using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducerData
{
    public Vector point;
    public int frame;

    public ProducerData(int frame, Vector point)
    {
        this.frame = frame;
        this.point = point;
    }
}
