using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTestManager : MonoBehaviour
{
    [SerializeField] PoseRecognizer poseRecognizer;
    [SerializeField] GestureRecognizer gestureRecognizer;
    [SerializeField] GestureRecognizerLoader gestureRecognizerLoader;

    [SerializeField] GameObject RightHandVisual;
    [SerializeField] GameObject LeftHandVisual;

    public static bool RunTest = false;
    //public static bool StopTest = false;
    public static Interaction interaction = null;

    public static bool loadDataset = false;
    public static void StartTest(Interaction i)
    {
        interaction = i;

        if (interaction.isGesture_R == true || interaction.isGesture_L == true)
        {
            loadDataset = true;
        }
        else RunTest = true;
    }

    private void Update()
    {
        if(loadDataset == true)
        {
            loadDataset = false;
            gestureRecognizerLoader.Initialize();
            if (interaction.isGesture_R == true)
            {
                gestureRecognizerLoader.Train(Handedness.Right);
            }
            if(interaction.isGesture_L == true)
            {
                gestureRecognizerLoader.Train(Handedness.Left);
            }

            RunTest = true;
        }
        if (RunTest == true && interaction != null)
        {
            bool isRecognized = false;
            bool isRightHandRecognized = false;
            bool isLeftHandRecognized = false;

            if (interaction.isPose_R == true && interaction.isPose_L == false)
            {
                isRecognized = poseRecognizer.Recognize(Handedness.Right, interaction.expectedPose_R, null, interaction.isTransformConstraint_R, interaction.isConditionSetToTrue);
                isRightHandRecognized = isRecognized;
            }
            if(interaction.isPose_L == true && interaction.isPose_R == false)
            {
                isRecognized = poseRecognizer.Recognize(Handedness.Left, null, interaction.expectedPose_L, interaction.isTransformConstraint_L, interaction.isConditionSetToTrue);
                isLeftHandRecognized = isRecognized;
            }
            if (interaction.isPose_L == true && interaction.isPose_R == true)
            {
                isRecognized = poseRecognizer.Recognize(Handedness.Right, interaction.expectedPose_R, null, interaction.isTransformConstraint_R, interaction.isConditionSetToTrue)
                    && poseRecognizer.Recognize(Handedness.Left, null, interaction.expectedPose_L, interaction.isTransformConstraint_L, interaction.isConditionSetToTrue);
                isRightHandRecognized = isRecognized;
                isLeftHandRecognized = isRecognized;
            }
            if(interaction.isGesture_R == true)
            {
                //isRecognized = gestureRecognizer.Recognize();
            }

            


            if (isRecognized == true)
            {
                if (isRightHandRecognized == true)
                    HighlightHand(RightHandVisual, true);
                else
                    HighlightHand(RightHandVisual, false);
                if (isLeftHandRecognized == true)
                    HighlightHand(LeftHandVisual, true);
                else
                    HighlightHand(LeftHandVisual, false);
            }
            else
            {
                HighlightHand(LeftHandVisual, false);
                HighlightHand(RightHandVisual, false);
            }

        }

        if(RunTest == false)
        {
            HighlightHand(LeftHandVisual, false);
            HighlightHand(RightHandVisual, false);
        }
    }

    public void HighlightHand(GameObject HandVisual, bool state)
    {
        HandVisual.GetComponent<HighlightPlus.HighlightEffect>().highlighted = state;
    }
}
