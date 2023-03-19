using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMDObject : MonoBehaviour
{
    [SerializeField] private GameObject HMD;

    public void SetDataForFrame(HMDMotion data, Vector3 OffsetPosition)
    {
        HMD.transform.position = data.HMDPosition + OffsetPosition;
        HMD.transform.rotation = data.HMDRotation;
    }
}
