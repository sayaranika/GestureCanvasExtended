using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Dataset 
{
    public List<int> Gestures { get; set; }
    public List<Sample> Samples { get; set; }
    public List<List<Sample>> SamplesByGesture { get; set; }
    public Dataset()
    {
        Gestures = new List<int>();
        Samples = new List<Sample>();
        SamplesByGesture = new List<List<Sample>>();
    }

    /**
     * Add gesture name to database if it does not
     * already exist and returns its enumerated id.
     */
    public int AddGestureId()
    {
        int i = Gestures.Count;

        // push gesture id into list and make room for sample list in samples_by_gesture,
        // which will be populated later when add sample is called

        Gestures.Add(i);
        SamplesByGesture.Add(new List<Sample>());
        return i;
    }

    //Add a new sample to the dataset. The gesture name  must have already been added.
    public void AddSample(Sample sample, int gesture_id)
    {
        Samples.Add(sample);
        SamplesByGesture[gesture_id].Add(sample);
    }

    public static Sample LoadSampleFile(int gesture_id, int example_id, List<HandSkeleton> dataList)
    {
        Sample ret;
        ret = new Sample(gesture_id, example_id);

        List<double> pt = new List<double>();
        List<Vector> points = new List<Vector>();

        int end = dataList.Count - 1;

        for (int i = 0; i < end; i++)
        {
            pt.Add(dataList[i].HandPosition.x);
            pt.Add(dataList[i].HandPosition.y);
            pt.Add(dataList[i].HandPosition.z);

            pt.Add(dataList[i].WristPosition.x);
            pt.Add(dataList[i].WristPosition.y);
            pt.Add(dataList[i].WristPosition.z);

            pt.Add(dataList[i].ForearmStubPosition.x);
            pt.Add(dataList[i].ForearmStubPosition.y);
            pt.Add(dataList[i].ForearmStubPosition.z);

            pt.Add(dataList[i].Index1Position.x);
            pt.Add(dataList[i].Index1Position.y);
            pt.Add(dataList[i].Index1Position.z);

            pt.Add(dataList[i].Index2Position.x);
            pt.Add(dataList[i].Index2Position.y);
            pt.Add(dataList[i].Index2Position.z);

            pt.Add(dataList[i].Index3Position.x);
            pt.Add(dataList[i].Index3Position.y);
            pt.Add(dataList[i].Index3Position.z);

            pt.Add(dataList[i].Thumb0Position.x);
            pt.Add(dataList[i].Thumb0Position.y);
            pt.Add(dataList[i].Thumb0Position.z);

            pt.Add(dataList[i].Thumb1Position.x);
            pt.Add(dataList[i].Thumb1Position.y);
            pt.Add(dataList[i].Thumb1Position.z);

            pt.Add(dataList[i].Thumb2Position.x);
            pt.Add(dataList[i].Thumb2Position.y);
            pt.Add(dataList[i].Thumb2Position.z);

            pt.Add(dataList[i].Thumb3Position.x);
            pt.Add(dataList[i].Thumb3Position.y);
            pt.Add(dataList[i].Thumb3Position.z);

            pt.Add(dataList[i].Middle1Position.x);
            pt.Add(dataList[i].Middle1Position.y);
            pt.Add(dataList[i].Middle1Position.z);

            pt.Add(dataList[i].Middle2Position.x);
            pt.Add(dataList[i].Middle2Position.y);
            pt.Add(dataList[i].Middle2Position.z);

            pt.Add(dataList[i].Middle3Position.x);
            pt.Add(dataList[i].Middle3Position.y);
            pt.Add(dataList[i].Middle3Position.z);

            pt.Add(dataList[i].Ring1Position.x);
            pt.Add(dataList[i].Ring1Position.y);
            pt.Add(dataList[i].Ring1Position.z);

            pt.Add(dataList[i].Ring2Position.x);
            pt.Add(dataList[i].Ring2Position.y);
            pt.Add(dataList[i].Ring2Position.z);

            pt.Add(dataList[i].Ring3Position.x);
            pt.Add(dataList[i].Ring3Position.y);
            pt.Add(dataList[i].Ring3Position.z);

            pt.Add(dataList[i].Pinky0Position.x);
            pt.Add(dataList[i].Pinky0Position.y);
            pt.Add(dataList[i].Pinky0Position.z);

            pt.Add(dataList[i].Pinky1Position.x);
            pt.Add(dataList[i].Pinky1Position.y);
            pt.Add(dataList[i].Pinky1Position.z);

            pt.Add(dataList[i].Pinky2Position.x);
            pt.Add(dataList[i].Pinky2Position.y);
            pt.Add(dataList[i].Pinky2Position.z);

            pt.Add(dataList[i].Pinky3Position.x);
            pt.Add(dataList[i].Pinky3Position.y);
            pt.Add(dataList[i].Pinky3Position.z);



            points.Add(new Vector(pt));

            pt.Clear();
        }

        ret.AddTrajectory(points);

        return ret;
    }
    public static Sample LoadSampleFile(int gesture_id, int example_id, int start, int end, List<HandSkeleton> dataList)
    {
        Sample ret;
        ret = new Sample(gesture_id, example_id);

        List<double> pt = new List<double>();
        List<Vector> points = new List<Vector>();

        for (int i = start; i < end; i++)
        {
            pt.Add(dataList[i].HandPosition.x);
            pt.Add(dataList[i].HandPosition.y);
            pt.Add(dataList[i].HandPosition.z);

            pt.Add(dataList[i].WristPosition.x);
            pt.Add(dataList[i].WristPosition.y);
            pt.Add(dataList[i].WristPosition.z);
                               
            pt.Add(dataList[i].ForearmStubPosition.x);
            pt.Add(dataList[i].ForearmStubPosition.y);
            pt.Add(dataList[i].ForearmStubPosition.z);
                               
            pt.Add(dataList[i].Index1Position.x);
            pt.Add(dataList[i].Index1Position.y);
            pt.Add(dataList[i].Index1Position.z);
                               
            pt.Add(dataList[i].Index2Position.x);
            pt.Add(dataList[i].Index2Position.y);
            pt.Add(dataList[i].Index2Position.z);
                               
            pt.Add(dataList[i].Index3Position.x);
            pt.Add(dataList[i].Index3Position.y);
            pt.Add(dataList[i].Index3Position.z);
                               
            pt.Add(dataList[i].Thumb0Position.x);
            pt.Add(dataList[i].Thumb0Position.y);
            pt.Add(dataList[i].Thumb0Position.z);
                               
            pt.Add(dataList[i].Thumb1Position.x);
            pt.Add(dataList[i].Thumb1Position.y);
            pt.Add(dataList[i].Thumb1Position.z);
                               
            pt.Add(dataList[i].Thumb2Position.x);
            pt.Add(dataList[i].Thumb2Position.y);
            pt.Add(dataList[i].Thumb2Position.z);
                               
            pt.Add(dataList[i].Thumb3Position.x);
            pt.Add(dataList[i].Thumb3Position.y);
            pt.Add(dataList[i].Thumb3Position.z);
                               
            pt.Add(dataList[i].Middle1Position.x);
            pt.Add(dataList[i].Middle1Position.y);
            pt.Add(dataList[i].Middle1Position.z);
                               
            pt.Add(dataList[i].Middle2Position.x);
            pt.Add(dataList[i].Middle2Position.y);
            pt.Add(dataList[i].Middle2Position.z);
                               
            pt.Add(dataList[i].Middle3Position.x);
            pt.Add(dataList[i].Middle3Position.y);
            pt.Add(dataList[i].Middle3Position.z);
                               
            pt.Add(dataList[i].Ring1Position.x);
            pt.Add(dataList[i].Ring1Position.y);
            pt.Add(dataList[i].Ring1Position.z);
                               
            pt.Add(dataList[i].Ring2Position.x);
            pt.Add(dataList[i].Ring2Position.y);
            pt.Add(dataList[i].Ring2Position.z);
                               
            pt.Add(dataList[i].Ring3Position.x);
            pt.Add(dataList[i].Ring3Position.y);
            pt.Add(dataList[i].Ring3Position.z);
                               
            pt.Add(dataList[i].Pinky0Position.x);
            pt.Add(dataList[i].Pinky0Position.y);
            pt.Add(dataList[i].Pinky0Position.z);
                               
            pt.Add(dataList[i].Pinky1Position.x);
            pt.Add(dataList[i].Pinky1Position.y);
            pt.Add(dataList[i].Pinky1Position.z);
                               
            pt.Add(dataList[i].Pinky2Position.x);
            pt.Add(dataList[i].Pinky2Position.y);
            pt.Add(dataList[i].Pinky2Position.z);
                               
            pt.Add(dataList[i].Pinky3Position.x);
            pt.Add(dataList[i].Pinky3Position.y);
            pt.Add(dataList[i].Pinky3Position.z);



            points.Add(new Vector(pt));

            pt.Clear();
        }

        ret.AddTrajectory(points);

        return ret;
    }

    public static Sample LoadSampleFile(int gesture_id, int example_id, int start, int end, List<HandSkeleton> dataList_R, List<HandSkeleton> dataList_L)
    {
        Sample ret;
        ret = new Sample(gesture_id, example_id);

        List<double> pt = new List<double>();
        List<Vector> points = new List<Vector>();

        for (int i = start; i < end; i++)
        {
            pt.Add(dataList_R[i].HandPosition.x);
            pt.Add(dataList_R[i].HandPosition.y);
            pt.Add(dataList_R[i].HandPosition.z);
            pt.Add(dataList_R[i].WristPosition.x);
            pt.Add(dataList_R[i].WristPosition.y);
            pt.Add(dataList_R[i].WristPosition.z);
            pt.Add(dataList_R[i].ForearmStubPosition.x);
            pt.Add(dataList_R[i].ForearmStubPosition.y);
            pt.Add(dataList_R[i].ForearmStubPosition.z);
            pt.Add(dataList_R[i].Index1Position.x);
            pt.Add(dataList_R[i].Index1Position.y);
            pt.Add(dataList_R[i].Index1Position.z);
            pt.Add(dataList_R[i].Index2Position.x);
            pt.Add(dataList_R[i].Index2Position.y);
            pt.Add(dataList_R[i].Index2Position.z);
            pt.Add(dataList_R[i].Index3Position.x);
            pt.Add(dataList_R[i].Index3Position.y);
            pt.Add(dataList_R[i].Index3Position.z);
            pt.Add(dataList_R[i].Thumb0Position.x);
            pt.Add(dataList_R[i].Thumb0Position.y);
            pt.Add(dataList_R[i].Thumb0Position.z);
            pt.Add(dataList_R[i].Thumb1Position.x);
            pt.Add(dataList_R[i].Thumb1Position.y);
            pt.Add(dataList_R[i].Thumb1Position.z);
            pt.Add(dataList_R[i].Thumb2Position.x);
            pt.Add(dataList_R[i].Thumb2Position.y);
            pt.Add(dataList_R[i].Thumb2Position.z);
            pt.Add(dataList_R[i].Thumb3Position.x);
            pt.Add(dataList_R[i].Thumb3Position.y);
            pt.Add(dataList_R[i].Thumb3Position.z);
            pt.Add(dataList_R[i].Middle1Position.x);
            pt.Add(dataList_R[i].Middle1Position.y);
            pt.Add(dataList_R[i].Middle1Position.z);
            pt.Add(dataList_R[i].Middle2Position.x);
            pt.Add(dataList_R[i].Middle2Position.y);
            pt.Add(dataList_R[i].Middle2Position.z);
            pt.Add(dataList_R[i].Middle3Position.x);
            pt.Add(dataList_R[i].Middle3Position.y);
            pt.Add(dataList_R[i].Middle3Position.z);
            pt.Add(dataList_R[i].Ring1Position.x);
            pt.Add(dataList_R[i].Ring1Position.y);
            pt.Add(dataList_R[i].Ring1Position.z);
            pt.Add(dataList_R[i].Ring2Position.x);
            pt.Add(dataList_R[i].Ring2Position.y);
            pt.Add(dataList_R[i].Ring2Position.z);
            pt.Add(dataList_R[i].Ring3Position.x);
            pt.Add(dataList_R[i].Ring3Position.y);
            pt.Add(dataList_R[i].Ring3Position.z);
            pt.Add(dataList_R[i].Pinky0Position.x);
            pt.Add(dataList_R[i].Pinky0Position.y);
            pt.Add(dataList_R[i].Pinky0Position.z);
            pt.Add(dataList_R[i].Pinky1Position.x);
            pt.Add(dataList_R[i].Pinky1Position.y);
            pt.Add(dataList_R[i].Pinky1Position.z);
            pt.Add(dataList_R[i].Pinky2Position.x);
            pt.Add(dataList_R[i].Pinky2Position.y);
            pt.Add(dataList_R[i].Pinky2Position.z);
            pt.Add(dataList_R[i].Pinky3Position.x);
            pt.Add(dataList_R[i].Pinky3Position.y);
            pt.Add(dataList_R[i].Pinky3Position.z);

            pt.Add(dataList_L[i].HandPosition.x);
            pt.Add(dataList_L[i].HandPosition.y);
            pt.Add(dataList_L[i].HandPosition.z);
            pt.Add(dataList_L[i].WristPosition.x);
            pt.Add(dataList_L[i].WristPosition.y);
            pt.Add(dataList_L[i].WristPosition.z);
            pt.Add(dataList_L[i].ForearmStubPosition.x);
            pt.Add(dataList_L[i].ForearmStubPosition.y);
            pt.Add(dataList_L[i].ForearmStubPosition.z);
            pt.Add(dataList_L[i].Index1Position.x);
            pt.Add(dataList_L[i].Index1Position.y);
            pt.Add(dataList_L[i].Index1Position.z);
            pt.Add(dataList_L[i].Index2Position.x);
            pt.Add(dataList_L[i].Index2Position.y);
            pt.Add(dataList_L[i].Index2Position.z);
            pt.Add(dataList_L[i].Index3Position.x);
            pt.Add(dataList_L[i].Index3Position.y);
            pt.Add(dataList_L[i].Index3Position.z);
            pt.Add(dataList_L[i].Thumb0Position.x);
            pt.Add(dataList_L[i].Thumb0Position.y);
            pt.Add(dataList_L[i].Thumb0Position.z);
            pt.Add(dataList_L[i].Thumb1Position.x);
            pt.Add(dataList_L[i].Thumb1Position.y);
            pt.Add(dataList_L[i].Thumb1Position.z);
            pt.Add(dataList_L[i].Thumb2Position.x);
            pt.Add(dataList_L[i].Thumb2Position.y);
            pt.Add(dataList_L[i].Thumb2Position.z);
            pt.Add(dataList_L[i].Thumb3Position.x);
            pt.Add(dataList_L[i].Thumb3Position.y);
            pt.Add(dataList_L[i].Thumb3Position.z);
            pt.Add(dataList_L[i].Middle1Position.x);
            pt.Add(dataList_L[i].Middle1Position.y);
            pt.Add(dataList_L[i].Middle1Position.z);
            pt.Add(dataList_L[i].Middle2Position.x);
            pt.Add(dataList_L[i].Middle2Position.y);
            pt.Add(dataList_L[i].Middle2Position.z);
            pt.Add(dataList_L[i].Middle3Position.x);
            pt.Add(dataList_L[i].Middle3Position.y);
            pt.Add(dataList_L[i].Middle3Position.z);
            pt.Add(dataList_L[i].Ring1Position.x);
            pt.Add(dataList_L[i].Ring1Position.y);
            pt.Add(dataList_L[i].Ring1Position.z);
            pt.Add(dataList_L[i].Ring2Position.x);
            pt.Add(dataList_L[i].Ring2Position.y);
            pt.Add(dataList_L[i].Ring2Position.z);
            pt.Add(dataList_L[i].Ring3Position.x);
            pt.Add(dataList_L[i].Ring3Position.y);
            pt.Add(dataList_L[i].Ring3Position.z);
            pt.Add(dataList_L[i].Pinky0Position.x);
            pt.Add(dataList_L[i].Pinky0Position.y);
            pt.Add(dataList_L[i].Pinky0Position.z);
            pt.Add(dataList_L[i].Pinky1Position.x);
            pt.Add(dataList_L[i].Pinky1Position.y);
            pt.Add(dataList_L[i].Pinky1Position.z);
            pt.Add(dataList_L[i].Pinky2Position.x);
            pt.Add(dataList_L[i].Pinky2Position.y);
            pt.Add(dataList_L[i].Pinky2Position.z);
            pt.Add(dataList_L[i].Pinky3Position.x);
            pt.Add(dataList_L[i].Pinky3Position.y);
            pt.Add(dataList_L[i].Pinky3Position.z);



            points.Add(new Vector(pt));

            pt.Clear();
        }

        ret.AddTrajectory(points);

        return ret;
    }

    public static int LoadGestureEntry(Dataset dataset, int start, int end, List<HandSkeleton> dataList)
    {
        if (dataset == null)
        {
            dataset = new Dataset();
        }

        int gestureId = dataset.AddGestureId();
        //eventually when the system has more than one sample per gesture, loop through each sample and load them
        //for now I am just loading the single sample per sample;
        Sample sample = LoadSampleFile(gestureId, 0, start, end, dataList);
        dataset.AddSample(sample, gestureId);

        //return dataset;

        return gestureId;
    }

    /*public static int LoadGesture()
    {

    }*/

    public static int LoadGestureEntry(Dataset dataset, int start, int end, List<HandSkeleton> dataList_R, List<HandSkeleton> dataList_L)
    {
        if (dataset == null)
        {
            dataset = new Dataset();
        }

        int gestureId = dataset.AddGestureId();
        
        Sample sample = LoadSampleFile(gestureId, 0, start, end, dataList_R, dataList_L);
        dataset.AddSample(sample, gestureId);

        //return dataset;
        return gestureId;
    }

    public void PrintDataset()
    {
        Debug.Log("500: Number of gestures " + Gestures.Count);
        Debug.Log("500: Gesture Ids are: ");
        foreach(int gesture in Gestures)
        {
            Debug.Log("500: gesture id: " + gesture);
        }

        Debug.Log("500: Number of samples " + Samples.Count);
        Debug.Log("500: Sample Ids are: ");
        foreach (Sample s in Samples)
        {
            Debug.Log("500: gesture id: " + s.GestureId + " example_id: " + s.ExampleId + " trajectory count: " + s.Trajectory.Count);
        }

        foreach(int gesture in Gestures)
        {
            Debug.Log("500: samples in gesture " + gesture + " is " + SamplesByGesture[gesture].Count);
        }
    }

    public void ClearDataset()
    {
        SamplesByGesture.Clear();
        Samples.Clear();
        Gestures.Clear();
    }

    public static int LoadGestureEntry(Dataset dataset, List<HandSkeleton> dataList)
    {
        if (dataset == null)
        {
            dataset = new Dataset();
        }

        int gestureId = dataset.AddGestureId();
        //eventually when the system has more than one sample per gesture, loop through each sample and load them
        //for now I am just loading the single sample per sample;
        Sample sample = LoadSampleFile(gestureId, 0, dataList);
        dataset.AddSample(sample, gestureId);

        //return dataset;

        return gestureId;
    }

    public static void LoadSample(Dataset dataset, int gesture_id, int example_id, List<HandSkeleton> dataList)
    {
        Sample sample = LoadSampleFile(gesture_id, example_id, dataList);
        dataset.AddSample(sample, gesture_id);
    }



}
