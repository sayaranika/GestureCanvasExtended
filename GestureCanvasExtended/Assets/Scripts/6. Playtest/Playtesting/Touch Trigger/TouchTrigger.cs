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
        Debug.Log("9000: Touch Trigger Active: ");
        if (interaction.isConditionSetToTrue == true && touchRadar.TriggerObjectsList.Count > 0)
        {
            Debug.Log("9000: Starting to check the condition: ");
            Debug.Log("9000: Points in trigger are: ");
            foreach (GameObject item in touchRadar.TriggerObjectsList)
            {
                Debug.Log("9000: " + item.name);
            }
            Debug.Log("9000: Points in TouchPoints_L: ");
            foreach (string item in interaction.TouchPoints_L)
            {
                Debug.Log("9000: " + item);
            }
            Debug.Log("9000: Points in TouchPoints_R: ");
            foreach (string item in interaction.TouchPoints_R)
            {
                Debug.Log("9000: " + item);
            }
            bool isRecognized = true;

            foreach (string s in interaction.TouchPoints_L)
            {
                Debug.Log("9000: s: " + s);
                if (s == "Index")
                {
                    Debug.Log("9000: index block");
                    if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_index")))
                    {
                        isRecognized = false;
                        Debug.Log("9000: did not found index in trigger");
                        break;
                    }
                }
                else if (s == "Middle")
                {
                    Debug.Log("9000: middle block");
                    if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_middle")))
                    {
                        isRecognized = false;
                        Debug.Log("9000: did not found middle in trigger");
                        break;
                    }
                }
                if (s == "Ring")
                {
                    Debug.Log("9000: ring block");
                    if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_ring")))
                    {
                        isRecognized = false;
                        Debug.Log("9000: did not found ring in trigger");
                        break;
                    }
                }
                if (s == "Pinky")
                {
                    Debug.Log("9000: pinky block");
                    if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_pinky")))
                    {
                        isRecognized = false;
                        Debug.Log("9000: did not found pinky in trigger");
                        break;
                    }
                }
                if (s == "Thumb")
                {
                    Debug.Log("9000: thumb block");
                    if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_l_thumb")))
                    {
                        isRecognized = false;
                        Debug.Log("9000: did not found thumb in trigger");
                        break;
                    }
                }

            }

            Debug.Log("9000: outside isRecognized value is: " + isRecognized);

            if (isRecognized == true)
            {
                Debug.Log("9000: inside because is Recognized is true: and will check for TouchPoints_R" + isRecognized);

                foreach (string s in interaction.TouchPoints_R)
                {
                    Debug.Log("9000: s" + s);

                    if (s == "Index")
                    {
                        Debug.Log("9000: inside index block");

                        if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_index")))
                        {
                            Debug.Log("9000: here because index is not in list");

                            isRecognized = false;
                            break;
                        }
                    }
                    else if (s == "Middle")
                    {
                        Debug.Log("9000: inside middle block");


                        if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_middle")))
                        {
                            Debug.Log("9000: here because middle is not in list");

                            isRecognized = false;
                            break;
                        }
                    }
                    if (s == "Ring")
                    {
                        Debug.Log("9000: inside ring block");

                        if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_ring")))
                        {
                            Debug.Log("9000: here because ring is not in list");

                            isRecognized = false;
                            break;
                        }
                    }
                    if (s == "Pinky")
                    {
                        Debug.Log("9000: inside pinky block");

                        if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_pinky")))
                        {
                            Debug.Log("9000: here because pinky is not in list");

                            isRecognized = false;
                            break;
                        }
                    }
                    if (s == "Thumb")
                    {
                        Debug.Log("9000: inside thumb block");

                        if (!touchRadar.TriggerObjectsList.Any(item => item.name.StartsWith("b_r_thumb")))
                        {
                            Debug.Log("9000: here because thumb is not in list");

                            isRecognized = false;
                            break;
                        }
                    }

                }
            }
            Debug.Log("9000: outside isRecognized value is: " + isRecognized);

            if (isRecognized == true)
            {
                //check for additional conditions and then transition to transition clip
                Debug.Log("9000: condition is true. Points are in trigger");

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
            Debug.Log("9000: done");

        }
    }
}
        /*else if(interaction.isConditionSetToTrue == false)
        {
            if(touchRadar.TriggerObjectsList.Count == 0)
            {
                //true transition to next clip after checking for additional conditions

                Debug.Log("");
            }
            else
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
                    //check for additional conditions and then transition to transition clip
                }
            }


        }
    }
}
*/