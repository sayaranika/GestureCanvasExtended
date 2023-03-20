using System.Collections.Generic;
using UnityEngine;

public class Clip 
{
    public int Id;
    public int startIndex;
    public int endIndex;
    public List<Interaction> interactions = new List<Interaction>();

    public List<HandPoseInstance> HandPoses_R = new List<HandPoseInstance>();
    public List<HandPoseInstance> HandPoses_L = new List<HandPoseInstance>();

    public ClipValidity clipValidity; //no need to ship with json
    public Interaction DefaultInteraction;

    public Clip(int Id, int startIndex, int endIndex)
    {
        this.Id = Id;
        this.startIndex = startIndex;
        this.endIndex = endIndex;
    }
}
