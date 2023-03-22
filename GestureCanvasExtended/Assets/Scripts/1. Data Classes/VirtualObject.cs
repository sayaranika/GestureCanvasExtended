using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

[Serializable]
public class VirtualObject : MonoBehaviour
{
    public string objectName;
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale;

    public bool isAttached = false;
    public bool isAttachedToRight = false;
    public string AttachedBone = "";

     [JsonIgnore] public GameObject objectRef;
    //public List<CustomAnimation> animation;

    public VirtualObject(GameObject objectRef, string objectName, Vector3 Position, Quaternion Rotation, Vector3 Scale)
    {
        this.objectRef = objectRef;
        this.objectName = objectName;
        this.Position = Position;
        this.Rotation = Rotation;
        this.Scale = Scale;
        //this.animation = new List<CustomAnimation>();
    }
}
