using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaytestingManager : MonoBehaviour
{
    [SerializeField] Text msg;
    public static Clip currentClip = null;
    [SerializeField] GestureRecognizer gestureRecognizer;

    public static List<GameObject> Recognizers = new List<GameObject>();
    [SerializeField] AssetManager assetManager;
    [SerializeField] GameObject recognizerObject;
    [SerializeField] PoseRecognizer poseRecognizer;



    private void Awake()
    {
        GestureDataset.Load();
        gestureRecognizer.Train();
        msg.text = "Testing";
    }

    private void Update()
    {
        if (currentClip == null)
        {
            if(gestureRecognizer.trained_R == true && gestureRecognizer.trained_L == true && gestureRecognizer.trained_B == true)
                Load(ClipHandler.ClipList[0]);
        }
    }

    public void Load(Clip clip)
    {
        Debug.Log("4000A: Loading new clip");
        foreach (GameObject recognizerObject in Recognizers)
        {
            Object.Destroy(recognizerObject);
        }
        Recognizers.Clear();
        Debug.Log("4000B");

        currentClip = clip;
        Debug.Log("4000C: Clip ID: " + clip.Id);
        msg.text = "Clip ID: " + clip.Id;
        assetManager.LoadObjects();
        Debug.Log("4000D");

        foreach (Interaction i in clip.interactions)
        {
            Debug.Log("4000E");

            GameObject recognizer = Instantiate(recognizerObject);
            Recognizers.Add(recognizer);
            RecognitionManager recognizerManager = recognizer.GetComponent<RecognitionManager>();
            recognizerManager.interaction = i;
            recognizerManager.poseRecognizer = this.poseRecognizer;
            recognizerManager.playtestManager = this.gameObject.GetComponent<PlaytestingManager>();
            Debug.Log("4000F");

        }
    }


}
