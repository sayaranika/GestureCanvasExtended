using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarStateManager : MonoBehaviour
{
    [SerializeField] AvatarManager avatarManager;
    [SerializeField] GameObject Player;

    float Distance = 1000.0f;
    float RangeDistance = 0.5f;
    private void Update()
    {
        if (Manager.SystemInitialized == true && Manager.ReloadSystem == false)
        {
            //check if player is within collider
            Distance = Vector3.Distance(Player.transform.position, avatarManager.Avatar().transform.position);

            if (Distance < RangeDistance)
            {
                avatarManager.SetMode(AvatarState.Skeletal, Handedness.Both);
            }
            else
            {
                //if not within collider -> check whether to turn on highlight or solid
                avatarManager.SetMode(AvatarState.Default, Handedness.Both);

                Clip selectedClip = null;
                foreach (Clip clip in ClipHandler.ClipList)
                {
                    if (AvatarPlayback.currentFrame >= clip.startIndex && AvatarPlayback.currentFrame < clip.endIndex)
                    {
                        selectedClip = clip;
                        break;
                    }
                }

                if (selectedClip != null)
                {
                    //int ratio = (int)0.15f * (selectedClip.endIndex - selectedClip.startIndex);
                    foreach (Interaction i in selectedClip.interactions)
                    {
                        if (i.isGesture_R == true)
                        {
                            if (AvatarPlayback.currentFrame > selectedClip.endIndex - 15 && AvatarPlayback.currentFrame < selectedClip.endIndex)
                            {
                                avatarManager.SetMode(AvatarState.Highlighted, Handedness.Right);
                            }

                        }

                        if (i.isGesture_L == true)
                        {
                            if (AvatarPlayback.currentFrame > selectedClip.endIndex - 15 && AvatarPlayback.currentFrame < selectedClip.endIndex)
                            {
                                avatarManager.SetMode(AvatarState.Highlighted, Handedness.Left);
                            }

                        }

                        if (i.isPose_R == true)
                        {
                            bool highlight = false;

                            highlight = HandPose.IsEqual(i.expectedPose_R, MasterRecording.RightHandPose[AvatarPlayback.currentFrame]);
                            if (highlight == true)
                            {
                                if (i.isTransformConstraint_R == true)
                                {
                                    if (HandPose.isTransformEqual(i.expectedPose_R, MasterRecording.RightHandPose[AvatarPlayback.currentFrame]))
                                    {
                                        avatarManager.SetMode(AvatarState.Highlighted, Handedness.Right);
                                    }
                                }
                                else
                                {
                                    avatarManager.SetMode(AvatarState.Highlighted, Handedness.Right);
                                }

                            }

                        }

                        if (i.isPose_L == true)
                        {
                            bool highlight = false;

                            highlight = HandPose.IsEqual(i.expectedPose_L, MasterRecording.LeftHandPose[AvatarPlayback.currentFrame]);
                            if (highlight == true)
                            {
                                if (i.isTransformConstraint_L == true)
                                {
                                    if (HandPose.isTransformEqual(i.expectedPose_L, MasterRecording.LeftHandPose[AvatarPlayback.currentFrame]))
                                    {
                                        avatarManager.SetMode(AvatarState.Highlighted, Handedness.Left);
                                    }
                                }
                                else
                                {
                                    avatarManager.SetMode(AvatarState.Highlighted, Handedness.Left);
                                }

                            }

                        }
                    }
                }
            }
        }

    }
}
