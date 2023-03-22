using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public Clip clipRef;
    public VFXObject vfxObjectRef;

    public static bool UpdateData = false;

    public bool isAttachable = true;

    private void Update()
    {
        if (UpdateData == true)
        {
            vfxObjectRef.Position = gameObject.transform.position;
            vfxObjectRef.Rotation = gameObject.transform.rotation;

            UpdateData = false;
        }

        if (vfxObjectRef.isAttached == true)
        {
            if (vfxObjectRef.isAttachedToRight == true)
            {
                AvatarManager avatarManager = GameObject.Find("AvatarManager").GetComponent<AvatarManager>();


                if (vfxObjectRef.AttachedBone == "wrist") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().wrist();

                if (vfxObjectRef.AttachedBone == "index1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().index1();
                if (vfxObjectRef.AttachedBone == "index2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().index2();
                if (vfxObjectRef.AttachedBone == "index3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().index3();
                if (vfxObjectRef.AttachedBone == "middle1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().middle1();
                if (vfxObjectRef.AttachedBone == "middle2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().middle2();
                if (vfxObjectRef.AttachedBone == "middle3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().middle3();
                if (vfxObjectRef.AttachedBone == "pinky0") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky0();
                if (vfxObjectRef.AttachedBone == "pinky1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky1();
                if (vfxObjectRef.AttachedBone == "pinky2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky2();
                if (vfxObjectRef.AttachedBone == "pinky3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky3();
                if (vfxObjectRef.AttachedBone == "ring1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().ring1();
                if (vfxObjectRef.AttachedBone == "ring2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().ring2();
                if (vfxObjectRef.AttachedBone == "ring3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().ring3();
                if (vfxObjectRef.AttachedBone == "thumb0") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb0();
                if (vfxObjectRef.AttachedBone == "thumb1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb1();
                if (vfxObjectRef.AttachedBone == "thumb2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb2();
                if (vfxObjectRef.AttachedBone == "thumb3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb3();


            }

            else if (vfxObjectRef.isAttachedToRight == false)
            {
                AvatarManager avatarManager = GameObject.Find("AvatarManager").GetComponent<AvatarManager>();


                if (vfxObjectRef.AttachedBone == "wrist") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().wrist();

                if (vfxObjectRef.AttachedBone == "index1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().index1();
                if (vfxObjectRef.AttachedBone == "index2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().index2();
                if (vfxObjectRef.AttachedBone == "index3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().index3();
                if (vfxObjectRef.AttachedBone == "middle1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().middle1();
                if (vfxObjectRef.AttachedBone == "middle2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().middle2();
                if (vfxObjectRef.AttachedBone == "middle3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().middle3();
                if (vfxObjectRef.AttachedBone == "pinky0") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().pinky0();
                if (vfxObjectRef.AttachedBone == "pinky1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().pinky1();
                if (vfxObjectRef.AttachedBone == "pinky2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().pinky2();
                if (vfxObjectRef.AttachedBone == "pinky3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().pinky3();
                if (vfxObjectRef.AttachedBone == "ring1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().ring1();
                if (vfxObjectRef.AttachedBone == "ring2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().ring2();
                if (vfxObjectRef.AttachedBone == "ring3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().ring3();
                if (vfxObjectRef.AttachedBone == "thumb0") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().thumb0();
                if (vfxObjectRef.AttachedBone == "thumb1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().thumb1();
                if (vfxObjectRef.AttachedBone == "thumb2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().thumb2();
                if (vfxObjectRef.AttachedBone == "thumb3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().thumb3();


            }


            Vector3 forward = AvatarManager.HMDDirection;
            forward.y = 0.0f;
            gameObject.transform.GetChild(0).transform.forward = forward;
        }
    }

    private void OnDestroy()
    {
        vfxObjectRef.Position = gameObject.transform.position;
        vfxObjectRef.Rotation = gameObject.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PinchArea")
        {
            isAttachable = false;
            vfxObjectRef.isAttached = false;

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
