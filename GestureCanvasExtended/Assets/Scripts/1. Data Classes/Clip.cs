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
    public List<VirtualObject> virtualObjects = new List<VirtualObject>();
    public List<VFXObject> vfxObjects = new List<VFXObject>();
    public List<ProximityObject> proximityObjects = new List<ProximityObject>();
    //[JsonIgnore] public List<GameObject> proximityGameObjects = new List<GameObject>();

    [JsonIgnore] public Jackknife GestureRecognizer_R;
    [JsonIgnore] public Jackknife GestureRecognizer_L;
    [JsonIgnore] public Jackknife GestureRecognizer_B;

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
