using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackHandler : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] Playback playback;
    [SerializeField] PlaybackSlider playbackSlider;
    [SerializeField] PlaybackObjectHandler playbackObjectHandler;
    
    public static int currentPlaybackIndex = 0;
    private void Start()
    {
        playback.Initialize();
    }


    private void LateUpdate()
    {
        if (Playback.isSceneLoaded)
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
                    playbackSlider.setValue(currentPlaybackIndex, Playback.frameCount);
                    break;

                case PlaybackState.InSliderDragState:
                    nextIndex = (int)((playbackSlider.getValue() * Playback.frameCount) / 100.0f);
                    break;

                case PlaybackState.InEditingState:
                    nextIndex = currentPlaybackIndex;
                    break;

                default:
                    nextIndex = 0;
                    break;
            }
            if (nextIndex < Playback.frameCount)
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
