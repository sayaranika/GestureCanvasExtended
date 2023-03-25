using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackObjectHandler : MonoBehaviour
{
    [Header("Prefab to Instantiate")]
    [SerializeField] GameObject HMDTransparent;
    [SerializeField] GameObject RightHandSolidPrefab;
    [SerializeField] GameObject LeftHandSolidPrefab;

    [Header("Avatar Parent")]
    [SerializeField] Transform prefabHolderTransform;

    [Header("UI")]
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject CenterEye;

    public HandObject RightHandObject { get; private set; }
    public HandObject LeftHandObject { get; private set; }
    public HMDObject HMDObject { get; private set; }

    private Vector3 AvatarOffset = new Vector3(0.0f, 0.0f, 0.6f);

    //////////////////////////   INSTANTIATE REPLAY OBJECTS   //////////////////////////

    public void InstantiateReplayObject()
    {
        this.RightHandObject = Object.Instantiate(RightHandSolidPrefab,
                                                  MasterRecording.RightHandSkeleton[0].HandPosition,
                                                  MasterRecording.RightHandSkeleton[0].HandRotation, prefabHolderTransform).GetComponent<HandObject>();

        this.LeftHandObject = Object.Instantiate(LeftHandSolidPrefab,
                                                     MasterRecording.LeftHandSkeleton[0].HandPosition,
                                                     MasterRecording.LeftHandSkeleton[0].HandRotation, prefabHolderTransform).GetComponent<HandObject>();

        this.HMDObject = Object.Instantiate(HMDTransparent,
                                                      MasterRecording.HMDMotion[0].HMDPosition,
                                                      MasterRecording.HMDMotion[0].HMDRotation, prefabHolderTransform).GetComponent<HMDObject>();

        //reset player position
        UI.transform.position = CenterEye.transform.position + new Vector3(0,0.4f,0.25f);

    }

    //////////////////////////   SET REPLAY OBJECT TRANSFORM   //////////////////////////

    public void SetReplayObjectTransform(int index)
    {
        PlaybackHandler.currentPlaybackIndex = index;

        HandSkeleton rightHandData = MasterRecording.RightHandSkeleton[PlaybackHandler.currentPlaybackIndex];
        RightHandObject.SetDataForFrame(rightHandData, AvatarOffset);

        HandSkeleton leftHandData = MasterRecording.LeftHandSkeleton[PlaybackHandler.currentPlaybackIndex];
        LeftHandObject.SetDataForFrame(leftHandData, AvatarOffset);

        HMDMotion hmdData = MasterRecording.HMDMotion[PlaybackHandler.currentPlaybackIndex];
        HMDObject.SetDataForFrame(hmdData, AvatarOffset);
    }
}
