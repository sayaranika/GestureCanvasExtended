using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft;

public class ExportManager : MonoBehaviour
{
    public void Export()
    {
        Debug.Log("9000 A: Called");
        List<Root> root = new List<Root>();
        root.Add(new Root(ClipHandler.ClipList));
        FileHandler.SaveToJSON<Root>(root, "NewClipList.json");
        Debug.Log("9000 D: Called");
    }
}

[Serializable]
public class Root
{
    public List<Clip> clips = new List<Clip>();

    public Root(List<Clip> clips)
    {
        this.clips = clips;
    }
}


