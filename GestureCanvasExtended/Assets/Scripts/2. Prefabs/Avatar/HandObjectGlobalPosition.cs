using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandObjectGlobalPosition : MonoBehaviour
{
    [SerializeField] private GameObject HandModel;

    [SerializeField]
    private GameObject Index1, Index2, Index3;

    [SerializeField]
    private GameObject Thumb0, Thumb1, Thumb2, Thumb3;

    [SerializeField]
    private GameObject Middle1, Middle2, Middle3;

    [SerializeField]
    private GameObject Ring1, Ring2, Ring3;

    [SerializeField]
    private GameObject Pinky0, Pinky1, Pinky2, Pinky3;

    [SerializeField]
    private GameObject Wrist, ForearmStub;

    public Vector3 wrist() { return Wrist.transform.position; }
    public Vector3 index1() { return Index1.transform.position; }
    public Vector3 index2() { return Index2.transform.position; }
    public Vector3 index3() { return Index3.transform.position; }
    public Vector3 middle1() { return Middle1.transform.position; }
    public Vector3 middle2() { return Middle2.transform.position; }
    public Vector3 middle3() { return Middle3.transform.position; }
    public Vector3 ring1() { return Ring1.transform.position; }
    public Vector3 ring2() { return Ring2.transform.position; }
    public Vector3 ring3() { return Ring3.transform.position; }
    public Vector3 pinky0() { return Pinky0.transform.position; }
    public Vector3 pinky1() { return Pinky1.transform.position; }
    public Vector3 pinky2() { return Pinky2.transform.position; }
    public Vector3 pinky3() { return Pinky3.transform.position; }
    public Vector3 thumb0() { return Thumb0.transform.position; }
    public Vector3 thumb1() { return Thumb1.transform.position; }
    public Vector3 thumb2() { return Thumb2.transform.position; }
    public Vector3 thumb3() { return Thumb3.transform.position; }

}
