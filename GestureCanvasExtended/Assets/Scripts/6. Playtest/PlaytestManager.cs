using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaytestManager : MonoBehaviour
{
    [SerializeField] GameObject recognizerObject;
    [SerializeField] PoseRecognizer poseRecognizer;
    [SerializeField] AssetManager assetManager;
    [SerializeField] Text msg;
    public static Clip currentClip = null;

    public static List<GameObject> Recognizers = new List<GameObject>();

    private void Start()
    {
        msg.text = "Testing";
    }

    private void Update()
    {
        if(currentClip == null)
        {
            Load(ClipHandler.ClipList[0]);
        }
    }

    public void Load(Clip clip)
    {
        foreach(GameObject recognizerObject in Recognizers)
        {
            Object.Destroy(recognizerObject);
        }
        Recognizers.Clear();

        currentClip = clip;
        Debug.Log("4000: Clip ID: " + clip.Id);
        msg.text = "Clip ID: " + clip.Id;
        assetManager.LoadObjects();

        foreach (Interaction i in clip.interactions)
        {
            GameObject recognizer = Instantiate(recognizerObject);
            Recognizers.Add(recognizer);
            RecognizerManager recognizerManager = recognizer.GetComponent<RecognizerManager>();
            recognizerManager.interaction = i;
            recognizerManager.poseRecognizer = this.poseRecognizer;
            recognizerManager.playtestManager = this.gameObject.GetComponent<PlaytestManager>();
        }
    }
}
