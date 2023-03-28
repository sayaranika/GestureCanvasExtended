using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigsManipulation : MonoBehaviour
{
    public bool isAttachable = true;
    public bool isAttached = false;
    public string AttachedBone = "";
    public bool isAttachedToRight;

    private void Update()
    {
        if (isAttached == true)
        {

            if (isAttachedToRight == true)
            {
                AvatarManager avatarManager = GameObject.Find("AvatarManager").GetComponent<AvatarManager>();
                if (AttachedBone == "wrist") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().wrist();
                if (AttachedBone == "index1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().index1();
                if (AttachedBone == "index2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().index2();
                if (AttachedBone == "index3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().index3();
                if (AttachedBone == "middle1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().middle1();
                if (AttachedBone == "middle2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().middle2();
                if (AttachedBone == "middle3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().middle3();
                if (AttachedBone == "pinky0") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky0();
                if (AttachedBone == "pinky1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky1();
                if (AttachedBone == "pinky2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky2();
                if (AttachedBone == "pinky3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky3();
                if (AttachedBone == "ring1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().ring1();
                if (AttachedBone == "ring2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().ring2();
                if (AttachedBone == "ring3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().ring3();
                if (AttachedBone == "thumb0") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb0();
                if (AttachedBone == "thumb1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb1();
                if (AttachedBone == "thumb2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb2();
                if (AttachedBone == "thumb3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb3();
            }

            else if (isAttachedToRight == false)
            {
                AvatarManager avatarManager = GameObject.Find("AvatarManager").GetComponent<AvatarManager>();


                if (AttachedBone == "wrist") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().wrist();
                if (AttachedBone == "index1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().index1();
                if (AttachedBone == "index2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().index2();
                if (AttachedBone == "index3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().index3();
                if (AttachedBone == "middle1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().middle1();
                if (AttachedBone == "middle2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().middle2();
                if (AttachedBone == "middle3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().middle3();
                if (AttachedBone == "pinky0") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().pinky0();
                if (AttachedBone == "pinky1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().pinky1();
                if (AttachedBone == "pinky2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().pinky2();
                if (AttachedBone == "pinky3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().pinky3();
                if (AttachedBone == "ring1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().ring1();
                if (AttachedBone == "ring2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().ring2();
                if (AttachedBone == "ring3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().ring3();
                if (AttachedBone == "thumb0") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().thumb0();
                if (AttachedBone == "thumb1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().thumb1();
                if (AttachedBone == "thumb2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().thumb2();
                if (AttachedBone == "thumb3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().thumb3();


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PinchArea")
        {
            isAttachable = false;
            isAttached = false;

            VirtualObject rootObj = gameObject.transform.root.gameObject.GetComponent<ObjectController>().objectRef;
            rootObj.isRigAttached = false;
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PinchArea")
        {
            isAttachable = true;
        }
    }

}
