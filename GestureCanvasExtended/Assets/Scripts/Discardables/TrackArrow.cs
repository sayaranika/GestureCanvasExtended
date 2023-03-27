using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackArrow : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("8000: " + gameObject.name + " Position: " + gameObject.transform.position + " Local Position: " + gameObject.transform.localPosition +
          //  " Rotation: " + gameObject.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PinchArea")
        {
            gameObject.transform.parent.GetComponent<ObjectController>().isAttachable = false;
            gameObject.transform.parent.GetComponent<ObjectController>().objectRef.isAttached = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PinchArea")
        {
            gameObject.transform.parent.GetComponent<ObjectController>().isAttachable = true;
        }
    }


}
