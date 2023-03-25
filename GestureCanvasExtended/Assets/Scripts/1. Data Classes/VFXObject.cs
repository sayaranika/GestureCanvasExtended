using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

[Serializable]
public class VFXObject 
{
    public string objectName;
    public Vector3 Position;
    public Quaternion Rotation;

    public bool isAttached = false;
    public bool isAttachedToRight = false;
    public string AttachedBone = "";

    [JsonIgnore] public GameObject vfxRef;

    public VFXObject(GameObject vfxRef, string objectName, Vector3 Position, Quaternion Rotation)
    {
        this.vfxRef = vfxRef;
        this.objectName = objectName;
        this.Position = Position;
        this.Rotation = Rotation;
    }
}
