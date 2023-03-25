/// <summary>
/// A class to hold one sample 
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Sample
{
    public int GestureId;
    public int ExampleId;

    public List<Vector> Trajectory;

    /**
     * Constructor that initializes all public variables,
     * except the trajectory. Use AddTrajectory for that.
     */
    public Sample(int gestureId, int exampleId)
    {
        GestureId = gestureId;
        ExampleId = exampleId;

        Trajectory = new List<Vector>();
    }

    /**
     * Multiple series are combined into a single trajectory.
     * In most cases this isn't relevant, but it may impact
     * multistroke gesture recognition, such as for hand
     * written pen or touch gestures. For those cases, you may
     * want to consider using Vatavu et al.'s $P recognizer.
     */
    public void AddTrajectory(List<Vector> trajectory)
    {
        for (int i = 0; i < trajectory.Count; i++)
            Trajectory.Add(trajectory[i].Clone() as Vector);
    }
}
