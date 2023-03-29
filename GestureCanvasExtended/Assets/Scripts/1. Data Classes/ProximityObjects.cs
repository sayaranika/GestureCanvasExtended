using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
[Serializable]
public class ProximityObject 
{
    //properties of Proximity GameObject to use when it is not attached to another GameObject
    public GameObject proximityRef;
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale;

    //if the Proximity GameObject is attached, make it the parent after setting the positional properties
    public string AttachedGameObjectName = "";
    [JsonIgnore] public GameObject AttachedGameObject;
    public AttachmentType attachmentType = AttachmentType.None;

    //check if the Proximity condition has been set
    public ProximityType ProximityConfigured = ProximityType.None;
    public ProximityType proximityType = ProximityType.Touch;

    //if proximity condition set to touch, contain it
    public List<string> TouchPoints_R = new List<string>();
    public List<string> TouchPoints_L = new List<string>();

    //list of ProximityVisualizers
    public List<GameObject> visualizers = new List<GameObject>();


    public ProximityObject(GameObject proximityRef, Vector3 Position, Quaternion Rotation, Vector3 Scale)
    {
        this.proximityRef = proximityRef;
        this.Position = Position;
        this.Rotation = Rotation;
        this.Scale = Scale;
    }

    public void Print()
    {
        Debug.Log("6000: Right Hand Touch Points: ");
        foreach (string item in TouchPoints_R)
        {
            Debug.Log("6000: " + item);
        }

        Debug.Log("6000: Left Hand Touch Points: ");
        foreach (string item in TouchPoints_L)
        {
            Debug.Log("6000: " + item);
        }
    }
}
