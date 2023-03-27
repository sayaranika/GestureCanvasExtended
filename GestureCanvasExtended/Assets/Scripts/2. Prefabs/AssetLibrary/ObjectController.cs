using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class ObjectController : MonoBehaviour
{
    public Clip clipRef;
    public VirtualObject objectRef;
    public static bool UpdateData = false;
    public bool isAttachable = true;
    //List<CustomAnimation> customAnimations = new List<CustomAnimation>();

    public bool isGravity = false;
    public bool isInReplay = false;
    public bool isInRecord = false;
    Vector3 startPos;
    private int currentReplayIndex;

    private void Update()
    {

        if (isInReplay == false)
        {
            /*if (objectRef.animation.Count > 0)
            {
                StartPlaybackWOReset();
            }*/
        }
        /*if (UpdateData == true && objectRef.animation.Count == 0)
        {
            objectRef.Position = gameObject.transform.position;
            objectRef.Rotation = gameObject.transform.rotation;

            UpdateData = false;
        }*/

        if (objectRef.isAttached == true)
        {
            //remove physics
            if (isGravity == true)
            {
                objectRef.objectRef.GetComponent<Rigidbody>().isKinematic = true;
                objectRef.objectRef.GetComponent<Rigidbody>().useGravity = false;
                isGravity = false;
            }


            if (objectRef.isAttachedToRight == true)
            {
                //ob.transform.parent = hand;
                AvatarManager avatarManager = GameObject.Find("AvatarManager").GetComponent<AvatarManager>();
                if (objectRef.AttachedBone == "wrist") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().wrist();
                if (objectRef.AttachedBone == "index1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().index1();
                if (objectRef.AttachedBone == "index2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().index2();
                if (objectRef.AttachedBone == "index3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().index3();
                if (objectRef.AttachedBone == "middle1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().middle1();
                if (objectRef.AttachedBone == "middle2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().middle2();
                if (objectRef.AttachedBone == "middle3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().middle3();
                if (objectRef.AttachedBone == "pinky0") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky0();
                if (objectRef.AttachedBone == "pinky1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky1();
                if (objectRef.AttachedBone == "pinky2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky2();
                if (objectRef.AttachedBone == "pinky3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky3();
                if (objectRef.AttachedBone == "ring1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().ring1();
                if (objectRef.AttachedBone == "ring2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().ring2();
                if (objectRef.AttachedBone == "ring3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().ring3();
                if (objectRef.AttachedBone == "thumb0") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb0();
                if (objectRef.AttachedBone == "thumb1") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb1();
                if (objectRef.AttachedBone == "thumb2") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb2();
                if (objectRef.AttachedBone == "thumb3") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb3();
            }

            else if (objectRef.isAttachedToRight == false)
            {
                AvatarManager avatarManager = GameObject.Find("AvatarManager").GetComponent<AvatarManager>();


                if (objectRef.AttachedBone == "wrist") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().wrist();
                if (objectRef.AttachedBone == "index1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().index1();
                if (objectRef.AttachedBone == "index2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().index2();
                if (objectRef.AttachedBone == "index3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().index3();
                if (objectRef.AttachedBone == "middle1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().middle1();
                if (objectRef.AttachedBone == "middle2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().middle2();
                if (objectRef.AttachedBone == "middle3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().middle3();
                if (objectRef.AttachedBone == "pinky0") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().pinky0();
                if (objectRef.AttachedBone == "pinky1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().pinky1();
                if (objectRef.AttachedBone == "pinky2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().pinky2();
                if (objectRef.AttachedBone == "pinky3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().pinky3();
                if (objectRef.AttachedBone == "ring1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().ring1();
                if (objectRef.AttachedBone == "ring2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().ring2();
                if (objectRef.AttachedBone == "ring3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().ring3();
                if (objectRef.AttachedBone == "thumb0") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().thumb0();
                if (objectRef.AttachedBone == "thumb1") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().thumb1();
                if (objectRef.AttachedBone == "thumb2") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().thumb2();
                if (objectRef.AttachedBone == "thumb3") gameObject.transform.position = avatarManager.CurrentAvatar_L().GetComponent<HandObjectGlobalPosition>().thumb3();


            }


            //Vector3 forward = AvatarManager.HMDDirection;
            //forward.y = 0.0f;
            //gameObject.transform.GetChild(0).transform.forward = forward;
        }
        else
        {
            /*if (isGravity == false)
            {
                objectRef.objectRef.GetComponent<Rigidbody>().isKinematic = false;
                objectRef.objectRef.GetComponent<Rigidbody>().useGravity = true;

                isGravity = true;
            }*/

        }
    }


    private void OnDestroy()
    {
        Debug.Log("5000: Object Ref Name: " + objectRef.objectRef.name + " Position: " + objectRef.objectRef.transform.position + " local Position: " + objectRef.objectRef.transform.localRotation);
        Debug.Log("5000: This object: " + gameObject.name + " position: " + gameObject.transform.position + " local position: " + gameObject.transform.localRotation);

        objectRef.Position = gameObject.transform.localPosition;
        objectRef.Rotation = gameObject.transform.localRotation;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PinchArea")
        {
            isAttachable = false;
            objectRef.isAttached = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PinchArea")
        {
            isAttachable = true;
        }
    }

    private void LateUpdate()
    {
        if (isInRecord)
        {
            //customAnimations.Add(new CustomAnimation(objectRef.objectRef.transform.position, objectRef.objectRef.transform.rotation, objectRef.objectRef.transform.localScale));
        }

        if (isInReplay)
        {
            int nextIndex = currentReplayIndex + 1;

            /*if (nextIndex < customAnimations.Count)
            {
                SetTransform(nextIndex);
            }
            else SetTransform(0);*/
        }
    }

    private void SetTransform(int index)
    {
        currentReplayIndex = index;
        //CustomAnimation frame = customAnimations[index];
        /*objectRef.objectRef.transform.position = frame.position;
        objectRef.objectRef.transform.rotation = frame.rotation;
        objectRef.objectRef.transform.localScale = frame.scale;*/
    }


    public void StartRecording()
    {
        if (objectRef.isAttached == false)
        {
            startPos = objectRef.objectRef.transform.position;
            isInRecord = true;
        }

    }

    public void StopRecording()
    {
        objectRef.objectRef.transform.position = startPos;
        isInRecord = false;
        //objectRef.animation = customAnimations;
    }



    public void StartPlaybackWOReset()
    {
        GameObject obj = objectRef.objectRef;
        startPos = obj.transform.position;

        Rigidbody rigidbody = obj.GetComponent<Rigidbody>();

        rigidbody.isKinematic = true;

        isInReplay = true;
    }

}
