using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTheFlyTest : MonoBehaviour
{
    [Header("Hand Objects")]
    [SerializeField] GameObject RightHandVisual;
    [SerializeField] GameObject LeftHandVisual;
    

    [Header("Recognizers")]
    [SerializeField] LeftGestureRecognizer gestureRecognizer_L;
    [SerializeField] RightGestureRecognizer gestureRecognizer_R;
    [SerializeField] PoseRecognizer poseRecognizer;

    public static bool RunTest = false;
    public static bool StopTest = false;
    public static Interaction interaction = null;

    public static void StartTest(Interaction i)
    {
        interaction = i;
        RunTest = true;
    }

    private void Update()
    {
        if (RunTest == true && interaction != null)
        {
            if (interaction.isPose_R == true)
            {
                bool isRecognized = poseRecognizer.Recognize(Handedness.Right, interaction.expectedPose_R, null, interaction.isTransformConstraint_R, interaction.isConditionSetToTrue);
                if (isRecognized == true) HighlightHand(RightHandVisual, true);
                else HighlightHand(RightHandVisual, false);
            }

            if (interaction.isPose_L == true)
            {
                bool isRecognized = poseRecognizer.Recognize(Handedness.Left, null, interaction.expectedPose_L, interaction.isTransformConstraint_L, interaction.isConditionSetToTrue);
                if (isRecognized == true) HighlightHand(LeftHandVisual, true);
                else HighlightHand(LeftHandVisual, false);
            }
            if (interaction.isGesture_R == true && gestureRecognizer_R.active == false)
            {
                gestureRecognizer_R.Initialize(interaction);
            }
            if (interaction.isGesture_L == true && gestureRecognizer_L.active == false)
            {
                gestureRecognizer_L.Initialize(interaction);
            }
        }


        if (StopTest == true)
        {
            //Stop all recognizers
            /*if (rightPoseRecognizer.isRightPoseRecoActive == true) rightPoseRecognizer.Stop();
            if (leftPoseRecognizer.isLeftPoseRecoActive == true) leftPoseRecognizer.Stop();*/
            if (gestureRecognizer_R.active == true) gestureRecognizer_R.Stop();
            /*if (gestureRecognizer_L.active == true) gestureRecognizer_L.Stop();
            if (gestureRecognizer_B.active == true) gestureRecognizer_B.Stop();*/
            interaction = null;
            StopTest = false;
        }
    }

    public void HighlightHand(GameObject HandVisual, bool state)
    {
        HandVisual.GetComponent<HighlightPlus.HighlightEffect>().highlighted = state;
    }


}
