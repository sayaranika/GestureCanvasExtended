using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseRecognizer : MonoBehaviour
{
    [SerializeField] RealtimeData realtimeData;

    public bool Recognize(Handedness handedness, HandPose handPose_R, HandPose handPose_L, bool isTransformConstraint, bool isConditionSetToTrue)
    {
        bool isRecognized = false;
        HandPose realtimePose = null;
        HandPose handPose = null;

        if (handedness == Handedness.Right)
        {
            realtimePose = realtimeData.RightHandPose;
            handPose = handPose_R;
        }
        else
        {
            realtimePose = realtimeData.LeftHandPose;
            handPose = handPose_L;
        }


        if (HandPose.IsEqual(handPose, realtimePose) == isConditionSetToTrue)
        {
            if(isTransformConstraint == false) isRecognized = true;
            else
            {
                if (HandPose.isTransformEqual(handPose, realtimePose) == isConditionSetToTrue) isRecognized = true;
                else isRecognized = false;
            }
        }
        else isRecognized = false;

        return isRecognized;
    }
}
