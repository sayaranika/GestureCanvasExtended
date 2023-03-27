using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizerController : MonoBehaviour
{
    public string AttachedBone;
    public Handedness handedness;
    public bool isSet = false;
    private void Update()
    {
        if(isSet == true)
        {
            AvatarManager avatarManager = GameObject.Find("AvatarManager").GetComponent<AvatarManager>();
            if(handedness == Handedness.Right)
            {
                if (AttachedBone == "Index") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().index3();
                if (AttachedBone == "Middle") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().middle3();
                if (AttachedBone == "Pinky") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky3();
                if (AttachedBone == "Ring") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().ring3();
                if (AttachedBone == "Thumb") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb3();
            }
            else
            {
                if (AttachedBone == "Index") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().index3();
                if (AttachedBone == "Middle") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().middle3();
                if (AttachedBone == "Pinky") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().pinky3();
                if (AttachedBone == "Ring") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().ring3();
                if (AttachedBone == "Thumb") gameObject.transform.position = avatarManager.CurrentAvatar_R().GetComponent<HandObjectGlobalPosition>().thumb3();
            }
        }

        
    }
}
