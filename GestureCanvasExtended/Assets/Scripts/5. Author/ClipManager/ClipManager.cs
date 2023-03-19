using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClipManager : MonoBehaviour
{
    [Header("Clip References to Instantiate")]
    [SerializeField] private GameObject clipPrefab;
    [SerializeField] Transform clipPanel;
    [SerializeField] private ToggleGroup clipToggleGroup;

    [Header("Arrow Prefabs to Instantiate")]
    [SerializeField] GameObject ArrowPrefab;
    [SerializeField] GameObject ArrowHeadPrefab;

    [Header("Script References")]
    [SerializeField] AvatarManager avatarManager;

    public static List<GameObject> clipButtonList = new List<GameObject>();
    public List<LineRenderer> transitionArrowList = new List<LineRenderer>();

    public static bool isClipSelectionOn = false;
    public static Clip selectedClip = null;

    public static bool updateConnections = false;

    private void Update()
    {
        if (updateConnections == true && ClipHandler.ClipList.Count > 1)
        {
            DrawTransitions();
            updateConnections = false;
        }

    }

    #region ADD CLIP BUTTONS
    public void AddClipButtons()
    {
        int numberOfClips = ClipHandler.ClipList.Count;

        foreach (ClipButton clipButton in ClipButtonHandler.ClipButtonList)
        {
            var button = GameObject.Instantiate(clipPrefab, clipPanel);
            button.transform.localPosition = new Vector3(0, 0, 0);
            button.transform.position = new Vector3(clipButton.StartPosition, button.transform.position.y, button.transform.position.z);
            Vector3 rescale = button.transform.localScale;

            float startVal = clipButton.StartPosition * 100.0f;
            float endVal = clipButton.EndPosition * 100.0f;

            rescale.x = ((endVal - startVal) * 2.0f);

            button.transform.localScale = rescale;



            Toggle buttonToggle = button.transform.GetChild(0).GetComponent<Toggle>();
            buttonToggle.group = clipToggleGroup;
            buttonToggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(buttonToggle, button, clipButton.clip.Id);
            });


            //set button ref
            button.GetComponent<ClipReference>().clip = clipButton.clip;
            button.GetComponent<ClipReference>().clipButton = clipButton;

            clipButtonList.Add(button);

            clipButton.button = button;

        }
    }

    void ToggleValueChanged(Toggle toggleButton, GameObject clipButton, int clipId)
    {
        if (isClipSelectionOn == true)
        {
            foreach (Clip clip in ClipHandler.ClipList)
            {
                if (clip.Id == clipId)
                {
                    selectedClip = clip;
                    break;
                }
            }
        }
        else
        {
            Clip _selectedClip = null;

            foreach (ClipButton clipButtons in ClipButtonHandler.ClipButtonList)
            {
                if (clipButtons.clip.Id == clipId)
                {
                    clipButtons.isToggleOn = toggleButton.isOn;
                    if (toggleButton.isOn == true) _selectedClip = clipButtons.clip;
                    break;
                }
            }

            if (selectedClip != null)
            {
                AvatarPlayback.startFrame = selectedClip.startIndex;
                AvatarPlayback.endFrame = selectedClip.endIndex;
                AvatarPlayback.currentClip = selectedClip;
                AvatarPlayback.currentClipButton = clipButton;
                avatarManager.SetTransform(selectedClip.startIndex);
            }
            else
            {
                AvatarPlayback.startFrame = 0;
                AvatarPlayback.endFrame = Playback.frameCount;
                AvatarPlayback.currentClip = null;
                AvatarPlayback.currentClipButton = null;
                AssetPanelVisibilityHandler.hideAssetPanel = true;
            }

            InteractionBuilderContent.refresh = true;
        }
    }

    #endregion

    #region DRAW TRANSITIONS
    public void DrawTransitions()
    {
        if (transitionArrowList.Count > 0)
        {
            foreach (LineRenderer l in transitionArrowList)
            {
                Destroy(l.gameObject);
            }
        }

        transitionArrowList.Clear();
        foreach (ClipButton clipButton in ClipButtonHandler.ClipButtonList)
        {
            foreach (Interaction interaction in clipButton.clip.interactions)
            {
                if (interaction.transitionClip != null)
                {
                    GameObject transitionClipButton = null;
                    foreach(ClipButton cb in ClipButtonHandler.ClipButtonList)
                    {
                        if(cb.clip.Id == interaction.transitionClip.Id)
                        {
                            transitionClipButton = cb.button;
                            break;
                        }
                    }

                    if(transitionClipButton != null) DrawArrow(clipButton.button, transitionClipButton);
                }
            }
        }
    }

    public void DrawArrow(GameObject source, GameObject destination, PointingDirection pointingDirection)
    {
        LineRenderer arrow = Object.Instantiate(ArrowPrefab, clipPanel).GetComponent<LineRenderer>();
        arrow.positionCount = 2;
        arrow.startWidth = .001f;
        arrow.endWidth = .001f;
        switch (pointingDirection)
        {
            case PointingDirection.Right:
                arrow.SetPosition(0, source.transform.GetChild(1).transform.position);
                arrow.SetPosition(1, destination.transform.GetChild(2).transform.position);
                break;
            case PointingDirection.Left:
                arrow.SetPosition(0, source.transform.GetChild(4).transform.position);
                arrow.SetPosition(1, destination.transform.GetChild(3).transform.position);
                break;
        }



        LineRenderer arrowHead = Object.Instantiate(ArrowHeadPrefab, clipPanel).GetComponent<LineRenderer>();
        arrowHead.positionCount = 2;
        arrowHead.startWidth = .004f;
        arrowHead.endWidth = .00f;
        switch (pointingDirection)
        {
            case PointingDirection.Right:
                arrowHead.SetPosition(0, destination.transform.GetChild(2).transform.GetChild(0).transform.position);
                arrowHead.SetPosition(1, destination.transform.GetChild(2).transform.position);
                break;
            case PointingDirection.Left:
                arrowHead.SetPosition(0, destination.transform.GetChild(3).transform.GetChild(0).transform.position);
                arrowHead.SetPosition(1, destination.transform.GetChild(3).transform.position);
                break;
        }


        transitionArrowList.Add(arrow);
        transitionArrowList.Add(arrowHead);
    }

    public void DrawArrow(GameObject source, GameObject destination)
    {
        bool ArrowDrawn = false;
        int sourceClipId = source.GetComponent<ClipReference>().clip.Id;
        int destClipId = destination.GetComponent<ClipReference>().clip.Id;

        if (clipButtonList[0].GetComponent<ClipReference>().clip.Id == sourceClipId && clipButtonList[1].GetComponent<ClipReference>().clip.Id == destClipId)
        {
            DrawArrow(source, destination, PointingDirection.Right);
            ArrowDrawn = true;
        }
        else if (clipButtonList[clipButtonList.Count - 1].GetComponent<ClipReference>().clip.Id == sourceClipId && clipButtonList[clipButtonList.Count - 2].GetComponent<ClipReference>().clip.Id == destClipId)
        {
            DrawArrow(source, destination, PointingDirection.Left);
            ArrowDrawn = true;
        }
        else
        {
            for (int i = 1; i < clipButtonList.Count - 1; i++)
            {
                if (clipButtonList[i].GetComponent<ClipReference>().clip.Id == sourceClipId)
                {
                    if (clipButtonList[i + 1].GetComponent<ClipReference>().clip.Id == destClipId)
                    {
                        DrawArrow(source, destination, PointingDirection.Right);
                        ArrowDrawn = true;
                    }
                    else if (clipButtonList[i - 1].GetComponent<ClipReference>().clip.Id == destClipId)
                    {
                        DrawArrow(source, destination, PointingDirection.Left);
                        ArrowDrawn = true;
                    }
                }
            }
        }

        if (ArrowDrawn == false) //arrow needs to be drawn between clips that are not adjacent
        {
            //down line
            LineRenderer lineDown = Object.Instantiate(ArrowPrefab, clipPanel).GetComponent<LineRenderer>();
            lineDown.positionCount = 2;
            lineDown.startWidth = .001f;
            lineDown.endWidth = .001f;
            lineDown.SetPosition(0, source.transform.GetChild(6).transform.position);
            lineDown.SetPosition(1, source.transform.GetChild(6).transform.GetChild(0).transform.position);
            transitionArrowList.Add(lineDown);

            //side line straight
            LineRenderer lineStraight = Object.Instantiate(ArrowPrefab, clipPanel).GetComponent<LineRenderer>();
            lineStraight.positionCount = 2;
            lineStraight.startWidth = .001f;
            lineStraight.endWidth = .001f;
            lineStraight.SetPosition(0, source.transform.GetChild(6).transform.GetChild(0).transform.position);
            lineStraight.SetPosition(1, destination.transform.GetChild(5).transform.GetChild(0).transform.position);
            transitionArrowList.Add(lineStraight);

            //line up
            LineRenderer lineUp = Object.Instantiate(ArrowPrefab, clipPanel).GetComponent<LineRenderer>();
            lineUp.positionCount = 2;
            lineUp.startWidth = .001f;
            lineUp.endWidth = .001f;
            lineUp.SetPosition(0, destination.transform.GetChild(5).transform.position);
            lineUp.SetPosition(1, destination.transform.GetChild(5).transform.GetChild(0).transform.position);
            transitionArrowList.Add(lineUp);

            //arrowhead
            LineRenderer arrowHeadUp = Object.Instantiate(ArrowHeadPrefab, clipPanel).GetComponent<LineRenderer>();
            arrowHeadUp.positionCount = 2;
            arrowHeadUp.startWidth = .004f; //.005f
            arrowHeadUp.endWidth = .000f;
            arrowHeadUp.SetPosition(0, destination.transform.GetChild(5).transform.GetChild(1).transform.position);
            arrowHeadUp.SetPosition(1, destination.transform.GetChild(5).transform.position);
            transitionArrowList.Add(arrowHeadUp);
        }
    }

    #endregion
}
