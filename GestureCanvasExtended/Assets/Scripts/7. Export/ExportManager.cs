using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportManager : MonoBehaviour
{
    public void Export()
    {
        FileHandler.SaveToJSON<Clip>(ClipHandler.ClipList, "ClipList.json");
    }
}
