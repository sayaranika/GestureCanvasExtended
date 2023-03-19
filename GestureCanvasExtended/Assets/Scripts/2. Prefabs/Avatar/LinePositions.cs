using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePositions : MonoBehaviour
{
    public LineRenderer line;

    public Transform startPos;
    public Transform endPos;

    private void Start()
    {
        line.positionCount = 2;
        line.startWidth = 0.005f;
        line.endWidth = 0.005f;
        
    }

    private void Update()
    {
        line.SetPosition(0, startPos.position);
        line.SetPosition(1, endPos.position);
    }
}
