using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleClipHandler : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject sliderHandle;

    [Header("Script References")]
    [SerializeField] private SampleClipButtonHandler clipButtonHandler;
    [SerializeField] private SamplePlayback playback;
    [SerializeField] PlaybackSlider playbackSlider;
    [SerializeField] PlaybackStateHandler playbackStateHandler;

    public static List<Clip> ClipList { get; private set; }
    public static int clipId { get; private set; }

    public void Initialize()
    {
        ClipList = new List<Clip>();
        clipId = 0;

        slider.value = 0.0f;
        float buttonStartPos = sliderHandle.transform.position.x;
        slider.value = 100.0f;
        float buttonEndPos = sliderHandle.transform.position.x;

        AddToClipList(0, SampleRecording.RightHandSkeleton.Count - 1, buttonStartPos, buttonEndPos);

        //refresh Clip UI
        clipButtonHandler.RefreshClipButtons();
    }

    //////////////////////////   CLIP EDITING FUNCTIONS   //////////////////////////

    public int ClipCount()
    {
        return ClipList.Count;
    }

    private void AddToClipList(int clipStartIndex, int clipEndIndex, float buttonStartPos, float buttonEndPos)
    {
        Clip clip = new Clip(clipId, clipStartIndex, clipEndIndex);
        ClipList.Add(clip);

        ClipButton clipButton = new ClipButton(clip, buttonStartPos, buttonEndPos);
        SampleClipButtonHandler.ClipButtonList.Add(clipButton);

        clipId++;
    }

    private void RemoveFromClipList(Clip clip, ClipButton clipButton)
    {
        ClipList.Remove(clip);
        SampleClipButtonHandler.ClipButtonList.Remove(clipButton);
    }

    public void CutClip(int cutPoint, Vector3 sliderHandlePosition)
    {
        Clip clipToCut = null;
        ClipButton clipToCutButton = null;
        foreach (ClipButton clipButton in SampleClipButtonHandler.ClipButtonList)
        {
            if (cutPoint > clipButton.clip.startIndex && cutPoint < clipButton.clip.endIndex)
            {
                clipToCut = clipButton.clip;
                clipToCutButton = clipButton;
            }
        }

        if (clipToCut != null)
        {
            AddToClipList(clipToCut.startIndex, cutPoint, clipToCutButton.StartPosition, sliderHandlePosition.x);
            AddToClipList(cutPoint + 1, clipToCut.endIndex, sliderHandlePosition.x, clipToCutButton.EndPosition);
            RemoveFromClipList(clipToCut, clipToCutButton);

            ClipList.Sort((x, y) => x.startIndex.CompareTo(y.startIndex));
            SampleClipButtonHandler.ClipButtonList.Sort((x, y) => x.clip.startIndex.CompareTo(y.clip.startIndex));
        }
    }

    public void DeleteClip()
    {
        int clipIndex = 0;
        List<Clip> ClipsToRemove = new List<Clip>();
        List<ClipButton> ClipButtonsToRemove = new List<ClipButton>();

        for (int i = clipIndex; i < SampleClipButtonHandler.ClipButtonList.Count; i++)
        {
            ClipButton clipButton = SampleClipButtonHandler.ClipButtonList[i];
            Clip clip = clipButton.clip;
            if (clipButton.isToggleOn == true)
            {
                int framesDeleted = (clip.endIndex - clip.startIndex);
                SampleRecording.RightHandSkeleton.RemoveRange(clip.startIndex, framesDeleted);
                SampleRecording.LeftHandSkeleton.RemoveRange(clip.startIndex, framesDeleted);
                SampleRecording.RightHandMotion.RemoveRange(clip.startIndex, framesDeleted);
                SampleRecording.LeftHandMotion.RemoveRange(clip.startIndex, framesDeleted);
                SampleRecording.HMDMotion.RemoveRange(clip.startIndex, framesDeleted);
                SampleRecording.RightHandPose.RemoveRange(clip.startIndex, framesDeleted);
                SampleRecording.LeftHandPose.RemoveRange(clip.startIndex, framesDeleted);

                ClipButtonsToRemove.Add(clipButton);
                ClipsToRemove.Add(clip);

                for (int j = i + 1; j < SampleClipHandler.ClipList.Count; j++)
                {
                    SampleClipHandler.ClipList[j].startIndex = SampleClipHandler.ClipList[j].startIndex - framesDeleted;
                    SampleClipHandler.ClipList[j].endIndex = SampleClipHandler.ClipList[j].endIndex - framesDeleted;
                }
            }
        }

        foreach (ClipButton clipButton in SampleClipButtonHandler.ClipButtonList)
        {
            if (ClipsToRemove.Contains(clipButton.clip) == false)
            {
                playback.SetFrameCount(SampleRecording.RightHandSkeleton.Count);

                playbackSlider.setValue(clipButton.clip.startIndex, SampleRecording.RightHandSkeleton.Count);

                Vector3 sliderStartPosition = sliderHandle.transform.position;

                playbackSlider.setValue(clipButton.clip.endIndex, SampleRecording.RightHandSkeleton.Count);

                Vector3 sliderEndPosition = sliderHandle.transform.position;

                clipButton.setButtonPosition(sliderStartPosition.x, sliderEndPosition.x);
            }
        }


        foreach (Clip clip in ClipsToRemove)
        {
            ClipList.Remove(clip);
        }

        ClipsToRemove.Clear();

        foreach (ClipButton clipButton in ClipButtonsToRemove)
        {
            SampleClipButtonHandler.ClipButtonList.Remove(clipButton);
        }

        ClipButtonsToRemove.Clear();

        //update clip id;
        int id = 0;
        foreach (Clip clip in SampleClipHandler.ClipList)
        {
            clip.Id = id;
            id++;
        }

        playback.SetFrameCount(SampleRecording.RightHandSkeleton.Count);
    }


    public void Cut()
    {
        CutClip(SamplePlaybackHandler.currentPlaybackIndex, sliderHandle.transform.position);
        clipButtonHandler.RefreshClipButtons();
    }

    public void Delete()
    {
        playbackStateHandler.Set(PlaybackState.InEditingState);
        DeleteClip();
        clipButtonHandler.RefreshClipButtons();
        playbackStateHandler.Set(PlaybackState.InPlaybackState);
    }
}
