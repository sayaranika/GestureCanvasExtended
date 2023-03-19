using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandObject : MonoBehaviour
{
    [SerializeField] private GameObject HandModel;

    [SerializeField]
    private GameObject Index1, Index2, Index3;

    [SerializeField]
    private GameObject Thumb0, Thumb1, Thumb2, Thumb3;

    [SerializeField]
    private GameObject Middle1, Middle2, Middle3;

    [SerializeField]
    private GameObject Ring1, Ring2, Ring3;

    [SerializeField]
    private GameObject Pinky0, Pinky1, Pinky2, Pinky3;

    [SerializeField]
    private GameObject Wrist,  ForearmStub;


    


    public void SetDataForFrame(HandSkeleton data, Vector3 PositionOffset)
    {
        HandModel.transform.position = data.HandPosition + PositionOffset;
        //HandModel.transform.position = data.HandPosition;
        HandModel.transform.rotation = data.HandRotation;

        Wrist.transform.localPosition = data.WristPosition;
        Wrist.transform.localRotation = data.WristRotation;
        ForearmStub.transform.localPosition = data.ForearmStubPosition;
        ForearmStub.transform.localRotation = data.ForearmStubRotation;

        Index1.transform.localPosition = data.Index1Position;
        Index1.transform.localRotation = data.Index1Rotation;
        Index2.transform.localPosition = data.Index2Position;
        Index2.transform.localRotation = data.Index2Rotation;
        Index3.transform.localPosition = data.Index3Position;
        Index3.transform.localRotation = data.Index3Rotation;


        Middle1.transform.localPosition = data.Middle1Position;
        Middle1.transform.localRotation = data.Middle1Rotation;
        Middle2.transform.localPosition = data.Middle2Position;
        Middle2.transform.localRotation = data.Middle2Rotation;
        Middle3.transform.localPosition = data.Middle3Position;
        Middle3.transform.localRotation = data.Middle3Rotation;


        Pinky0.transform.localPosition = data.Pinky0Position;
        Pinky0.transform.localRotation = data.Pinky0Rotation;
        Pinky1.transform.localPosition = data.Pinky1Position;
        Pinky1.transform.localRotation = data.Pinky1Rotation;
        Pinky2.transform.localPosition = data.Pinky2Position;
        Pinky2.transform.localRotation = data.Pinky2Rotation;
        Pinky3.transform.localPosition = data.Pinky3Position;
        Pinky3.transform.localRotation = data.Pinky3Rotation;


        Thumb0.transform.localPosition = data.Thumb0Position;
        Thumb0.transform.localRotation = data.Thumb0Rotation;
        Thumb1.transform.localPosition = data.Thumb1Position;
        Thumb1.transform.localRotation = data.Thumb1Rotation;
        Thumb2.transform.localPosition = data.Thumb2Position;
        Thumb2.transform.localRotation = data.Thumb2Rotation;
        Thumb3.transform.localPosition = data.Thumb3Position;
        Thumb3.transform.localRotation = data.Thumb3Rotation;


        Ring1.transform.localPosition = data.Ring1Position;
        Ring1.transform.localRotation = data.Ring1Rotation;
        Ring2.transform.localPosition = data.Ring2Position;
        Ring2.transform.localRotation = data.Ring2Rotation;
        Ring3.transform.localPosition = data.Ring3Position;
        Ring3.transform.localRotation = data.Ring3Rotation;
    }
}
