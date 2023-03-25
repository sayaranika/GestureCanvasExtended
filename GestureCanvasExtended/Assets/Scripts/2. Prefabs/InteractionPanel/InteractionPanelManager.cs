using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InteractionPanelManager : MonoBehaviour
{
    private bool isEditingResponse = false;

    #region VARIABLES
    [SerializeField] private TMPro.TextMeshProUGUI InteractionTitle;
    [SerializeField] GameObject HandCondition_R;
    [SerializeField] GameObject HandCondition_L;
    [SerializeField] GameObject AddInputParent;
    [SerializeField] GameObject AddInputBtn;
    [SerializeField] GameObject DeleteInteractionButton;

    [SerializeField] GameObject StartTestBtn;
    [SerializeField] GameObject CancelTestBtn;

    [Header("Right Hand UI")]
    [SerializeField] GameObject EditPose_R;
    [SerializeField] GameObject SetPose_R;
    [SerializeField] TMP_Dropdown GestureOrPoseDropdown_R;
    [SerializeField] GameObject Lock_R;
    [SerializeField] GameObject Unlock_R;
    [SerializeField] GameObject RemoveBtn_R;
    [SerializeField] GameObject AddSample_R;

    [Header("Left Hand UI")]
    [SerializeField] GameObject EditPose_L;
    [SerializeField] GameObject SetPose_L;
    [SerializeField] TMP_Dropdown GestureOrPoseDropdown_L;
    [SerializeField] GameObject Lock_L;
    [SerializeField] GameObject Unlock_L;
    [SerializeField] GameObject RemoveBtn_L;
    [SerializeField] GameObject AddSample_L;

    [Header("Response")]
    [SerializeField] GameObject editResponseBtn;
    [SerializeField] GameObject TrueBtn;
    [SerializeField] GameObject FalseBtn;
    [SerializeField] GameObject arrowImage;

    [SerializeField] GameObject actionPlate;
    [SerializeField] Transform logic;


    public Clip clipRef;
    public Interaction interactionRef;

    [SerializeField] GameObject ClipsPanel;
    [SerializeField] GameObject ClipPanelBtnPrefab;


    List<GameObject> clipPanelBtnList = new List<GameObject>();
    #endregion

    public void DeactivateClipPanelButtons()
    {
        foreach (GameObject obj in clipPanelBtnList)
        {
            Destroy(obj);
        }

        clipPanelBtnList.Clear();
    }

    public void EditResponse()
    {
        DeactivateClipPanelButtons();
        isEditingResponse = true;
        editResponseBtn.GetComponent<Image>().color = Color.cyan;
        ClipsPanel.SetActive(true);

        foreach (GameObject clipBtn in ClipManager.clipButtonList)
        {
            Clip clipBtnRef = clipBtn.GetComponent<ClipReference>().clip;



            GameObject instantiatedClipBtn = Instantiate(ClipPanelBtnPrefab, ClipsPanel.transform);
            instantiatedClipBtn.GetComponent<ClipPanelBtnManager>().clip = clipBtnRef;
            instantiatedClipBtn.GetComponent<ClipPanelBtnManager>().SetButtonText();
            instantiatedClipBtn.GetComponent<ClipPanelBtnManager>().interaction = interactionRef;

            clipPanelBtnList.Add(instantiatedClipBtn);
        }
        UIManager.UpdateLayout = true;
    }

    private void Start()
    {
        CancelTestBtn.SetActive(false);

        ClipsPanel.SetActive(false);
        isEditingResponse = false;
        editResponseBtn.GetComponent<Image>().color = Color.white;
    }

    #region SETTING PANEL CONTENTS

    public void SetPanelContents()
    {
        int id = 1;

        foreach (Interaction i in clipRef.interactions)
        {
            i.Id = id;
            id++;
        }

        InteractionTitle.text = "INT # " + interactionRef.Id;


        if (interactionRef.isGesture_R == true || interactionRef.isPose_R == true) SetHandCondition(Handedness.Right);
        else HandCondition_R.SetActive(false);

        if (interactionRef.isGesture_L == true || interactionRef.isPose_L == true) SetHandCondition(Handedness.Left);
        else HandCondition_L.SetActive(false);

        AddInputOption();

        SetResponses();


    }

    private void SetHandCondition(Handedness handedness)
    {
        switch (handedness)
        {
            case Handedness.Right:
                if (interactionRef.isGesture_R) SetGesture(HandCondition_R, GestureOrPoseDropdown_R, EditPose_R, SetPose_R, Lock_R, Unlock_R, AddSample_R);
                if (interactionRef.isPose_R)
                {
                    SetPose(HandCondition_R, GestureOrPoseDropdown_R, EditPose_R, SetPose_R, Lock_R, Unlock_R, AddSample_R);
                    SetTransform(Lock_R, Unlock_R, interactionRef.isTransformConstraint_R);
                }
                break;
            case Handedness.Left:
                if (interactionRef.isGesture_L) SetGesture(HandCondition_L, GestureOrPoseDropdown_L, EditPose_L, SetPose_L, Lock_L, Unlock_L, AddSample_L);
                if (interactionRef.isPose_L)
                {
                    SetPose(HandCondition_L, GestureOrPoseDropdown_L, EditPose_L, SetPose_L, Lock_L, Unlock_L, AddSample_L);
                    SetTransform(Lock_L, Unlock_L, interactionRef.isTransformConstraint_L);
                }
                break;
        }
    }

    private void SetGesture(GameObject HandCondition, TMP_Dropdown GestureOrPoseDropdown, GameObject EditPose, GameObject SetPose, GameObject Lock, GameObject Unlock, GameObject AddSample)
    {
        HandCondition.SetActive(true);
        GestureOrPoseDropdown.value = 0;

        EditPose.SetActive(false);
        SetPose.SetActive(false);
        Lock.SetActive(false);
        Unlock.SetActive(false);
        AddSample.SetActive(true);
    }

    private void SetPose(GameObject HandCondition, TMP_Dropdown GestureOrPoseDropdown, GameObject EditPose, GameObject SetPose, GameObject Lock, GameObject Unlock, GameObject AddSample)
    {
        HandCondition.SetActive(true);
        GestureOrPoseDropdown.value = 1;

        EditPose.SetActive(true);
        SetPose.SetActive(false);
        AddSample.SetActive(false);
    }

    private void SetTransform(GameObject Lock, GameObject Unlock, bool isTransformConstraint)
    {
        if (isTransformConstraint == true)
        {
            Lock.SetActive(true);
            Unlock.SetActive(false);
            Lock.GetComponent<Button>().interactable = false;
        }
        else
        {
            Lock.SetActive(false);
            Unlock.SetActive(true);
            Unlock.GetComponent<Button>().interactable = false;
        }
    }

    private void AddInputOption()
    {
        bool flag = false;
        if (clipRef.clipValidity.isDataValid_R == true)
        {
            if (interactionRef.isGesture_R == false && interactionRef.isPose_R == false) flag = true;
        }

        if (clipRef.clipValidity.isDataValid_L == true)
        {
            if (interactionRef.isGesture_L == false && interactionRef.isPose_L == false)
                flag = true;
        }

        AddInputParent.SetActive(flag);
    }

    public void SetResponses()
    {
        if (interactionRef.isConditionSetToTrue == true)
        {
            TrueBtn.SetActive(true);
            FalseBtn.SetActive(false);
        }
        else
        {
            TrueBtn.SetActive(false);
            FalseBtn.SetActive(true);
        }

        arrowImage.SetActive(true);

        if (interactionRef.transitionClip != null)
        {
            GameObject actionClip = Instantiate(actionPlate, logic);
            actionClip.GetComponent<ClipBtnHandler>().AssociateClip(interactionRef.transitionClip);
            actionClip.GetComponent<ClipBtnHandler>().interaction = interactionRef;


            //actionClip.GetComponentInChildren<Text>().text = "Clip " + interactionRef.transitionClip.Id;
            actionClip.GetComponent<Image>().color = Color.yellow;


            foreach (GameObject clipButton in ClipManager.clipButtonList)
            {
                clipButton.transform.GetChild(0).GetComponent<Image>().color = Color.grey;
                if (clipButton.GetComponent<ClipReference>().clip.Id == interactionRef.transitionClip.Id && InteractionVisibilityHandler.isInteractionBuilderOpen == true)
                {
                    clipButton.transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
                }
            }
        }
    }

    #endregion



    #region UI FUNCTIONS FOR EDITING INPUT
    public void DeleteInteraction()
    {
        clipRef.interactions.Remove(interactionRef);

        int id = 0;

        foreach (Interaction i in clipRef.interactions)
        {
            i.Id = id;
            id++;
        }

        InteractionBuilderContent.refresh = true;
        ClipManager.updateConnections = true;
    }

    public void RemoveHandCondition_R()
    {
        interactionRef.isGesture_R = false;
        interactionRef.isPose_R = false;

        InteractionBuilderContent.refresh = true;
    }

    public void RemoveHandCondition_L()
    {
        interactionRef.isGesture_L = false;
        interactionRef.isPose_L = false;

        InteractionBuilderContent.refresh = true;
    }

    public void HandConditionChanged_R()
    {
        int i = GestureOrPoseDropdown_R.value;

        if (i == 0)
        {
            interactionRef.isGesture_R = true;
            interactionRef.isPose_R = false;
        }
        else
        {
            interactionRef.isGesture_R = false;
            interactionRef.isPose_R = true;

            if (interactionRef.expectedPose_R == null)
            {
                SetDefaultHandPose(Handedness.Right);
            }
        }

        InteractionBuilderContent.refresh = true;
    }

    public void HandConditionChanged_L()
    {
        int i = GestureOrPoseDropdown_L.value;

        if (i == 0)
        {
            interactionRef.isGesture_L = true;
            interactionRef.isPose_L = false;
        }
        else
        {
            interactionRef.isGesture_L = false;
            interactionRef.isPose_L = true;

            if (interactionRef.expectedPose_L == null)
            {
                SetDefaultHandPose(Handedness.Left);
            }
        }

        InteractionBuilderContent.refresh = true;
    }

    public void LockPressed_R()
    {
        //if lock is pressed, you need to unlock it
        interactionRef.isTransformConstraint_R = false;
        Unlock(Lock_R, Unlock_R);
    }

    public void UnlockPressed_R()
    {
        //if unlock is pressed, you need to lock it and set the transform frame number
        interactionRef.isTransformConstraint_R = true;
        Lock(Lock_R, Unlock_R);
    }

    public void LockPressed_L()
    {
        interactionRef.isTransformConstraint_L = false;
        Unlock(Lock_L, Unlock_L);
    }

    public void UnlockPressed_L()
    {
        interactionRef.isTransformConstraint_L = true;
        Lock(Lock_L, Unlock_L);
    }

    public void EditPosePressed_L()
    {
        EditPosePressed(SetPose_L, EditPose_L, Lock_L, Unlock_L);
        //AvatarPlayback.currentFrame = (clipRef.HandPoses_L.First(s => s.handPose.HandPoseId == interactionRef.expectedPose_L.HandPoseId)).frameNumber;
    }

    public void EditPosePressed_R()
    {
        EditPosePressed(SetPose_R, EditPose_R, Lock_R, Unlock_R);
        //AvatarPlayback.currentFrame = interactionRef.expectedPose_L.frameNumber;
        //AvatarPlayback.currentFrame = (clipRef.HandPoses_R.First(s => s.handPose.HandPoseId == interactionRef.expectedPose_R.HandPoseId)).frameNumber;
    }

    public void SetPosePressed_R()
    {
        interactionRef.expectedPose_R = MasterRecording.RightHandPose[AvatarPlayback.currentFrame];
        SetPosePressed(SetPose_R, EditPose_R, Lock_R, Unlock_R);

    }

    public void SetPosePressed_L()
    {
        interactionRef.expectedPose_L = MasterRecording.LeftHandPose[AvatarPlayback.currentFrame];
        SetPosePressed(SetPose_L, EditPose_L, Lock_L, Unlock_L);

    }

    public void AddInput()
    {
        if (clipRef.clipValidity.isDataValid_R == true)
        {
            if (interactionRef.isGesture_R == false && interactionRef.isPose_R == false)
            {
                if (clipRef.DefaultInteraction.isGesture_R == true)
                    interactionRef.isGesture_R = true;
                else if (clipRef.DefaultInteraction.isPose_R == true)
                    interactionRef.isPose_R = true;
                else
                    interactionRef.isGesture_R = true;
            }
        }


        if (clipRef.clipValidity.isDataValid_L == true)
        {
            if (interactionRef.isGesture_L == false && interactionRef.isPose_L == false)
            {
                if (clipRef.DefaultInteraction.isGesture_L == true)
                    interactionRef.isGesture_L = true;
                else if (clipRef.DefaultInteraction.isPose_R == true)
                    interactionRef.isPose_L = true;
                else
                    interactionRef.isGesture_L = true;
            }
        }

        InteractionBuilderContent.refresh = true;
    }

    public void StartTest()
    {
        StartTestBtn.SetActive(false);
        CancelTestBtn.SetActive(true);

        DeleteInteractionButton.GetComponent<Button>().interactable = false;
        if (HandCondition_R.activeSelf == true)
        {
            RemoveBtn_R.GetComponent<Button>().interactable = false;
            GestureOrPoseDropdown_R.interactable = false;
            if (EditPose_R.activeSelf == true) EditPose_R.GetComponent<Button>().interactable = false;
            if (SetPose_R.activeSelf == true) SetPose_R.GetComponent<Button>().interactable = false;
            if (Lock_R.activeSelf == true) Lock_R.GetComponent<Button>().interactable = false;
            if (Unlock_R.activeSelf == true) Unlock_R.GetComponent<Button>().interactable = false;
            if (AddSample_R.activeSelf == true) AddSample_R.GetComponent<Button>().interactable = false;
        }
        if (HandCondition_L.activeSelf == true)
        {
            RemoveBtn_L.GetComponent<Button>().interactable = false;
            GestureOrPoseDropdown_L.interactable = false;
            if (SetPose_L.activeSelf == true) SetPose_L.GetComponent<Button>().interactable = false;
            if (EditPose_L.activeSelf == true) EditPose_L.GetComponent<Button>().interactable = false;
            if (Lock_L.activeSelf == true) Lock_L.GetComponent<Button>().interactable = false;
            if (Unlock_L.activeSelf == true) Unlock_L.GetComponent<Button>().interactable = false;
            if (AddSample_L.activeSelf == true) AddSample_L.GetComponent<Button>().interactable = false;
        }

        AddInputBtn.GetComponent<Button>().interactable = false;


        if (TrueBtn.activeSelf == true) TrueBtn.GetComponent<Button>().interactable = false;
        if (FalseBtn.activeSelf == true) FalseBtn.GetComponent<Button>().interactable = false;

        AddInteractionManager.deactivateButton = true;

        UIButtonsManager.hideButtons = true;

        foreach (GameObject buttons in ClipManager.clipButtonList)
            buttons.transform.GetChild(0).GetComponent<Toggle>().interactable = false;

        OnTheFlyTest.StartTest(interactionRef);
    }

    public void CancelTest()
    {
        StartTestBtn.SetActive(true);
        CancelTestBtn.SetActive(false);

        DeleteInteractionButton.GetComponent<Button>().interactable = true;
        if (HandCondition_R.activeSelf == true)
        {
            RemoveBtn_R.GetComponent<Button>().interactable = true;
            GestureOrPoseDropdown_R.interactable = true;
            if (EditPose_R.activeSelf == true) EditPose_R.GetComponent<Button>().interactable = true;
            if (SetPose_R.activeSelf == true) SetPose_R.GetComponent<Button>().interactable = true;
            if (Lock_R.activeSelf == true) Lock_R.GetComponent<Button>().interactable = true;
            if (Unlock_R.activeSelf == true) Unlock_R.GetComponent<Button>().interactable = true;
            if (AddSample_R.activeSelf == true) AddSample_R.GetComponent<Button>().interactable = true;
        }
        if (HandCondition_L.activeSelf == true)
        {
            RemoveBtn_L.GetComponent<Button>().interactable = true;
            GestureOrPoseDropdown_L.interactable = true;
            if (SetPose_L.activeSelf == true) SetPose_L.GetComponent<Button>().interactable = true;
            if (EditPose_L.activeSelf == true) EditPose_L.GetComponent<Button>().interactable = true;
            if (Lock_L.activeSelf == true) Lock_L.GetComponent<Button>().interactable = true;
            if (Unlock_L.activeSelf == true) Unlock_L.GetComponent<Button>().interactable = true;
            if (AddSample_L.activeSelf == true) AddSample_L.GetComponent<Button>().interactable = true;
        }

        AddInputBtn.GetComponent<Button>().interactable = true;


        if (TrueBtn.activeSelf == true) TrueBtn.GetComponent<Button>().interactable = true;
        if (FalseBtn.activeSelf == true) FalseBtn.GetComponent<Button>().interactable = true;

        AddInteractionManager.activateButton = true;

        UIButtonsManager.showButtons = true;

        foreach (GameObject buttons in ClipManager.clipButtonList)
            buttons.transform.GetChild(0).GetComponent<Toggle>().interactable = true;

        //TestManager.StopTest = false;
        OnTheFlyTest.StopTest = true;
    }

    public void AddGestureSample_R()
    {

    }

    public void AddGestureSample_L()
    {

    }



    #endregion



    #region UI FUNCTIONS FOR EDITING RESPONSES



    public void TruePressed()
    {
        interactionRef.isConditionSetToTrue = false;
        InteractionBuilderContent.refresh = true;
    }

    public void FalsePressed()
    {
        interactionRef.isConditionSetToTrue = true;
        InteractionBuilderContent.refresh = true;
    }

    #endregion


    #region HELPERS


    public void SetPosePressed(GameObject SetPose, GameObject EditPose, GameObject Lock, GameObject Unlock)
    {
        //enable set pose button
        SetPose.SetActive(false);
        EditPose.SetActive(true);

        if (HandCondition_R.activeSelf == true)
        {
            RemoveBtn_R.GetComponent<Button>().interactable = true;
            GestureOrPoseDropdown_R.interactable = true;
        }
        if (HandCondition_L.activeSelf == true)
        {
            RemoveBtn_L.GetComponent<Button>().interactable = true;
            GestureOrPoseDropdown_L.interactable = true;
        }
        AddInputBtn.GetComponent<Button>().interactable = true;
        DeleteInteractionButton.GetComponent<Button>().interactable = true;

        if (TrueBtn.activeSelf == true) TrueBtn.GetComponent<Button>().interactable = true;
        if (FalseBtn.activeSelf == true) FalseBtn.GetComponent<Button>().interactable = true;

        AddInteractionManager.activateButton = true;

        UIButtonsManager.showButtons = true;

        foreach (GameObject buttons in ClipManager.clipButtonList)
            buttons.transform.GetChild(0).GetComponent<Toggle>().interactable = true;

        //show instruction panel
        InformationPanelManager.hideInformation = true;


        AvatarPlayback.currentState = PlaybackState.InPlaybackState;
        InteractionBuilderContent.refresh = true;

    }





    public void EditPosePressed(GameObject SetPose, GameObject EditPose, GameObject Lock, GameObject Unlock)
    {
        //enable set pose button
        SetPose.SetActive(true);
        EditPose.SetActive(false);


        if (Lock.activeSelf == true) Lock.GetComponent<Button>().interactable = true;
        if (Unlock.activeSelf == true) Unlock.GetComponent<Button>().interactable = true;

        if (HandCondition_R.activeSelf == true)
        {
            RemoveBtn_R.GetComponent<Button>().interactable = false;
            GestureOrPoseDropdown_R.interactable = false;
        }
        if (HandCondition_L.activeSelf == true)
        {
            RemoveBtn_L.GetComponent<Button>().interactable = false;
            GestureOrPoseDropdown_L.interactable = false;
        }
        AddInputBtn.GetComponent<Button>().interactable = false;
        DeleteInteractionButton.GetComponent<Button>().interactable = false;

        if (TrueBtn.activeSelf == true) TrueBtn.GetComponent<Button>().interactable = false;
        if (FalseBtn.activeSelf == true) FalseBtn.GetComponent<Button>().interactable = false;

        AddInteractionManager.deactivateButton = true;

        UIButtonsManager.hideButtons = true;

        foreach (GameObject buttons in ClipManager.clipButtonList)
            buttons.transform.GetChild(0).GetComponent<Toggle>().interactable = false;



        //show instruction panel
        InformationPanelManager.showInformation = true;


        //pause playback in the frame of current selected pose
        AvatarPlayback.currentState = PlaybackState.InPauseState;
    }

    public void Lock(GameObject Lock, GameObject Unlock)
    {
        Lock.SetActive(true);
        Unlock.SetActive(false);
    }

    public void Unlock(GameObject Lock, GameObject Unlock)
    {
        Lock.SetActive(false);
        Unlock.SetActive(true);
    }

    private void SetDefaultHandPose(Handedness handedness)
    {
        switch (handedness)
        {
            case Handedness.Right:
                HandPoseInstance max = null;
                int maxCount = -1;
                foreach (HandPoseInstance hp in clipRef.HandPoses_R)
                {
                    if (hp.count > maxCount)
                    {
                        max = hp;
                        maxCount = hp.count;
                    }
                }

                if (max != null)
                {
                    interactionRef.expectedPose_R = max.handPose;
                }
                break;
            case Handedness.Left:
                HandPoseInstance max_L = null;
                int maxCount_L = -1;
                foreach (HandPoseInstance hp in clipRef.HandPoses_L)
                {
                    if (hp.count > maxCount_L)
                    {
                        max_L = hp;
                        maxCount_L = hp.count;
                    }
                }

                if (max_L != null)
                {
                    interactionRef.expectedPose_L = max_L.handPose;
                }
                break;
        }
    }

    #endregion
}
