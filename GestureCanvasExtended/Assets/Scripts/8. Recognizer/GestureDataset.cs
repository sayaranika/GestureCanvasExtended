using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureDataset : MonoBehaviour
{
    public static Dataset GestureDataset_R = new Dataset();
    public static Dataset GestureDataset_L = new Dataset();
    public static Dataset GestureDataset_B = new Dataset();
    public static void Load()
    {
        GestureDataset_R.ClearDataset();
        GestureDataset_L.ClearDataset();
        foreach (Clip clip in ClipHandler.ClipList)
        {
            foreach(Interaction i in clip.interactions)
            {
                if(i.isGesture_R == true && i.isGesture_L == false)
                {
                    if(i.GestureSamples_R.Count > 0)
                    {
                        int Id = Dataset.LoadGestureEntry(GestureDataset_R, i.GestureSamples_R[0].sample);
                        if(i.GestureSamples_R.Count > 1)
                            for(int m = 1; m < i.GestureSamples_R.Count; m++)
                                Dataset.LoadSample(GestureDataset_R, Id, m, i.GestureSamples_R[m].sample);

                        i.expectedGestureId_R = Id;
                        i.GestureLength_R = clip.endIndex - clip.startIndex;
                    }
                }


                if (i.isGesture_L == true && i.isGesture_R == false)
                {
                    if (i.GestureSamples_L.Count > 0)
                    {
                        int Id = Dataset.LoadGestureEntry(GestureDataset_L, i.GestureSamples_L[0].sample);
                        if (i.GestureSamples_L.Count > 1)
                            for (int m = 1; m < i.GestureSamples_L.Count; m++)
                                Dataset.LoadSample(GestureDataset_L, Id, m, i.GestureSamples_L[m].sample);

                        i.expectedGestureId_L = Id;
                        i.GestureLength_L = clip.endIndex - clip.startIndex;
                    }
                }

                if (i.isGesture_L == true && i.isGesture_R == true)
                {
                    Debug.Log("900: Gesture Samples R: " + i.GestureSamples_R.Count + " L: " + i.GestureSamples_L.Count);
                    //if (i.GestureSamples_R.Count > 0 && i.GestureSamples_L.Count > 0 && i.GestureLength_R.c)
                    //{
                        int Id = Dataset.LoadGestureEntry(GestureDataset_B, i.GestureSamples_R[0].sample, i.GestureSamples_L[0].sample);
                        /*if (i.GestureSamples_B.Count > 1)
                        {
                            for (int m = 1; m < i.GestureSamples_B.Count; m++)
                            {
                                Dataset.LoadSample(GestureDataset_B, Id, m, i.GestureSamples_R[m].sample, i.GestureSamples_L[m].sample);
                            }
                        }*/
                        i.expectedGestureId_B = Id;
                        i.GestureLength_B = clip.endIndex - clip.startIndex;
                    //}
                    Debug.Log("900: done");
                }
            }
        }
        Debug.Log("Right Hand Dataset");
        GestureDataset_R.PrintDataset();

        Debug.Log("Left Hand Dataset");
        GestureDataset_L.PrintDataset();

        Debug.Log("Both Hand Dataset");
        GestureDataset_B.PrintDataset();


    }






}
