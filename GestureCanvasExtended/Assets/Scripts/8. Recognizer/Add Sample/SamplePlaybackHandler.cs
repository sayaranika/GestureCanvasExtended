using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlaybackHandler : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] SamplePlayback playback;
    [SerializeField] PlaybackSlider playbackSlider;
    [SerializeField] SamplePlaybackObjectHandler playbackObjectHandler;

    public static int currentPlaybackIndex = 0;

    private void Start()
    {
        playback.Initialize();
    }

    private void LateUpdate()
    {
        if (SamplePlayback.isSceneLoaded)
        {
            int nextIndex;
            switch (PlaybackStateHandler.currentState)
            {
                case PlaybackState.InPauseState:
                    nextIndex = currentPlaybackIndex;
                    break;

                case PlaybackState.InStopState:
                    nextIndex = 0;
                    break;

                case PlaybackState.InPlaybackState:
                    nextIndex = currentPlaybackIndex + 1;
                    playbackSlider.setValue(currentPlaybackIndex, SamplePlayback.frameCount);
                    break;

                case PlaybackState.InSliderDragState:
                    nextIndex = (int)((playbackSlider.getValue() * SamplePlayback.frameCount) / 100.0f);
                    break;

                case PlaybackState.InEditingState:
                    nextIndex = currentPlaybackIndex;
                    break;

                default:
                    nextIndex = 0;
                    break;
            }
            if (nextIndex < SamplePlayback.frameCount)
            {
                playbackObjectHandler.SetReplayObjectTransform(nextIndex);
            }
            else
            {
                playbackObjectHandler.SetReplayObjectTransform(0);
            }
        }
    }
}
