using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetController : MonoBehaviour
{
    [SerializeField]
    private OVRSkeleton ovrSkeleton_R;
    [SerializeField] GameObject HandModel_R;
    [SerializeField] GameObject HandModel_L;
    [SerializeField]
    private OVRSkeleton ovrSkeleton_L;
    //[SerializeField] Transform RightHand;
    //[SerializeField] Transform LeftHand;

    //[SerializeField]
    //private GameObject CenterCamera;

    [Header("GameObjects")]
    [SerializeField] GameObject Shield;
    [SerializeField] GameObject Crate;
    [SerializeField] GameObject Spike;
    [SerializeField] GameObject Bow;
    [SerializeField] GameObject Arrow;

    [Header("VFX")]
    [SerializeField] GameObject DragonPunch;
    [SerializeField] GameObject IceWall;
    [SerializeField] GameObject AppleBombs;
    [SerializeField] GameObject Chidori;
    [SerializeField] GameObject FireSpray;
    [SerializeField] GameObject SnowStar;


    List<ObjectsThatFollowHand> FollowObjects = new List<ObjectsThatFollowHand>();
    public float smoothness = 0.5f;
    public float speed = 10.0f;


    private void Update()
    {
        Debug.Log("2000A: Here");
        if (FollowObjects.Count > 0)
        {
            Debug.Log("2000 B");
            foreach (ObjectsThatFollowHand followObject in FollowObjects)
            {
                //GameObject HandModel;
                //if (followObject.isRight == true) HandModel = HandModel_R;
                //else HandModel = HandModel_L;
                //Vector3 targetPosition = HandModel.transform.position;
                //Quaternion targetRotation = HandModel.transform.rotation;
                //followObject.obj.transform.position = Vector3.MoveTowards(followObject.obj.transform.position, targetPosition, speed * Time.deltaTime);
                //followObject.obj.transform.rotation = Quaternion.Slerp(followObject.obj.transform.rotation, targetRotation, smoothness * speed * Time.deltaTime);
                
                Debug.Log("2000 C");

                if (followObject.obj.tag == "SpawnedObject")
                {
                    Debug.Log("2000 D");

                    
                    if (followObject.isRight == true)
                    {
                    Debug.Log("2000 E");


                        FollowHand(followObject, ovrSkeleton_R);
                        //followObject.obj.transform.rotation = HandModel_R.transform.rotation;
                        //followObject.obj.transform.rotation = Quaternion.Slerp(followObject.obj.transform.rotation, HandModel_R.transform.rotation, smoothness * speed * Time.deltaTime);
                    }
                    else
                    {
                    Debug.Log("2000 F");

                        FollowHand(followObject, ovrSkeleton_L);
                        //followObject.obj.transform.rotation = HandModel_R.transform.rotation;

                        //followObject.obj.transform.rotation = Quaternion.Slerp(followObject.obj.transform.rotation, HandModel_L.transform.rotation, smoothness * speed * Time.deltaTime);

                    }
                }
            }
        }
    }

    public void FollowHand(ObjectsThatFollowHand followObject, OVRSkeleton skeleton)
    {
        if (followObject.AttachedPoint == "wrist") UpdatePosition(followObject,skeleton.Bones[(int)OVRPlugin.BoneId.Hand_WristRoot].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_WristRoot].Transform.rotation);
        if (followObject.AttachedPoint == "index1") UpdatePosition(followObject,  skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index1].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index1].Transform.rotation);
        if (followObject.AttachedPoint == "index2") UpdatePosition(followObject,  skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index2].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index2].Transform.rotation);
        if (followObject.AttachedPoint == "index3") UpdatePosition(followObject,  skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index3].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Index3].Transform.rotation);
        if (followObject.AttachedPoint == "middle1") UpdatePosition(followObject,skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle1].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle1].Transform.rotation);
        if (followObject.AttachedPoint == "middle2") UpdatePosition(followObject,skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle2].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle2].Transform.rotation);
        if (followObject.AttachedPoint == "middle3") UpdatePosition(followObject,skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle3].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Middle3].Transform.rotation);
        if (followObject.AttachedPoint == "pinky0") UpdatePosition(followObject,  skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky0].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky0].Transform.rotation);
        if (followObject.AttachedPoint == "pinky1") UpdatePosition(followObject,  skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky1].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky1].Transform.rotation);
        if (followObject.AttachedPoint == "pinky2") UpdatePosition(followObject,  skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky2].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky2].Transform.rotation);
        if (followObject.AttachedPoint == "pinky3") UpdatePosition(followObject,  skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky3].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Pinky3].Transform.rotation);
        if (followObject.AttachedPoint == "ring1") UpdatePosition(followObject,    skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring1].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring1].Transform.rotation);
        if (followObject.AttachedPoint == "ring2") UpdatePosition(followObject,    skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring2].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring2].Transform.rotation);
        if (followObject.AttachedPoint == "ring3") UpdatePosition(followObject,    skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring3].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Ring3].Transform.rotation);
        if (followObject.AttachedPoint == "thumb0") UpdatePosition(followObject,  skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb0].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb0].Transform.rotation);
        if (followObject.AttachedPoint == "thumb1") UpdatePosition(followObject,  skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb1].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb1].Transform.rotation);
        if (followObject.AttachedPoint == "thumb2") UpdatePosition(followObject,  skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb2].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb2].Transform.rotation);
        if (followObject.AttachedPoint == "thumb3") UpdatePosition(followObject,  skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb3].Transform.position, skeleton.Bones[(int)OVRPlugin.BoneId.Hand_Thumb3].Transform.rotation);
    }

    public void UpdatePosition(ObjectsThatFollowHand followObject, Vector3 targetPosition, Quaternion targetRotation)
    {

        float speed = 10.0f;
        followObject.obj.transform.position = Vector3.MoveTowards(followObject.obj.transform.position, targetPosition, speed * Time.deltaTime);
        //targetRotation *= Quaternion.Euler(0f, 180f, 0f);

        followObject.obj.transform.rotation = targetRotation;
        //followObject.obj.transform.rotation = Quaternion.Slerp(followObject.obj.transform.rotation, targetRotation, smoothness * speed * Time.deltaTime);

    }

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

    public void SpawnVirtualObjects()
    {
        foreach (VirtualObject obj in PlaytestingManager.currentClip.virtualObjects)
        {
            if (obj.isAttached == true)
            {
                GameObject ob = null;
                if (obj.objectName == "Spike") ob = Instantiate(Spike) as GameObject;
                if (obj.objectName == "Shield") ob = Instantiate(Shield) as GameObject;
                if (obj.objectName == "Crate") ob = Instantiate(Crate) as GameObject;
                if (obj.objectName == "Bow") ob = Instantiate(Bow) as GameObject;
                if (obj.objectName == "Arrow") ob = Instantiate(Arrow) as GameObject;

                if(obj.isAttachedToRight == true && ob != null)
                {
                    ob.transform.parent = null;
                    Vector3 forward = HandModel_R.transform.forward;
                    forward.y = 0.0f;
                    ob.transform.forward = forward;
                    FollowObjects.Add(new ObjectsThatFollowHand(ob, true, obj.AttachedBone));
                }
                    
                else
                {
                    ob.transform.parent = null;
                    Vector3 forward = HandModel_L.transform.forward;
                    forward.y = 0.0f;
                    ob.transform.forward = forward;
                    FollowObjects.Add(new ObjectsThatFollowHand(ob, false, obj.AttachedBone));
                }
                    //FollowObjects.Add(new ObjectsThatFollowHand(ob, false, obj.AttachedBone));

            }
            else
            {
                if (obj.objectName == "Spike") Instantiate(Spike, obj.Position, obj.Rotation);
                if (obj.objectName == "Shield") Instantiate(Shield, obj.Position, obj.Rotation);
                if (obj.objectName == "Crate") Instantiate(Crate, obj.Position, obj.Rotation);
                if (obj.objectName == "Bow") Instantiate(Bow, obj.Position, obj.Rotation);
                if (obj.objectName == "Arrow") Instantiate(Arrow, obj.Position, obj.Rotation);
            }
        }
    }

    public void SpawnVFXObjects()
    {
        foreach (VFXObject obj in PlaytestingManager.currentClip.vfxObjects)
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
        Debug.Log("3000A");
        ClearScene();
        Debug.Log("3000B");
        SpawnVirtualObjects();
        Debug.Log("3000C");
        //SpawnVFXObjects();
        Debug.Log("3000D");


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

