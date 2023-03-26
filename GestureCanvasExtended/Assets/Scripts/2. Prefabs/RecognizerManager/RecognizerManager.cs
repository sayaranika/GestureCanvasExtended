using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecognizerManager : MonoBehaviour
{
    public Interaction interaction;
    public PoseRecognizer poseRecognizer;
    public GestureRecognizer gestureRecognizer;
    public PlaytestManager playtestManager;



    private void Update()
    {
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

public class RecognizerResult
{
    public bool Pose_R;
    public bool Pose_L;
    public bool Gesture_R;
    public bool Gesture_L;
    public List<bool> Proximity = new List<bool>();

    RecognizerResult() { }
}
