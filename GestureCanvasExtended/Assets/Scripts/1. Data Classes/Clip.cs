using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[SerializeField]
public class Clip
{
    public int Id;
    [JsonIgnore] public int startIndex;
    [JsonIgnore] public int endIndex;
    public List<Interaction> interactions = new List<Interaction>();

    [JsonIgnore] public List<HandPoseInstance> HandPoses_R = new List<HandPoseInstance>();
    [JsonIgnore] public List<HandPoseInstance> HandPoses_L = new List<HandPoseInstance>();

    [JsonIgnore] public ClipValidity clipValidity;
    [JsonIgnore] public Interaction DefaultInteraction;

    public Clip(int Id, int startIndex, int endIndex)
    {
        this.Id = Id;
        this.startIndex = startIndex;
        this.endIndex = endIndex;
    }
}
