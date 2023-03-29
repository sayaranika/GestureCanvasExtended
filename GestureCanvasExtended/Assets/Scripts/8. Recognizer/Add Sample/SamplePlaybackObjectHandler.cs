using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlaybackObjectHandler : MonoBehaviour
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
        if(SampleRecording.interaction.isGesture_R == true)
        {
            this.RightHandObject = Object.Instantiate(RightHandSolidPrefab,
                                                  SampleRecording.RightHandSkeleton[0].HandPosition,
                                                  SampleRecording.RightHandSkeleton[0].HandRotation, prefabHolderTransform).GetComponent<HandObject>();
        }
        
        if(SampleRecording.interaction.isGesture_L == true)
        {
            this.LeftHandObject = Object.Instantiate(LeftHandSolidPrefab,
                                                     SampleRecording.LeftHandSkeleton[0].HandPosition,
                                                     SampleRecording.LeftHandSkeleton[0].HandRotation, prefabHolderTransform).GetComponent<HandObject>();
        }

        this.HMDObject = Object.Instantiate(HMDTransparent,
                                                      SampleRecording.HMDMotion[0].HMDPosition,
                                                      SampleRecording.HMDMotion[0].HMDRotation, prefabHolderTransform).GetComponent<HMDObject>();

        //reset player position
        UI.transform.position = CenterEye.transform.position + new Vector3(0, 1.0f, 0.25f);

    }

    public void SetReplayObjectTransform(int index)
    {
        SamplePlaybackHandler.currentPlaybackIndex = index;

        if(SampleRecording.interaction.isGesture_R == true)
        {
            HandSkeleton rightHandData = SampleRecording.RightHandSkeleton[SamplePlaybackHandler.currentPlaybackIndex];
            RightHandObject.SetDataForFrame(rightHandData, AvatarOffset);
        }
        
        if(SampleRecording.interaction.isGesture_L == true)
        {
            HandSkeleton leftHandData = SampleRecording.LeftHandSkeleton[SamplePlaybackHandler.currentPlaybackIndex];
            LeftHandObject.SetDataForFrame(leftHandData, AvatarOffset);
        }

        

        HMDMotion hmdData = SampleRecording.HMDMotion[SamplePlaybackHandler.currentPlaybackIndex];
        HMDObject.SetDataForFrame(hmdData, AvatarOffset);
    }
}
