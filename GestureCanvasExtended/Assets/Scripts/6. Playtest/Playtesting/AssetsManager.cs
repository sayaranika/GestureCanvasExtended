using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AssetsManager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject Bow;
    [SerializeField] GameObject Arrow;

    [Header("Triggers")]
    [SerializeField] GameObject TouchTrigger;

    [Header("Left Hand")]
    [SerializeField] OVRSkeleton ovrSkeleton_L;
    [SerializeField] GameObject HandModel_L;

    [Header("Right Hand")]
    [SerializeField] OVRSkeleton ovrSkeleton_R;
    [SerializeField] GameObject HandModel_R;

    [SerializeField] PlaytestingManager playtestManager;
    [SerializeField] PoseRecognizer poseRecognizer;

    public float smoothness = 0.5f; // Controls the speed of interpolation
    public float distanceFactor = 0.1f; // Controls the distance factor
    public float speed = 10.0f;

    List<ObjectsThatFollowHand> FollowObjects = new List<ObjectsThatFollowHand>();


    public void LoadObjects()
    {
        ClearScene();
        SpawnVirtualObjects();
        SpawnVFXObjects();
        SpawnTouchTriggers();
    }

    private void Update()
    {
        if (FollowObjects.Count > 0)
        {
            foreach(ObjectsThatFollowHand ob in FollowObjects)
            {
                Vector3 targetPosition;
                Quaternion targetRotation;
                if(ob.isRight == true)
                {
                    targetPosition = GetPosition(ob.AttachedPoint, ovrSkeleton_R);
                    //targetRotation = HandModel_R.transform.rotation;
                    //targetRotation = Quaternion.LookRotation(HandModel_L.transform.position, Vector3.up);
                    targetRotation = HandModel_R.transform.rotation * Quaternion.Euler(90, 0, 180);
                }
                else
                {
                    targetPosition = GetPosition(ob.AttachedPoint, ovrSkeleton_L);
                    targetRotation = HandModel_L.transform.rotation;
                }
                ob.obj.transform.position = Vector3.MoveTowards(ob.obj.transform.position, targetPosition, speed * Time.deltaTime);
                ob.obj.transform.rotation = Quaternion.Slerp(ob.obj.transform.rotation, targetRotation, smoothness * speed * Time.deltaTime);
            }
        }
    }

    public Vector3 GetPosition(string bone, OVRSkeleton skeleton)
    {
        if (bone == "wrist") return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_WristRoot].Transform.position;
        if (bone == "index1")  return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index1].Transform.position;
        if (bone == "index2")  return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index2].Transform.position;
        if (bone == "index3")  return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index3].Transform.position;
        if (bone == "middle1") return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle1].Transform.position;
        if (bone == "middle2") return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle2].Transform.position;
        if (bone == "middle3") return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle3].Transform.position;
        if (bone == "pinky0")  return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky0].Transform.position;
        if (bone == "pinky1")  return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky1].Transform.position;
        if (bone == "pinky2")  return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky2].Transform.position;
        if (bone == "pinky3")  return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky3].Transform.position;
        if (bone == "ring1") return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring1].Transform.position;
        if (bone == "ring2")   return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring2].Transform.position;
        if (bone == "ring3")   return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring3].Transform.position;
        if (bone == "thumb0")  return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb0].Transform.position;
        if (bone == "thumb1")  return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb1].Transform.position;
        if (bone == "thumb2")  return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb2].Transform.position;
        if (bone == "thumb3") return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb3].Transform.position;
        else return skeleton.Bones[(int)OVRPlugin.BoneId.Hand_WristRoot].Transform.position;
    }


    #region HELPERS
    public void ClearScene()
    {
        FollowObjects.Clear();
        GameObject[] b = GameObject.FindGameObjectsWithTag("SpawnedVFX");
        if (b.Length > 0)
        {
            foreach (var obj in b)
                Destroy(obj);
        }

        GameObject[] c = GameObject.FindGameObjectsWithTag("ProximityObject");
        if (c.Length > 0)
        {
            foreach (var obj in c)
                Destroy(obj);
        }

        GameObject[] d = GameObject.FindGameObjectsWithTag("SpawnedObject");
        if (d.Length > 0)
        {
            foreach (var obj in d)
                Destroy(obj);
        }
    }

    public void SpawnTouchTriggers()
    {
        foreach(Interaction i in PlaytestingManager.currentClip.interactions)
        {
            if(i.isTouch_L == true || i.isTouch_R == true)
            {
                if(i.triggerParent == "ArrowPivot(Clone)")
                {
                    GameObject obj = GameObject.Find("ArrowPlay(Clone)");
                    GameObject touch = Instantiate(TouchTrigger, obj.transform);
                    touch.transform.localPosition = i.triggerPosition;
                    touch.transform.localRotation = i.triggerRotation;
                    touch.transform.localScale = i.triggerScale;
                    touch.GetComponent<TouchTrigger>().interaction = i;
                    touch.GetComponent<TouchTrigger>().playtestManager = playtestManager;
                    touch.GetComponent<TouchTrigger>().poseRecognizer = poseRecognizer;

                }
                else
                {
                    GameObject touch = Instantiate(TouchTrigger);
                    touch.transform.position = i.triggerPosition;
                    touch.transform.rotation = i.triggerRotation;
                    touch.transform.localScale = i.triggerScale;
                    touch.GetComponent<TouchTrigger>().interaction = i;
                    touch.GetComponent<TouchTrigger>().poseRecognizer = poseRecognizer;
                    touch.GetComponent<TouchTrigger>().playtestManager = playtestManager;
                }
            }
        }
    }

    public void SpawnVFXObjects() { }

    public void SpawnVirtualObjects()
    {
        foreach (VirtualObject obj in PlaytestingManager.currentClip.virtualObjects)
        {
            if(obj.isAttached)
            {
                GameObject ob = null;
                if (obj.objectName == "Bow") ob = Instantiate(Bow, obj.Position, obj.Rotation);
                if (obj.objectName == "Arrow") ob = Instantiate(Arrow, obj.Position, obj.Rotation);
                ob.transform.parent = null;
                //ob.transform.position = new Vector3(0, 1, 3);
                Vector3 forward;
                if (obj.isAttachedToRight == true)
                {
                    ob.transform.position = HandModel_R.transform.position;
                    forward = HandModel_R.transform.forward;
                }
                else
                {
                    ob.transform.position = HandModel_L.transform.position;
                    forward = HandModel_L.transform.forward;
                }
                forward.y = 0.0f;
                ob.transform.forward = forward;
                if (obj.isAttachedToRight == true) FollowObjects.Add(new ObjectsThatFollowHand(ob, true, obj.AttachedBone));
                else FollowObjects.Add(new ObjectsThatFollowHand(ob, false, obj.AttachedBone));

                if(obj.isRigAttached == true)
                {
                    Debug.Log("8000: Inside for gameObject " + ob.name);

                    GameObject rig = ob.transform.GetChild(0).transform.GetChild(3).gameObject;

                    if(rig == null)
                    {
                        Debug.Log("8000: Rig not found");
                    }
                    else
                    {
                        Debug.Log("8000: Found");
                        if (obj.isRigAttachedToRight == true) FollowObjects.Add(new ObjectsThatFollowHand(rig, true, obj.rigAttachedName));
                        else FollowObjects.Add(new ObjectsThatFollowHand(rig, true, obj.rigAttachedName));
                        Debug.Log("8000: Attached");
                    }

                    
                }

            }
            else
            {
                //if (obj.objectName == "Spike") Instantiate(Spike, obj.Position, obj.Rotation);
                //if (obj.objectName == "Shield") Instantiate(Shield, obj.Position, obj.Rotation);
                //if (obj.objectName == "Crate") Instantiate(Crate, obj.Position, obj.Rotation);
                if (obj.objectName == "Bow")
                {
                    Debug.Log("5000: Instantiating Bow at " + obj.Position + " " + obj.Rotation);
                    Instantiate(Bow, obj.Position, obj.Rotation);
                }
                if (obj.objectName == "Arrow")
                {
                    Debug.Log("5000: Instantiating Arrow at " + obj.Position + " " + obj.Rotation);

                    Instantiate(Arrow, obj.Position, obj.Rotation);
                }
            }
        }
    }
    #endregion
}
