using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractionInitializer : MonoBehaviour
{
    public void InitializeDefaultInteraction()
    {
        DataValidity();
        InferHandedness();
        SetUniqueHandConfig(MasterRecording.RightHandPose, Handedness.Right);
        SetUniqueHandConfig(MasterRecording.LeftHandPose, Handedness.Left);

        SetDefaultInteraction();
    }

    public void DataValidity()
    {
        bool dataValid_R = false;
        bool dataValid_L = false;

        foreach (Clip clip in ClipHandler.ClipList)
        {
            for (int i = clip.startIndex; i < clip.endIndex; i++)
            {
                if (MasterRecording.RightHandSkeleton[i].HandPosition != ClipValidity.INVALID) dataValid_R = true;
                if (MasterRecording.LeftHandSkeleton[i].HandPosition != ClipValidity.INVALID) dataValid_L = true;
            }

            ClipValidity clipValidity = new ClipValidity(clip, dataValid_R, dataValid_L);
            clip.clipValidity = clipValidity;

            dataValid_R = false;
            dataValid_L = false;
        }
    }

    #region HANDEDNESS
    public void InferHandedness()
    {
        int INVALID_THRESHOLD;
        foreach (Clip clip in ClipHandler.ClipList)
        {
            INVALID_THRESHOLD = (int)(0.8f * (clip.endIndex - clip.startIndex));  //if 80% of data is invalid, we declare that the condition is not set
            int totalInvalid_R = 0;
            int totalInvalid_L = 0;
            for (int i = clip.startIndex; i < clip.endIndex; i++)
            {
                if (MasterRecording.RightHandSkeleton[i].HandPosition == ClipValidity.INVALID) totalInvalid_R++;
                if (MasterRecording.LeftHandSkeleton[i].HandPosition == ClipValidity.INVALID) totalInvalid_L++;
            }

            if (totalInvalid_R >= INVALID_THRESHOLD) clip.clipValidity.isHandDataSet_R = false; else clip.clipValidity.isHandDataSet_R = true;

            if (totalInvalid_L >= INVALID_THRESHOLD) clip.clipValidity.isHandDataSet_L = false; else clip.clipValidity.isHandDataSet_L = true;
        }
    }
    #endregion

    #region SET UNIQUE HAND CONFIG
    /////////////////////////////////// POPULATE HAND CONFIGS IN A CLIP ////////////////////////////////
    private void SetUniqueHandConfig(List<HandPose> HandPoseRecording, Handedness handedness)
    {
        foreach (Clip clip in ClipHandler.ClipList)
        {
            for (int i = clip.startIndex; i < clip.endIndex - 1; i++)
            {
                if (HandPoseRecording[i].ParentConfigId == -1)
                {
                    for (int j = i + 1; j < clip.endIndex; j++)
                    {
                        if (HandPoseRecording[j].ParentConfigId == -1 && HandPose.IsEqual(HandPoseRecording[i], HandPoseRecording[j]))
                            HandPoseRecording[j].ParentConfigId = HandPoseRecording[i].HandPoseId;
                    }
                }
            }
        }

        ///setting the unique hand poses

        foreach (Clip clip in ClipHandler.ClipList)
        {
            for (int i = clip.startIndex; i < clip.endIndex; i++)
            {
                if (HandPoseRecording[i].ParentConfigId == -1)
                {
                    int count = 1;
                    for (int j = clip.startIndex; j < clip.endIndex; j++)
                    {
                        if (HandPoseRecording[i].HandPoseId == HandPoseRecording[j].ParentConfigId)
                            count++;
                    }

                    if (handedness == Handedness.Right)
                        clip.HandPoses_R.Add(new HandPoseInstance(HandPoseRecording[i], i, count));
                    else
                        clip.HandPoses_L.Add(new HandPoseInstance(HandPoseRecording[i], i, count));
                }
            }

        }
    }
    #endregion

    #region SET DEFAULT INTERACTION
    public void SetDefaultInteraction()
    {
        foreach (Clip clip in ClipHandler.ClipList)
        {
            Interaction interaction = new Interaction(1); // suggested interaction will have id 1
            if (clip.clipValidity.isDataValid_R == false && clip.clipValidity.isDataValid_L == false)
            {
                clip.interactions.Add(interaction);
                continue; //do not parse data
            }
            // RIGHT HAND
            if (clip.clipValidity.isHandDataSet_R == false)
            {
                interaction.isGesture_R = false;
                interaction.isPose_R = false;
            }
            else
            {
                if (clip.HandPoses_R.Count == 1)
                {
                    //check if there is translation. If yes then set it to gesture else pose
                    List<float> Distances = new List<float>();

                    for (int i = clip.startIndex; i < clip.endIndex; i++)
                        Distances.Add(Vector3.Distance(MasterRecording.RightHandSkeleton[clip.startIndex].HandPosition, MasterRecording.RightHandSkeleton[i].HandPosition));

                    if (Distances.Max(z => z) < 0.1f) interaction.setPose(Handedness.Right, clip.HandPoses_R[0].handPose);
                    else interaction.setGesture(Handedness.Right, clip.startIndex, clip.endIndex);
                    Distances.Clear();
                }
                else
                {
                    interaction.setGesture(Handedness.Right, clip.startIndex, clip.endIndex);
                }
            }
            // Left HAND
            if (clip.clipValidity.isHandDataSet_L == false)
            {
                interaction.isGesture_L = false;
                interaction.isPose_L = false;
            }
            else
            {
                if (clip.HandPoses_L.Count == 1)
                {
                    //check if there is translation. If yes then set it to gesture else pose
                    List<float> Distances = new List<float>();

                    for (int i = clip.startIndex; i < clip.endIndex; i++)
                        Distances.Add(Vector3.Distance(MasterRecording.LeftHandSkeleton[clip.startIndex].HandPosition, MasterRecording.LeftHandSkeleton[i].HandPosition));
                    if (Distances.Max(z => z) < 0.1f) interaction.setPose(Handedness.Left, clip.HandPoses_L[0].handPose);
                    else interaction.setGesture(Handedness.Left, clip.startIndex, clip.endIndex);

                    Distances.Clear();

                }
                else interaction.setGesture(Handedness.Left, clip.startIndex, clip.endIndex);
            }
        }
        //set transitions
        if (ClipHandler.ClipList.Count > 1)
        {
            for (int i = 0; i < ClipHandler.ClipList.Count - 1; i++)
            {
                if (ClipHandler.ClipList[i].interactions.Count == 1)
                {
                    ClipHandler.ClipList[i].interactions[0].transitionClip = ClipHandler.ClipList[i + 1];
                }
            }
            if (ClipHandler.ClipList[ClipHandler.ClipList.Count - 1].interactions.Count == 1)
            {
                ClipHandler.ClipList[ClipHandler.ClipList.Count - 1].interactions[0].transitionClip = ClipHandler.ClipList[0];
            }

        }
    }
    #endregion
}
