using UnityEngine;
public class ClipValidity 
{
    public Clip clip;

    public static Vector3 INVALID = new Vector3(-1000.0f, -1000.0f, -1000.0f);

    public bool isDataValid_R; // false if none of the frames have any hand data.
    public bool isDataValid_L;
    public bool isHandDataSet_R; //false if hand condition is not set in default 
    public bool isHandDataSet_L;

    public ClipValidity(Clip clip, bool isDataValid_R, bool isDataValid_L)
    {
        this.clip = clip;
        this.isDataValid_L = isDataValid_L;
        this.isDataValid_R = isDataValid_R;
    }
}
