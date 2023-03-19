using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    public static AvatarState currentAvatarState_R = AvatarState.Default;
    public static AvatarState currentAvatarState_L = AvatarState.Default;

    Vector3 Offset = new Vector3(0.0f, 0.0f, 0.9f);

    HandObject DefaultHandObject_R;
    HandObject DefaultHandObject_L;
    HandObject SkeletalHandObject_R;
    HandObject SkeletalHandObject_L;
    HandObject HighlightedHandObject_R;
    HandObject HighlightedHandObject_L;

    HMDObject HMDObject;

    GameObject DefaultHand_R;
    GameObject DefaultHand_L;
    GameObject SkeletalHand_R;
    GameObject SkeletalHand_L;
    GameObject HighlightedHand_R;
    GameObject HighlightedHand_L;

    GameObject HMD;

    [Header("Default Prefab to Instantiate")]
    [SerializeField] GameObject DefaultPrefab_R;
    [SerializeField] GameObject DefaultPrefab_L;

    [Header("Skeletal Prefab to Instantiate")]
    [SerializeField] GameObject SkeletalPrefab_R;
    [SerializeField] GameObject SkeletalPrefab_L;

    [Header("Highlighted Prefab to Instantiate")]
    [SerializeField] GameObject HighlightedPrefab_R;
    [SerializeField] GameObject HighlightedPrefab_L;

    [Header("HMD Prefab to Instantiate")]
    [SerializeField] GameObject HMDPrefab;

    [Header("Other Required References")]
    [SerializeField] private Transform AvatarHolder;

    public static Vector3 HMDDirection;
    public static Vector3 HMDPosition;

    private void Update()
    {
        if (Manager.SystemInitialized == true && Manager.ReloadSystem == false)
        {
            HMDDirection = HMD.transform.forward;
            HMDPosition = HMD.transform.position;
        }

    }

    #region SET AVATAR MODE

    public void SetMode(AvatarState state, Handedness handedness)
    {
        switch (state)
        {
            case AvatarState.Default:
                if (handedness == Handedness.Right)
                {
                    HighlightedHand_R.SetActive(false);
                    SkeletalHand_R.SetActive(false);
                    DefaultHand_R.SetActive(true);
                    currentAvatarState_R = AvatarState.Default;
                }
                else if (handedness == Handedness.Left)
                {
                    HighlightedHand_L.SetActive(false);
                    SkeletalHand_L.SetActive(false);
                    DefaultHand_L.SetActive(true);
                    currentAvatarState_L = AvatarState.Default;
                }
                else if (handedness == Handedness.Both)
                {
                    HighlightedHand_R.SetActive(false);
                    HighlightedHand_L.SetActive(false);
                    SkeletalHand_R.SetActive(false);
                    SkeletalHand_L.SetActive(false);
                    DefaultHand_R.SetActive(true);
                    DefaultHand_L.SetActive(true);
                    currentAvatarState_R = AvatarState.Default;
                    currentAvatarState_L = AvatarState.Default;
                }
                break;
            case AvatarState.Skeletal:
                if (handedness == Handedness.Right)
                {
                    HighlightedHand_R.SetActive(false);
                    SkeletalHand_R.SetActive(true);
                    DefaultHand_R.SetActive(false);
                    currentAvatarState_R = AvatarState.Skeletal;
                }
                else if (handedness == Handedness.Left)
                {
                    HighlightedHand_L.SetActive(false);
                    SkeletalHand_L.SetActive(true);
                    DefaultHand_L.SetActive(false);
                    currentAvatarState_L = AvatarState.Skeletal;
                }
                else if (handedness == Handedness.Both)
                {
                    HighlightedHand_R.SetActive(false);
                    HighlightedHand_L.SetActive(false);
                    SkeletalHand_R.SetActive(true);
                    SkeletalHand_L.SetActive(true);
                    DefaultHand_R.SetActive(false);
                    DefaultHand_L.SetActive(false);
                    currentAvatarState_R = AvatarState.Skeletal;
                    currentAvatarState_L = AvatarState.Skeletal;
                }
                break;
            case AvatarState.Highlighted:
                if (handedness == Handedness.Right)
                {
                    HighlightedHand_R.SetActive(true);
                    SkeletalHand_R.SetActive(false);
                    DefaultHand_R.SetActive(false);
                    currentAvatarState_R = AvatarState.Highlighted;
                }
                else if (handedness == Handedness.Left)
                {
                    HighlightedHand_L.SetActive(true);
                    SkeletalHand_L.SetActive(false);
                    DefaultHand_L.SetActive(false);
                    currentAvatarState_L = AvatarState.Highlighted;
                }
                else if (handedness == Handedness.Both)
                {
                    HighlightedHand_R.SetActive(true);
                    HighlightedHand_L.SetActive(true);
                    SkeletalHand_R.SetActive(false);
                    SkeletalHand_L.SetActive(false);
                    DefaultHand_R.SetActive(false);
                    DefaultHand_L.SetActive(false);
                    currentAvatarState_R = AvatarState.Highlighted;
                    currentAvatarState_L = AvatarState.Highlighted;
                }


                break;

        }
    }
    #endregion

    #region INITIALIZE AVATARS
    public void InstantiateAvatar()
    {
        InitializeDefaultAvatar();
        InitializeSkeletalAvatar();
        InitializeHighlightedAvatar();

        HMD = Object.Instantiate(HMDPrefab, MasterRecording.HMDMotion[0].HMDPosition, MasterRecording.HMDMotion[0].HMDRotation, AvatarHolder) as GameObject;
        HMDObject = HMD.GetComponent<HMDObject>();
    }

    public void InitializeDefaultAvatar()
    {
        DefaultHand_R = Object.Instantiate(DefaultPrefab_R, MasterRecording.RightHandSkeleton[0].HandPosition, MasterRecording.RightHandSkeleton[0].HandRotation, AvatarHolder) as GameObject;
        DefaultHand_L = Object.Instantiate(DefaultPrefab_L, MasterRecording.LeftHandSkeleton[0].HandPosition, MasterRecording.LeftHandSkeleton[0].HandRotation, AvatarHolder) as GameObject;

        DefaultHandObject_R = DefaultHand_R.GetComponent<HandObject>();
        DefaultHandObject_L = DefaultHand_L.GetComponent<HandObject>();
    }

    public void InitializeSkeletalAvatar()
    {
        SkeletalHand_R = Object.Instantiate(SkeletalPrefab_R, MasterRecording.RightHandSkeleton[0].HandPosition, MasterRecording.RightHandSkeleton[0].HandRotation, AvatarHolder) as GameObject;
        SkeletalHand_L = Object.Instantiate(SkeletalPrefab_L, MasterRecording.LeftHandSkeleton[0].HandPosition, MasterRecording.LeftHandSkeleton[0].HandRotation, AvatarHolder) as GameObject;

        SkeletalHandObject_R = SkeletalHand_R.GetComponent<HandObject>();
        SkeletalHandObject_L = SkeletalHand_L.GetComponent<HandObject>();
    }

    public void InitializeHighlightedAvatar()
    {
        HighlightedHand_R = Object.Instantiate(HighlightedPrefab_R, MasterRecording.RightHandSkeleton[0].HandPosition, MasterRecording.RightHandSkeleton[0].HandRotation, AvatarHolder) as GameObject;
        HighlightedHand_L = Object.Instantiate(HighlightedPrefab_L, MasterRecording.LeftHandSkeleton[0].HandPosition, MasterRecording.LeftHandSkeleton[0].HandRotation, AvatarHolder) as GameObject;

        HighlightedHandObject_R = HighlightedHand_R.GetComponent<HandObject>();
        HighlightedHandObject_L = HighlightedHand_L.GetComponent<HandObject>();
    }
    #endregion

    #region SET AVATAR TRANSFORM
    public void SetTransform(int index)
    {
        AvatarPlayback.currentFrame = index;

        HMDObject.SetDataForFrame(MasterRecording.HMDMotion[AvatarPlayback.currentFrame], Offset);


        switch (currentAvatarState_R)
        {
            case AvatarState.Default:
                DefaultHandObject_R.SetDataForFrame(MasterRecording.RightHandSkeleton[AvatarPlayback.currentFrame], Offset);
                break;
            case AvatarState.Skeletal:
                SkeletalHandObject_R.SetDataForFrame(MasterRecording.RightHandSkeleton[AvatarPlayback.currentFrame], Offset);
                break;
            case AvatarState.Highlighted:
                HighlightedHandObject_R.SetDataForFrame(MasterRecording.RightHandSkeleton[AvatarPlayback.currentFrame], Offset);
                break;
        }



        switch (currentAvatarState_L)
        {
            case AvatarState.Default:
                DefaultHandObject_L.SetDataForFrame(MasterRecording.LeftHandSkeleton[AvatarPlayback.currentFrame], Offset);
                break;
            case AvatarState.Skeletal:
                SkeletalHandObject_L.SetDataForFrame(MasterRecording.LeftHandSkeleton[AvatarPlayback.currentFrame], Offset);
                break;
            case AvatarState.Highlighted:
                HighlightedHandObject_L.SetDataForFrame(MasterRecording.LeftHandSkeleton[AvatarPlayback.currentFrame], Offset);
                break;
        }
    }
    #endregion

    public GameObject Avatar()
    {
        return HMD;
    }

    public GameObject CurrentAvatar_R()
    {
        if (currentAvatarState_R == AvatarState.Default) return DefaultHand_R;
        else if (currentAvatarState_R == AvatarState.Highlighted) return HighlightedHand_R;
        else return SkeletalHand_R;
    }

    public GameObject CurrentAvatar_L()
    {
        if (currentAvatarState_L == AvatarState.Default) return DefaultHand_L;
        else if (currentAvatarState_L == AvatarState.Highlighted) return HighlightedHand_L;
        else return SkeletalHand_L;
    }


}
