using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarPlayback : MonoBehaviour
{
    public static int startFrame;
    public static int endFrame;
    public static Clip currentClip;
    public static GameObject currentClipButton;
    public static int currentFrame;
    public int totalFrames;

    [Header("UI")]
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject pauseButton;

    [Header("Script References")]
    [SerializeField] AvatarPlaybackSlider avatarPlaybackSlider;
    [SerializeField] AvatarManager avatarManager;

    public static PlaybackState currentState = PlaybackState.None;

    private void Start()
    {
        totalFrames = MasterRecording.RightHandSkeleton.Count;
        endFrame = totalFrames;
        startFrame = 0;
        currentFrame = 0;
    }

    private void LateUpdate()
    {
        if (Manager.SystemInitialized == true && Manager.ReloadSystem == false)
        {
            int nextIndex = startFrame;
            switch (currentState)
            {
                case PlaybackState.InPauseState:
                    nextIndex = currentFrame;
                    break;

                case PlaybackState.InPlaybackState:
                    nextIndex = currentFrame + 1;
                    avatarPlaybackSlider.setValue(currentFrame, totalFrames);
                    break;

                case PlaybackState.InSliderDragState:
                    nextIndex = (int)((avatarPlaybackSlider.getValue() * Playback.frameCount) / 100.0f);
                    if (nextIndex < startFrame)
                    {
                        nextIndex = startFrame;
                        avatarPlaybackSlider.setValue(startFrame, totalFrames);
                    }
                    else if (nextIndex >= endFrame)
                    {
                        nextIndex = endFrame - 1;
                        avatarPlaybackSlider.setValue(endFrame - 1, totalFrames);
                    }
                    break;

                case PlaybackState.InEditingState:
                    nextIndex = currentFrame;
                    break;

                default:
                    nextIndex = startFrame;
                    break;
            }

            if (nextIndex < endFrame) avatarManager.SetTransform(nextIndex);
            else avatarManager.SetTransform(startFrame);
        }
    }



    public void SetState(PlaybackState state)
    {
        currentState = state;

        switch (state)
        {
            case PlaybackState.InPlaybackState:
                ShowPause();
                break;
            case PlaybackState.InPauseState:
            case PlaybackState.InSliderDragState:
            case PlaybackState.InEditingState:
                ShowPlay();
                break;
        }
    }

    public void ShowPlay()
    {
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ShowPause()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void Play()
    {
        SetState(PlaybackState.InPlaybackState);
    }

    public void Pause()
    {
        SetState(PlaybackState.InPauseState);
    }
}
