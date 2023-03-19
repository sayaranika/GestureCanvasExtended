using System.Collections.Generic;
using UnityEngine;

public class Clip 
{
    public int Id;
    public int startIndex;
    public int endIndex;

    public Clip(int Id, int startIndex, int endIndex)
    {
        this.Id = Id;
        this.startIndex = startIndex;
        this.endIndex = endIndex;
    }
}
