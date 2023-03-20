using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealtimeData : MonoBehaviour
{
    [SerializeField] HandPoseRecorder handPoseRecorder;

    //public bool getRealtimeData = false;
    public HandPose RightHandPose;
    public HandPose LeftHandPose;

    private void LateUpdate()
    {
        //if (getRealtimeData == true) 
            GetData();
    }

    public void GetData()
    {
        RightHandPose = handPoseRecorder.GetRightHandPose();
        LeftHandPose = handPoseRecorder.GetLeftHandPose();
    }
}
