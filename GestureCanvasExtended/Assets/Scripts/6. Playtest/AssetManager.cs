using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    [SerializeField]
    private OVRSkeleton ovrSkeleton_R;
    [SerializeField]
    private OVRSkeleton ovrSkeleton_L;
    [SerializeField] Transform RightHand;
    [SerializeField] Transform LeftHand;

    [SerializeField]
    private GameObject CenterCamera;

    [Header("GameObjects")]
    [SerializeField] GameObject Shield;
    [SerializeField] GameObject Crate;
    [SerializeField] GameObject Spike;

    [Header("VFX")]
    [SerializeField] GameObject DragonPunch;
    [SerializeField] GameObject IceWall;
    [SerializeField] GameObject AppleBombs;
    [SerializeField] GameObject Chidori;
    [SerializeField] GameObject FireSpray;
    [SerializeField] GameObject SnowStar;


    List<ObjectsThatFollowHand> FollowObjects = new List<ObjectsThatFollowHand>();

    private void Update()
    {
        if (FollowObjects.Count > 0)
        {
            foreach (ObjectsThatFollowHand followObject in FollowObjects)
            {
                //position and rotation according to follow point
                if (followObject.isRight == true) FollowHand(followObject, ovrSkeleton_R);
                else FollowHand(followObject, ovrSkeleton_L);
                if (followObject.obj.tag == "SpawnedVFX")
                {
                    Vector3 forward = CenterCamera.transform.forward;
                    forward.y = 0.0f;
                    followObject.obj.transform.forward = forward;
                }
            }
        }
    }

    public void ClearScene()
    {
        FollowObjects.Clear();
        //destroy previously created objects and then instantiate the new ones.
        GameObject[] b = GameObject.FindGameObjectsWithTag("SpawnedVFX");
        if (b.Length > 0)
        {
            //deactivate
            foreach (var obj in b)
            {
                Destroy(obj);
            }

        }

        GameObject[] c = GameObject.FindGameObjectsWithTag("SpawnedObject");
        if (c.Length > 0)
        {
            //deactivate
            foreach (var obj in c)
            {
                Destroy(obj);
            }

        }
    }

    public void AttachToHand(VirtualObject obj, GameObject ob, OVRSkeleton ovrSkeleton, Transform hand)
    {
        if (obj.AttachedBone == "wrist") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_WristRoot].Transform.position;
        if (obj.AttachedBone == "index1") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index1].Transform.position;
        if (obj.AttachedBone == "index2") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index2].Transform.position;
        if (obj.AttachedBone == "index3") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index3].Transform.position;
        if (obj.AttachedBone == "middle1") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle1].Transform.position;
        if (obj.AttachedBone == "middle2") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle2].Transform.position;
        if (obj.AttachedBone == "middle3") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle3].Transform.position;
        if (obj.AttachedBone == "pinky0") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky0].Transform.position;
        if (obj.AttachedBone == "pinky1") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky1].Transform.position;
        if (obj.AttachedBone == "pinky2") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky2].Transform.position;
        if (obj.AttachedBone == "pinky3") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky3].Transform.position;
        if (obj.AttachedBone == "ring1") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring1].Transform.position;
        if (obj.AttachedBone == "ring2") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring2].Transform.position;
        if (obj.AttachedBone == "ring3") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring3].Transform.position;
        if (obj.AttachedBone == "thumb0") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb0].Transform.position;
        if (obj.AttachedBone == "thumb1") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb1].Transform.position;
        if (obj.AttachedBone == "thumb2") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb2].Transform.position;
        if (obj.AttachedBone == "thumb3") ob.transform.position = ovrSkeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb3].Transform.position;

        ob.transform.rotation = obj.Rotation;
        ob.transform.parent = hand;
    }

    public void SpawnVirtualObjects()
    {
        foreach(VirtualObject obj in PlaytestManager.currentClip.virtualObjects)
        {
            Debug.Log("3000: " + obj.objectName);
            if (obj.isAttached == true)
            {
                GameObject ob = null;
                if (obj.objectName == "Spike") ob = Instantiate(Spike) as GameObject;
                if (obj.objectName == "Shield") ob = Instantiate(Shield) as GameObject;
                if (obj.objectName == "Crate") ob = Instantiate(Crate) as GameObject;
                if (obj.isAttachedToRight == true && ob != null) AttachToHand(obj, ob, ovrSkeleton_R, RightHand);
                else AttachToHand(obj, ob, ovrSkeleton_L, LeftHand);
            }
            else
            {
                if (obj.objectName == "Spike") Instantiate(Spike, obj.Position, obj.Rotation);
                if (obj.objectName == "Shield") Instantiate(Shield, obj.Position, obj.Rotation);
                if (obj.objectName == "Crate") Instantiate(Crate, obj.Position, obj.Rotation);
            }
            

            

        }
    }

    public void SpawnVFXObjects()
    {
        foreach(VFXObject obj in PlaytestManager.currentClip.vfxObjects)
        {
            if (obj.objectName == "DragonPunch")
            {
                GameObject ob = Instantiate(DragonPunch) as GameObject;
                if (obj.isAttached == true) FollowObjects.Add(new ObjectsThatFollowHand(ob, obj.isAttachedToRight, obj.AttachedBone));
            }
            if (obj.objectName == "IceWall")
            {
                GameObject ob = Instantiate(IceWall) as GameObject;
                if (obj.isAttached == true) FollowObjects.Add(new ObjectsThatFollowHand(ob, obj.isAttachedToRight, obj.AttachedBone));
            }
            if (obj.objectName == "AppleBombs")
            {
                GameObject ob = Instantiate(AppleBombs) as GameObject;
                if (obj.isAttached == true) FollowObjects.Add(new ObjectsThatFollowHand(ob, obj.isAttachedToRight, obj.AttachedBone));
            }
            if (obj.objectName == "Chidori")
            {
                GameObject ob = Instantiate(Chidori) as GameObject;
                if (obj.isAttached == true) FollowObjects.Add(new ObjectsThatFollowHand(ob, obj.isAttachedToRight, obj.AttachedBone));
            }
            if (obj.objectName == "FireSpray")
            {
                GameObject ob = Instantiate(FireSpray) as GameObject;
                if (obj.isAttached == true) FollowObjects.Add(new ObjectsThatFollowHand(ob, obj.isAttachedToRight, obj.AttachedBone));
            }

            if (obj.objectName == "SnowStar")
            {
                GameObject ob = Instantiate(SnowStar) as GameObject;
                if (obj.isAttached == true) FollowObjects.Add(new ObjectsThatFollowHand(ob, obj.isAttachedToRight, obj.AttachedBone));
            }
        }
    }
    public void LoadObjects()
    {
        ClearScene();
        SpawnVirtualObjects();
        SpawnVFXObjects();
    }


    public void FollowHand(ObjectsThatFollowHand followObject, OVRSkeleton skeleton)
    {
        //followObject.obj.transform.rotation = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_WristRoot].Transform.rotation;
        if (followObject.AttachedPoint == "wrist") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_WristRoot].Transform.position;
        if (followObject.AttachedPoint == "index1") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index1].Transform.position;
        if (followObject.AttachedPoint == "index2") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index2].Transform.position;
        if (followObject.AttachedPoint == "index3") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index3].Transform.position;
        if (followObject.AttachedPoint == "middle1") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle1].Transform.position;
        if (followObject.AttachedPoint == "middle2") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle2].Transform.position;
        if (followObject.AttachedPoint == "middle3") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle3].Transform.position;
        if (followObject.AttachedPoint == "pinky0") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky0].Transform.position;
        if (followObject.AttachedPoint == "pinky1") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky1].Transform.position;
        if (followObject.AttachedPoint == "pinky2") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky2].Transform.position;
        if (followObject.AttachedPoint == "pinky3") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky3].Transform.position;
        if (followObject.AttachedPoint == "ring1") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring1].Transform.position;
        if (followObject.AttachedPoint == "ring2") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring2].Transform.position;
        if (followObject.AttachedPoint == "ring3") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring3].Transform.position;
        if (followObject.AttachedPoint == "thumb0") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb0].Transform.position;
        if (followObject.AttachedPoint == "thumb1") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb1].Transform.position;
        if (followObject.AttachedPoint == "thumb2") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb2].Transform.position;
        if (followObject.AttachedPoint == "thumb3") followObject.obj.transform.position = skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb3].Transform.position;
    }
}

public class ObjectsThatFollowHand
{
    public GameObject obj;
    public bool isRight;
    public string AttachedPoint;

    public ObjectsThatFollowHand(GameObject obj, bool isRight, string AttachedPoint)
    {
        this.obj = obj;
        this.isRight = isRight;
        this.AttachedPoint = AttachedPoint;
    }
}
