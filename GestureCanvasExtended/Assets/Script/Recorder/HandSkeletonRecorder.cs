using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSkeletonRecorder : MonoBehaviour
{
    #region Hand Positional and Rotational Variables

    /////////////////////////////////////////////// HAND POSITIONAL INFO ///////////////////////////////////////////////
    private Vector3 HandPosition;
    private Vector3 WristPosition;
    private Vector3 ForearmStubPosition;
    private Vector3 Index1Position;
    private Vector3 Index2Position;
    private Vector3 Index3Position;
    private Vector3 Thumb0Position;
    private Vector3 Thumb1Position;
    private Vector3 Thumb2Position;
    private Vector3 Thumb3Position;
    private Vector3 Middle1Position;
    private Vector3 Middle2Position;
    private Vector3 Middle3Position;
    private Vector3 Ring1Position;
    private Vector3 Ring2Position;
    private Vector3 Ring3Position;
    private Vector3 Pinky0Position;
    private Vector3 Pinky1Position;
    private Vector3 Pinky2Position;
    private Vector3 Pinky3Position;

    /////////////////////////////////////////////// HAND ROTATIONAL INFO ///////////////////////////////////////////////

    private Quaternion HandRotation;
    private Quaternion ForearmStubRotation;
    private Quaternion WristRotation;
    private Quaternion Index1Rotation;
    private Quaternion Index2Rotation;
    private Quaternion Index3Rotation;
    private Quaternion Thumb0Rotation;
    private Quaternion Thumb1Rotation;
    private Quaternion Thumb2Rotation;
    private Quaternion Thumb3Rotation;
    private Quaternion Middle1Rotation;
    private Quaternion Middle2Rotation;
    private Quaternion Middle3Rotation;
    private Quaternion Ring1Rotation;
    private Quaternion Ring2Rotation;
    private Quaternion Ring3Rotation;
    private Quaternion Pinky0Rotation;
    private Quaternion Pinky1Rotation;
    private Quaternion Pinky2Rotation;
    private Quaternion Pinky3Rotation;

    #endregion

    #region GET HAND SKELETON DATA
    public HandSkeleton GetHandSkeleton(OVRSkeleton ovrSkeleton, OVRHand ovrHand)
    {
        if (ovrHand.IsTracked && ovrHand.IsDataValid)
        {
            HandPosition = ovrSkeleton.transform.position;
            WristPosition = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_WristRoot].Transform.localPosition;
            ForearmStubPosition = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_ForearmStub].Transform.localPosition;
            Index1Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index1].Transform.localPosition;
            Index2Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index2].Transform.localPosition;
            Index3Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index3].Transform.localPosition;
            Thumb0Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb0].Transform.localPosition;
            Thumb1Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb1].Transform.localPosition;
            Thumb2Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb2].Transform.localPosition;
            Thumb3Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb3].Transform.localPosition;
            Middle1Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle1].Transform.localPosition;
            Middle2Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle2].Transform.localPosition;
            Middle3Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle3].Transform.localPosition;
            Ring1Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring1].Transform.localPosition;
            Ring2Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring2].Transform.localPosition;
            Ring3Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring3].Transform.localPosition;
            Pinky0Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky0].Transform.localPosition;
            Pinky1Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky1].Transform.localPosition;
            Pinky2Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky2].Transform.localPosition;
            Pinky3Position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky3].Transform.localPosition;

            HandRotation = ovrSkeleton.transform.rotation;
            ForearmStubRotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_ForearmStub].Transform.localRotation;
            WristRotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_WristRoot].Transform.localRotation;
            Index1Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index1].Transform.localRotation;
            Index2Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index2].Transform.localRotation;
            Index3Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index3].Transform.localRotation;
            Thumb0Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb0].Transform.localRotation;
            Thumb1Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb1].Transform.localRotation;
            Thumb2Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb2].Transform.localRotation;
            Thumb3Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb3].Transform.localRotation;
            Middle1Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle1].Transform.localRotation;
            Middle2Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle2].Transform.localRotation;
            Middle3Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle3].Transform.localRotation;
            Ring1Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring1].Transform.localRotation;
            Ring2Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring2].Transform.localRotation;
            Ring3Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring3].Transform.localRotation;
            Pinky0Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky0].Transform.localRotation;
            Pinky1Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky1].Transform.localRotation;
            Pinky2Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky2].Transform.localRotation;
            Pinky3Rotation = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky3].Transform.localRotation;

        }
        else
        {
            HandPosition = new Vector3(-1000.0f, -1000.0f, -1000.0f); //INVALID FRAME
            WristPosition = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            ForearmStubPosition = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Index1Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Index2Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Index3Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Thumb0Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Thumb1Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Thumb2Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Thumb3Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Middle1Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Middle2Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Middle3Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Ring1Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Ring2Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Ring3Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Pinky0Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Pinky1Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Pinky2Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);
            Pinky3Position = new Vector3(-1000.0f, -1000.0f, -1000.0f);

            HandRotation = Quaternion.identity;
            ForearmStubRotation = Quaternion.identity;
            WristRotation = Quaternion.identity;
            Index1Rotation = Quaternion.identity;
            Index2Rotation = Quaternion.identity;
            Index3Rotation = Quaternion.identity;
            Thumb0Rotation = Quaternion.identity;
            Thumb1Rotation = Quaternion.identity;
            Thumb2Rotation = Quaternion.identity;
            Thumb3Rotation = Quaternion.identity;
            Middle1Rotation = Quaternion.identity;
            Middle2Rotation = Quaternion.identity;
            Middle3Rotation = Quaternion.identity;
            Ring1Rotation = Quaternion.identity;
            Ring2Rotation = Quaternion.identity;
            Ring3Rotation = Quaternion.identity;
            Pinky0Rotation = Quaternion.identity;
            Pinky1Rotation = Quaternion.identity;
            Pinky2Rotation = Quaternion.identity;
            Pinky3Rotation = Quaternion.identity;

        }

        return new HandSkeleton(
        HandPosition,
        WristPosition,
        ForearmStubPosition,
        Index1Position,
        Index2Position,
        Index3Position,
        Thumb0Position,
        Thumb1Position,
        Thumb2Position,
        Thumb3Position,
        Middle1Position,
        Middle2Position,
        Middle3Position,
        Ring1Position,
        Ring2Position,
        Ring3Position,
        Pinky0Position,
        Pinky1Position,
        Pinky2Position,
        Pinky3Position,
        HandRotation,
        WristRotation,
        ForearmStubRotation,
        Index1Rotation,
        Index2Rotation,
        Index3Rotation,
        Thumb0Rotation,
        Thumb1Rotation,
        Thumb2Rotation,
        Thumb3Rotation,
        Middle1Rotation,
        Middle2Rotation,
        Middle3Rotation,
        Ring1Rotation,
        Ring2Rotation,
        Ring3Rotation,
        Pinky0Rotation,
        Pinky1Rotation,
        Pinky2Rotation,
        Pinky3Rotation
            );
    }

    #endregion


}
