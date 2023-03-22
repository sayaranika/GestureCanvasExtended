using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorObjects : MonoBehaviour
{
    [SerializeField] string anchorName;
    [SerializeField] bool isRight;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("300: " + other.name + " " + other.tag);

        if(other.tag == "SpawnedVFX")
        {
            Debug.Log("300: spawned");
            if (other.GetComponent<VFXController>().isAttachable == true && other.GetComponent<VFXController>().vfxObjectRef.isAttached == false)
            {
                Debug.Log("300: attached");
                other.GetComponent<VFXController>().vfxObjectRef.isAttached = true;
                other.GetComponent<VFXController>().vfxObjectRef.AttachedBone = anchorName;

            }
        }

        if (other.tag == "SpawnedObject")
        {
            Debug.Log("300: spawned");

            ObjectController objectController = other.GetComponent<ObjectController>();
            if(objectController == null)
            {
                objectController = other.GetComponentInParent<ObjectController>();
                if(objectController == null)
                {
                    objectController = other.GetComponentInChildren<ObjectController>();
                }
            }

            if (objectController.isAttachable == true && objectController.objectRef.isAttached == false)
            {
                Debug.Log("300: attached");
                objectController.objectRef.isAttached = true;
                objectController.objectRef.AttachedBone = anchorName;

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("400: " + other.name + " " + other.tag);
        if (other.tag == "SpawnedVFX")
        {
            Debug.Log("400: spawned");
            if (other.GetComponent<VFXController>().isAttachable == true && other.GetComponent<VFXController>().vfxObjectRef.isAttached == false)
            {
                Debug.Log("400: attached");
                other.GetComponent<VFXController>().vfxObjectRef.isAttached = true;
                other.GetComponent<VFXController>().vfxObjectRef.isAttachedToRight = isRight;
                other.GetComponent<VFXController>().vfxObjectRef.AttachedBone = anchorName;

            }
        }

        if (other.tag == "SpawnedObject")
        {
            Debug.Log("400: spawned");

            ObjectController objectController = other.GetComponent<ObjectController>();
            if (objectController == null)
            {
                objectController = other.GetComponentInParent<ObjectController>();
                if (objectController == null)
                {
                    objectController = other.GetComponentInChildren<ObjectController>();
                }
            }

            if (objectController.isAttachable == true && objectController.objectRef.isAttached == false)
            {
                Debug.Log("400: attached");
                objectController.objectRef.isAttached = true;
                objectController.objectRef.isAttachedToRight = isRight;
                objectController.objectRef.AttachedBone = anchorName;

            }
        }
    }

    
}
