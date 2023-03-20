using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

[Serializable]
public class Interaction
{
    public int Id;
    public Clip transitionClip;

    public bool isGesture_R;
    public bool isGesture_L;
    public bool isPose_R;
    public bool isPose_L;

    public HandPose expectedPose_R;
    public HandPose expectedPose_L;
    public bool isTransformConstraint_R;
    public bool isTransformConstraint_L;

    public List<HandSkeleton> expectedGesture_R = new List<HandSkeleton>();
    public List<HandSkeleton> expectedGesture_L = new List<HandSkeleton>();
    public List<HandSkeleton> expectedGesture = new List<HandSkeleton>();

    [JsonIgnore] public int rightHandGestureStartIndex;
    [JsonIgnore] public int leftHandGestureStartIndex;

    [JsonIgnore] public int rightHandGestureEndIndex;
    [JsonIgnore] public int leftHandGestureEndIndex;

    public bool isConditionSetToTrue;

    public Interaction(int interactionId)
    {
        this.Id = interactionId;

        isGesture_L = false;
        isGesture_R = false;
        isPose_L = false;
        isPose_R = false;
        isTransformConstraint_L = false;
        isTransformConstraint_R = false;
        transitionClip = null;
        isConditionSetToTrue = true;
    }

    public void setGesture(Handedness handedness, int startIndex, int endIndex)
    {
        switch (handedness)
        {
            case Handedness.Right:
                isGesture_R = true;
                isPose_R = false;

                rightHandGestureStartIndex = startIndex;
                rightHandGestureEndIndex = endIndex;

                expectedGesture_R.Clear();

                for(int i = rightHandGestureStartIndex; i < rightHandGestureEndIndex; i++)
                {
                    expectedGesture_R.Add(MasterRecording.RightHandSkeleton[i]);
                }
                break;
            case Handedness.Left:;
                isGesture_L = true;
                isPose_L = false;

                leftHandGestureStartIndex = startIndex;
                leftHandGestureEndIndex = endIndex;

                expectedGesture_L.Clear();

                for (int i = leftHandGestureStartIndex; i < leftHandGestureEndIndex; i++)
                {
                    expectedGesture_L.Add(MasterRecording.LeftHandSkeleton[i]);
                }
                break;
        }
    }

    public void setPose(Handedness handedness, HandPose handPose)
    {
        switch (handedness)
        {
            case Handedness.Right:
                isGesture_R = false;
                isPose_R = true;
                expectedPose_R = handPose;
                break;
            case Handedness.Left:
                isGesture_L = false;
                isPose_L = true;
                expectedPose_L = handPose;
                break;
        }
    }
}
