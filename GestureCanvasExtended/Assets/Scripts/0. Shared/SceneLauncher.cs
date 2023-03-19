using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLauncher : MonoBehaviour
{
    public void Launch
        (string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
