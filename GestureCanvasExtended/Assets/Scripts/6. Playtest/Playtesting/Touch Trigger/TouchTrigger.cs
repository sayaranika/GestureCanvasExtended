using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TouchTrigger : MonoBehaviour
{
    public Interaction interaction;
    public PlaytestingManager playtestManager;
    public PoseRecognizer poseRecognizer;
    [SerializeField] TouchRadar touchRadar;

    private void Update()
    {
        if (interaction.isConditionSetToTrue == true && touchRadar.TriggerObjectsList.Count > 0)
        {
            bool isRecognized = true;
            foreach (string s in interaction.TouchPoints_L)
            {
                if (s == "Index")
                {
                    if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_index")))
                    {
                        isRecognized = false;
                        break;
                    }
                }
                else if (s == "Middle")
                {
                    if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_middle")))
                    {
                        isRecognized = false;
                        break;
                    }
                }
                if (s == "Ring")
                {
                    if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_ring")))
                    {
                        isRecognized = false;
                        break;
                    }
                }
                if (s == "Pinky")
                {
                    if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_pinky")))
                    {
                        isRecognized = false;
                        break;
                    }
                }
                if (s == "Thumb")
                {
                    if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_thumb")))
                    {
                        isRecognized = false;
                        break;
                    }
                }
            }
            if (isRecognized == true)
            {
                foreach (string s in interaction.TouchPoints_R)
                {

                    if (s == "Index")
                    {
                        if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_index")))
                        {
                            isRecognized = false;
                            break;
                        }
                    }
                    else if (s == "Middle")
                    {
                        if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_middle")))
                        {
                            isRecognized = false;
                            break;
                        }
                    }
                    if (s == "Ring")
                    {
                        if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_ring")))
                        {
                            isRecognized = false;
                            break;
                        }
                    }
                    if (s == "Pinky")
                    {
                        if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_pinky")))
                        {
                            isRecognized = false;
                            break;
                        }
                    }
                    if (s == "Thumb")
                    {
                        if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_thumb")))
                        {
                            isRecognized = false;
                            break;
                        }
                    }

                }
            }
            if (isRecognized == true)
            {
                if (interaction.isPose_L == true || interaction.isPose_R == true)
                {
                    bool flag = false;

                    if (interaction.isPose_R == true && interaction.isPose_L == false)
                    {
                        flag = poseRecognizer.Recognize(Handedness.Right, interaction.expectedPose_R, null, interaction.isTransformConstraint_R, interaction.isConditionSetToTrue);
                    }
                    else if (interaction.isPose_R == false && interaction.isPose_L == true)
                    {
                        flag = poseRecognizer.Recognize(Handedness.Left, null, interaction.expectedPose_L, interaction.isTransformConstraint_L, interaction.isConditionSetToTrue);
                    }
                    else if (interaction.isPose_L == true && interaction.isPose_R == true)
                    {
                        flag = poseRecognizer.Recognize(Handedness.Right, interaction.expectedPose_R, null, interaction.isTransformConstraint_R, interaction.isConditionSetToTrue)
                                && poseRecognizer.Recognize(Handedness.Left, null, interaction.expectedPose_L, interaction.isTransformConstraint_L, interaction.isConditionSetToTrue);
                    }
                    if (isRecognized == true)
                    {
                        playtestManager.Load(interaction.transitionClip);
                    }
                }
                else
                {
                    playtestManager.Load(interaction.transitionClip);
                }
                playtestManager.Load(interaction.transitionClip);
            }
        }

        else if (interaction.isConditionSetToTrue == false)
        {
            if (touchRadar.TriggerObjectsList.Count == 0)
            {
                //true transition to next clip after checking for additional conditions
                playtestManager.Load(interaction.transitionClip);
            }
            else
            {
                bool isRecognized = true;
                foreach (string s in interaction.TouchPoints_L)
                {
                    if (s == "Index")
                    {
                        if (touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_index")))
                        {
                            isRecognized = false;
                            break;
                        }
                    }
                    else if (s == "Middle")
                    {
                        if (touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_middle")))
                        {
                            isRecognized = false;
                            break;
                        }
                    }
                    if (s == "Ring")
                    {
                        if (touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_ring")))
                        {
                            isRecognized = false;
                            break;
                        }
                    }
                    if (s == "Pinky")
                    {
                        if (touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_pinky")))
                        {
                            isRecognized = false;
                            break;
                        }
                    }
                    if (s == "Thumb")
                    {
                        if (touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_thumb")))
                        {
                            isRecognized = false;
                            break;
                        }
                    }


                }

                if (isRecognized == true)
                {
                    foreach (string s in interaction.TouchPoints_R)
                    {
                        if (s == "Index")
                        {
                            if (touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_index")))
                            {
                                isRecognized = false;
                                break;
                            }
                        }
                        else if (s == "Middle")
                        {
                            if (touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_middle")))
                            {
                                isRecognized = false;
                                break;
                            }
                        }
                        if (s == "Ring")
                        {
                            if (touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_ring")))
                            {
                                isRecognized = false;
                                break;
                            }
                        }
                        if (s == "Pinky")
                        {
                            if (touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_pinky")))
                            {
                                isRecognized = false;
                                break;
                            }
                        }
                        if (s == "Thumb")
                        {
                            if (touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_thumb")))
                            {
                                isRecognized = false;
                                break;
                            }
                        }

                    }
                }
                if (isRecognized == true)
                {
                    playtestManager.Load(interaction.transitionClip);
                }
            }
        }
    }
}

            
            
        
    
