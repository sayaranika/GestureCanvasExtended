using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PinchArea")
        {
            transform.parent.gameObject.GetComponent<ObjectController>().isAttachable = false;
            transform.parent.gameObject.GetComponent<ObjectController>().objectRef.isAttached = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PinchArea")
        {
            transform.parent.gameObject.GetComponent<ObjectController>().isAttachable = true;
        }
    }
}
