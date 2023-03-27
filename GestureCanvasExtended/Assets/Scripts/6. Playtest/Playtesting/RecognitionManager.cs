using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecognitionManager : MonoBehaviour
{
    public Interaction interaction;
    public PoseRecognizer poseRecognizer;
    public GestureRecognizer gestureRecognizer;
    public PlaytestingManager playtestManager;

    private void Update()
    {
        if (interaction.isGesture_R == true && interaction.isGesture_L == false)
        {
            Debug.Log("4000G");

            gestureRecognizer.Recognize(interaction, Handedness.Right, poseRecognizer, playtestManager);
            Debug.Log("4000H");

        }
        else if (interaction.isGesture_L == true && interaction.isGesture_R == false)
        {
            gestureRecognizer.Recognize(interaction, Handedness.Left, poseRecognizer, playtestManager);
        }
        else if (interaction.isGesture_L == true && interaction.isGesture_R == true)
        {
            gestureRecognizer.Recognize(interaction, Handedness.Both, poseRecognizer, playtestManager);
        }
        


        bool isRecognized = false;

        if (interaction.isPose_R == true && interaction.isPose_L == false)
        {
            isRecognized = poseRecognizer.Recognize(Handedness.Right, interaction.expectedPose_R, null, interaction.isTransformConstraint_R, interaction.isConditionSetToTrue);
        }
        else if (interaction.isPose_R == false && interaction.isPose_L == true)
        {
            isRecognized = poseRecognizer.Recognize(Handedness.Left, null, interaction.expectedPose_L, interaction.isTransformConstraint_L, interaction.isConditionSetToTrue);
        }
        else if (interaction.isPose_L == true && interaction.isPose_R == true)
        {
            isRecognized = poseRecognizer.Recognize(Handedness.Right, interaction.expectedPose_R, null, interaction.isTransformConstraint_R, interaction.isConditionSetToTrue)
                    && poseRecognizer.Recognize(Handedness.Left, null, interaction.expectedPose_L, interaction.isTransformConstraint_L, interaction.isConditionSetToTrue);
        }
        if (isRecognized == true)
        {
            playtestManager.Load(interaction.transitionClip);
        }
    }


}
