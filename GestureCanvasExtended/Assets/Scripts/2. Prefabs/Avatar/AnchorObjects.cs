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
            if (objectController.isAttachable == true && objectController.objectRef.isAttached == false)
            {
                Debug.Log("300: attached");
                objectController.objectRef.isAttached = true;
                objectController.objectRef.AttachedBone = anchorName;

            }
        }

        if (other.tag == "Trouble")
        {
            Debug.Log("300: trouble detected");

            ObjectController objectController = other.transform.parent.GetComponent<ObjectController>();
            
            if (objectController.isAttachable == true && objectController.objectRef.isAttached == false)
            {
                Debug.Log("300: attached");
                objectController.objectRef.isAttached = true;
                objectController.objectRef.AttachedBone = anchorName;

            }
        }

        if (other.tag == "RigPoint")
        {
            Debug.Log("300: spawned");
            if (other.GetComponent<RigsManipulation>().isAttachable == true && other.GetComponent<RigsManipulation>().isAttached == false)
            {
                other.GetComponent<RigsManipulation>().isAttached = true;
                other.GetComponent<RigsManipulation>().AttachedBone = anchorName;

                VirtualObject rootObj = other.transform.root.gameObject.GetComponent<ObjectController>().objectRef;
                rootObj.rigAttachedName = anchorName;
                rootObj.isRigAttachedToRight = isRight;
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
            /*if (objectController == null)
            {
                objectController = other.GetComponentInParent<ObjectController>();
                if (objectController == null)
                {
                    objectController = other.GetComponentInChildren<ObjectController>();
                }
            }*/

            if (objectController.isAttachable == true && objectController.objectRef.isAttached == false)
            {
                Debug.Log("400: attached");
                objectController.objectRef.isAttached = true;
                objectController.objectRef.isAttachedToRight = isRight;
                objectController.objectRef.AttachedBone = anchorName;

            }
        }
        if (other.tag == "Trouble")
        {
            Debug.Log("300: trouble detected");

            ObjectController objectController = other.transform.parent.GetComponent<ObjectController>();

            if (objectController.isAttachable == true && objectController.objectRef.isAttached == false)
            {
                Debug.Log("300: attached");
                objectController.objectRef.isAttached = true;
                objectController.objectRef.isAttachedToRight = isRight;
                objectController.objectRef.AttachedBone = anchorName;

            }
        }

        if (other.tag == "RigPoint")
        {
            if (other.GetComponent<MeshRenderer>().enabled == true && other.GetComponent<RigsManipulation>().isAttachable == true && other.GetComponent<RigsManipulation>().isAttached == false)
            {
                other.GetComponent<RigsManipulation>().isAttached = true;
                other.GetComponent<RigsManipulation>().isAttachedToRight = isRight;
                other.GetComponent<RigsManipulation>().AttachedBone = anchorName;

                if(other.transform.root.name.StartsWith("Bow"))
                {
                    VirtualObject rootObj = other.transform.root.gameObject.GetComponent<ObjectController>().objectRef;
                    rootObj.rigAttachedName = anchorName;
                    rootObj.isRigAttached = true;
                    rootObj.isRigAttachedToRight = isRight;
                }

            }
        }
    }

    
}
