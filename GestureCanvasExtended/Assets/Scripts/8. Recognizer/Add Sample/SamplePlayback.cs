using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SamplePlayback : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] SampleClipHandler clipHandler;
    [SerializeField] PlaybackStateHandler playbackStateHandler;
    [SerializeField] SamplePlaybackObjectHandler playbackObjectHandler;
    public static bool isSceneLoaded { get; private set; }
    public static int frameCount { get; private set; }

    //////////////////////////   LOAD/REFRESH SCENE   //////////////////////////
    public void Initialize()
    {
        isSceneLoaded = false;

        if (SampleRecording.RightHandSkeleton.Count == SampleRecording.LeftHandSkeleton.Count &&
            SampleRecording.RightHandSkeleton.Count == SampleRecording.HMDMotion.Count &&
            SampleRecording.RightHandSkeleton.Count != 0 && SampleRecording.LeftHandSkeleton.Count != 0 && SampleRecording.HMDMotion.Count != 0)
        {
            frameCount = SampleRecording.RightHandSkeleton.Count;
            Debug.Log("2000: " + frameCount);
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

    public void Add()
    {
        Debug.Log("2000: Left Hand Count: " + SampleRecording.LeftHandSkeleton.Count);
        if(SampleRecording.interaction.isGesture_L == true)
        {
            SampleRecording.interaction.GestureSamples_L.Add(new GestureSamplesWrapper(SampleRecording.LeftHandSkeleton));
        }
        if (SampleRecording.interaction.isGesture_R == true)
        {
            SampleRecording.interaction.GestureSamples_R.Add(new GestureSamplesWrapper(SampleRecording.RightHandSkeleton));
        }

        Debug.Log("2000: samples in Gesture: " + SampleRecording.interaction.GestureSamples_R.Count);

        //SceneManager.LoadScene("RecordSample");
    }

    

    private void Start()
    {
        Debug.Log("2000: At start Left Hand Count: " + SampleRecording.LeftHandSkeleton.Count);

    }
}
