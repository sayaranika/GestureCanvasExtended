using UnityEngine;

public class HMDMotion
{
    public Vector3 HMDPosition { get; private set; }
    public Quaternion HMDRotation { get; private set; }

    public HMDMotion(Vector3 HMDPosition, Quaternion HMDRotation)
    {
        this.HMDPosition = HMDPosition;
        this.HMDRotation = HMDRotation;
    }
}
