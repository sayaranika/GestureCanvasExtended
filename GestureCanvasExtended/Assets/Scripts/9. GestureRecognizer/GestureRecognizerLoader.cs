using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureRecognizerLoader : MonoBehaviour
{
    public static bool isInitialized = false;

    public static bool trainingComplete_R = false;
    public static bool trainingComplete_L = false;

    public Jackknife jackknife_R;
    public Jackknife jackknife_L;

    public configuartion_parameters_t parameters;
    public void Initialize()
    {
        GestureDataset.Load();

        Debug.Log("5000 A: Clips and their expected gesture id");

        foreach(Clip clip in ClipHandler.ClipList)
        {
            foreach(Interaction i in clip.interactions)
            {
                if (i.isGesture_R == true)
                    Debug.Log("5000 A: Clip " + clip.Id + " Right Gesture ID: " + i.expectedGestureId_R);
                if(i.isGesture_L == true)
                    Debug.Log("5000 A: Clip " + clip.Id + " Left Gesture ID: " + i.expectedGestureId_L);

            }
        }
    }

    public void Train(Handedness handedness)
    {
        if (handedness == Handedness.Right)
        {
            StartCoroutine(StartTraining(GestureDataset.GestureDataset_R, jackknife_R, handedness));
        }
        if(handedness == Handedness.Left) StartCoroutine(StartTraining(GestureDataset.GestureDataset_L, jackknife_L, handedness));

    }

    IEnumerator StartTraining(Dataset dataset, Jackknife jackknife, Handedness handedness)
    {
        JackknifeBlades blades = new JackknifeBlades();
        blades.SetIPDefaults();
        jackknife = new Jackknife(blades);

        

        foreach (int gesture in dataset.Gestures)
        {
            Debug.Log("400: Gesture Id is: " + gesture);
            List<Sample> sampleList = dataset.SamplesByGesture[gesture];

            foreach (Sample sample in sampleList)
            {
                Debug.Log("400: Sample Gesture " + sample.GestureId);
                jackknife.AddTemplate(sample);
            }
        }

        parameters = new configuartion_parameters_t(2);
        // We originally used n=4, r=2 for Kinect data
        // and n=6, r=2 for Leap Motion data, but
        // here we just set the average. There is barely
        // any effect on the results.
        Debug.Log("400: Training Starting");
        jackknife.Train(6, 2, 1.00);
        Debug.Log("400: Training Complete");

        if (handedness == Handedness.Right)
        {
            trainingComplete_R = true;
            ClipHandler.ClipList[0].GestureRecognizer_R = jackknife;

        }

        if (handedness == Handedness.Left)
        {
            trainingComplete_L = true;
            ClipHandler.ClipList[0].GestureRecognizer_L = jackknife;
        }
        yield return null;
    }
}
