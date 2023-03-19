using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipButton 
{
    public Clip clip;
    public float StartPosition;
    public float EndPosition;
    public bool isToggleOn;
    public GameObject button;

    public ClipButton(Clip clip, float StartPosition, float EndPosition)
    {
        this.clip = clip;
        this.StartPosition = StartPosition;
        this.EndPosition = EndPosition;
    }

    public void setButtonPosition(float startPosition, float endPosition)
    {
        StartPosition = startPosition;
        EndPosition = endPosition;
    }
}
