using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackStateHandler : MonoBehaviour
{
    [Header("Playback UI")]
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject pauseButton;

    public static PlaybackState currentState = PlaybackState.None;
    public static PlaybackState previousState = PlaybackState.None;


    /////////////////////////////  SET PLAYBACK STATE  /////////////////////////////

    public void Set(PlaybackState state)
    {
        previousState = currentState;
        currentState = state;

        UpdateUI(state);
    }

    public void UpdateUI(PlaybackState state)
    {
        switch (state)
        {
            case PlaybackState.InPlaybackState:
                ShowPause();
                break;
            case PlaybackState.InPauseState:
            case PlaybackState.InStopState:
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
}
