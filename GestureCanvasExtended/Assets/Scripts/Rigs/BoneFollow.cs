using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneFollow : MonoBehaviour
{
    //public Transform bone;

    void Update()
    {
        // Set the position of the bone to the position of the sphere.
        Transform bone = gameObject.transform.parent.transform;
        bone.position = gameObject.transform.position;
        //bone.position = transform.position;
    }
}
