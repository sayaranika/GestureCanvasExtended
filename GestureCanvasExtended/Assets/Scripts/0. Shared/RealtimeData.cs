using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealtimeData : MonoBehaviour
{
    [SerializeField] HandPoseRecorder handPoseRecorder;

    public HandPose RightHandPose;
    public HandPose LeftHandPose;

    private void LateUpdate()
    {
        GetData();
    }

    public void GetData()
    {
        RightHandPose = handPoseRecorder.GetRightHandPose();
        LeftHandPose = handPoseRecorder.GetLeftHandPose();
    }
}