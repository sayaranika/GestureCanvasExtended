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

        Root entry = new Root(ClipHandler.ClipList);
        entry.GestureRecognizer_R = ClipHandler.ClipList[0].GestureRecognizer_R;
        entry.GestureRecognizer_L = ClipHandler.ClipList[0].GestureRecognizer_L;

        root.Add(entry);
        FileHandler.SaveToJSON<Root>(root, "final.json");
        Debug.Log("9000 D: Called");
    }
}

[Serializable]
public class Root
{
    public List<Clip> clips = new List<Clip>();
    public Jackknife GestureRecognizer_R;
    public Jackknife GestureRecognizer_L;


    public Root(List<Clip> clips)
    {
        this.clips = clips;
    }
}


