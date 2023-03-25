using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureDataset : MonoBehaviour
{
    public static Dataset GestureDataset_R = new Dataset();
    public static Dataset GestureDataset_L = new Dataset();
    public static void Load()
    {
        Debug.Log("500: Starting to load dataset" + GestureDataset_R.Gestures.Count + " " + GestureDataset_L.Gestures.Count);
        GestureDataset_R.ClearDataset();
        GestureDataset_L.ClearDataset();
        Debug.Log("500: Starting to load dataset" + GestureDataset_R.Gestures.Count + " " + GestureDataset_L.Gestures.Count);
        foreach (Clip clip in ClipHandler.ClipList)
        {
            foreach(Interaction i in clip.interactions)
            {
                if(i.isGesture_R == true)
                {
                    if(i.GestureSamples_R.Count > 0)
                    {
                        int Id = Dataset.LoadGestureEntry(GestureDataset_R, i.GestureSamples_R[0].sample);
                        if(i.GestureSamples_R.Count > 1)
                            for(int m = 1; m < i.GestureSamples_R.Count; m++)
                                Dataset.LoadSample(GestureDataset_R, Id, m, i.GestureSamples_R[m].sample);

                        i.expectedGestureId_R = Id;

                        Debug.Log("500: [Right] Expected Gesture Id for interaction " + i.Id + " from clip " + clip.Id + " : " + Id);
                    }
                    
                }


                if (i.isGesture_L == true)
                {
                    if (i.GestureSamples_L.Count > 0)
                    {
                        int Id = Dataset.LoadGestureEntry(GestureDataset_L, i.GestureSamples_L[0].sample);
                        if (i.GestureSamples_L.Count > 1)
                            for (int m = 1; m < i.GestureSamples_L.Count; m++)
                                Dataset.LoadSample(GestureDataset_L, Id, m, i.GestureSamples_L[m].sample);

                        i.expectedGestureId_L = Id;

                        Debug.Log("500: [Left] Expected Gesture Id for interaction " + i.Id + " from clip " + clip.Id + " : " + Id);
                    }

                }
            }
        }
        Debug.Log("Right Hand Dataset");
        GestureDataset_R.PrintDataset();

        Debug.Log("Left Hand Dataset");
        GestureDataset_L.PrintDataset();


    }






}
