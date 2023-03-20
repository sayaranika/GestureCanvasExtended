using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLauncher : MonoBehaviour
{
    public void Launch(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void RestartRecording()
    {
        Manager.SystemInitialized = false;
        SceneManager.LoadScene("Record");
    }

    public void StartPlaytest()
    {
        PlaytestManager.currentClip = null;
        PlaytestManager.Recognizers.Clear();
        SceneManager.LoadScene("Playtest");
    }
}
