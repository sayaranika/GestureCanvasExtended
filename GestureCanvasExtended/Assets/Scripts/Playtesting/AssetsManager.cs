using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsManager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject Bow;
    [SerializeField] GameObject Arrow;

    [Header("Left Hand")]
    [SerializeField] OVRSkeleton ovrSkeleton_L;
    [SerializeField] GameObject HandModel_L;

    [Header("Right Hand")]
    [SerializeField] OVRSkeleton ovrSkeleton_R;
    [SerializeField] GameObject HandModel_R;

    public float smoothness = 0.5f; // Controls the speed of interpolation
    public float distanceFactor = 0.1f; // Controls the distance factor
    public float speed = 10.0f;

    List<ObjectsThatFollowHand> FollowObjects = new List<ObjectsThatFollowHand>();


    public void LoadObjects()
    {
        ClearScene();
        SpawnVirtualObjects();
        SpawnVFXObjects();
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
                    targetRotation = HandModel_R.transform.rotation;
                }
                else
                {
                    targetPosition = GetPosition(ob.AttachedPoint, ovrSkeleton_L);
                    targetRotation = HandModel_L.transform.rotation;
                }
                //Vector3 targetPosition = ovrSkeleton_L.Bones[(int)OVRPlugin.BoneId.Hand_Middle2].Transform.position;
                //Quaternion targetRotation = HandModel_L.transform.rotation;

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

        GameObject[] c = GameObject.FindGameObjectsWithTag("SpawnedObject");
        if (c.Length > 0)
        {
            foreach (var obj in c)
                Destroy(obj);
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
            }
            else
            {
                //if (obj.objectName == "Spike") Instantiate(Spike, obj.Position, obj.Rotation);
                //if (obj.objectName == "Shield") Instantiate(Shield, obj.Position, obj.Rotation);
                //if (obj.objectName == "Crate") Instantiate(Crate, obj.Position, obj.Rotation);
                if (obj.objectName == "Bow") Instantiate(Bow, obj.Position, obj.Rotation);
                if (obj.objectName == "Arrow") Instantiate(Arrow, obj.Position, obj.Rotation);
            }
        }

            /*GameObject ob = null;
        ob = Instantiate(Bow) as GameObject;

        ob.transform.parent = null;
        ob.transform.position = new Vector3(0, 1, 3);
        Vector3 forward = HandModel_L.transform.forward;
        forward.y = 0.0f;
        ob.transform.forward = forward;
        FollowObjects.Add(new ObjectsThatFollowHand(ob, false, "index1"));*/
    }
    #endregion
}
