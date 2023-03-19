using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMDRecorder : MonoBehaviour
{
    public HMDMotion GetHMDData(GameObject HMD)
    {
        Vector3 HMDPosition = HMD.transform.position;
        Quaternion HMDRotation = HMD.transform.rotation;
        return new HMDMotion(HMDPosition, HMDRotation);
    }
}
