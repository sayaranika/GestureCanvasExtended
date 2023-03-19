using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playback : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] ClipHandler clipHandler;
    [SerializeField] PlaybackStateHandler playbackStateHandler;
    [SerializeField] PlaybackObjectHandler playbackObjectHandler;
    public static bool isSceneLoaded { get; private set; }
    public static int frameCount { get; private set; }

    //////////////////////////   LOAD/REFRESH SCENE   //////////////////////////
    public void Initialize()
    {
        isSceneLoaded = false;

        if (MasterRecording.RightHandSkeleton.Count == MasterRecording.LeftHandSkeleton.Count &&
            MasterRecording.RightHandSkeleton.Count == MasterRecording.HMDMotion.Count &&
            MasterRecording.RightHandSkeleton.Count != 0 && MasterRecording.LeftHandSkeleton.Count != 0 && MasterRecording.HMDMotion.Count != 0)
        {
            frameCount = MasterRecording.RightHandSkeleton.Count;
            playbackObjectHandler.InstantiateReplayObject();
            clipHandler.Initialize();
            playbackStateHandler.Set(PlaybackState.InPlaybackState);

            isSceneLoaded = true;
        }
        else Debug.Log("Error 1000: Data Corrupted");
    }

    public void SetFrameCount(int count)
    {
        frameCount = count;
    }

    /////////////////////////////  PLAYBACK FUNCTIONS  /////////////////////////////
    public void Play()
    {
        playbackStateHandler.Set(PlaybackState.InPlaybackState);
    }

    public void Pause()
    {
        playbackStateHandler.Set(PlaybackState.InPauseState);
    }

    public void Stop()
    {
        playbackStateHandler.Set(PlaybackState.InStopState);
    }
}
