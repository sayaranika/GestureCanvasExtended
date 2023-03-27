using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour
{
    [SerializeField] GameObject ProximityTrigger;
    [SerializeField] GameObject Shield;
    [SerializeField] GameObject Crate;
    [SerializeField] GameObject Spike;
    [SerializeField] GameObject Bow;
    [SerializeField] GameObject Arrow;

    [SerializeField] GameObject DragonPunch;
    [SerializeField] GameObject IceWall;
    [SerializeField] GameObject AppleBombs;
    [SerializeField] GameObject Chidori;
    [SerializeField] GameObject FireSpray;
    [SerializeField] GameObject SnowStar;

    


    public void Load()
    {
        foreach (Clip clip in ClipHandler.ClipList)
        {
            #region VFX
            if (clip.vfxObjects.Count > 0)
            {
                foreach (VFXObject vfxObject in clip.vfxObjects)
                {
                    if (vfxObject.objectName == "DragonPunch")
                    {
                        GameObject obj = Instantiate(DragonPunch, vfxObject.Position, vfxObject.Rotation) as GameObject;
                        vfxObject.vfxRef = obj;
                        obj.GetComponent<VFXController>().clipRef = clip;
                        obj.GetComponent<VFXController>().vfxObjectRef = vfxObject;


                    }

                    if (vfxObject.objectName == "IceWall")
                    {
                        GameObject obj = Instantiate(IceWall, vfxObject.Position, vfxObject.Rotation) as GameObject;
                        vfxObject.vfxRef = obj;
                        obj.GetComponent<VFXController>().clipRef = clip;
                        obj.GetComponent<VFXController>().vfxObjectRef = vfxObject;


                    }

                    if (vfxObject.objectName == "AppleBombs")
                    {
                        GameObject obj = Instantiate(AppleBombs, vfxObject.Position, vfxObject.Rotation) as GameObject;
                        vfxObject.vfxRef = obj;
                        obj.GetComponent<VFXController>().clipRef = clip;
                        obj.GetComponent<VFXController>().vfxObjectRef = vfxObject;


                    }

                    if (vfxObject.objectName == "Chidori")
                    {
                        GameObject obj = Instantiate(Chidori, vfxObject.Position, vfxObject.Rotation) as GameObject;
                        vfxObject.vfxRef = obj;
                        obj.GetComponent<VFXController>().clipRef = clip;
                        obj.GetComponent<VFXController>().vfxObjectRef = vfxObject;


                    }

                    if (vfxObject.objectName == "FireSpray")
                    {
                        GameObject obj = Instantiate(FireSpray, vfxObject.Position, vfxObject.Rotation) as GameObject;
                        vfxObject.vfxRef = obj;
                        obj.GetComponent<VFXController>().clipRef = clip;
                        obj.GetComponent<VFXController>().vfxObjectRef = vfxObject;


                    }

                    if (vfxObject.objectName == "SnowStar")
                    {
                        GameObject obj = Instantiate(SnowStar, vfxObject.Position, vfxObject.Rotation) as GameObject;
                        vfxObject.vfxRef = obj;
                        obj.GetComponent<VFXController>().clipRef = clip;
                        obj.GetComponent<VFXController>().vfxObjectRef = vfxObject;


                    }
                }

            }
            #endregion

            #region Objects
            if (clip.virtualObjects.Count > 0)
            {
                foreach (VirtualObject virtualObject in clip.virtualObjects)
                {
                    if (virtualObject.objectName == "Shield")
                    {
                        GameObject obj = Instantiate(Shield, virtualObject.Position, virtualObject.Rotation) as GameObject;
                        obj.transform.localScale = virtualObject.Scale;
                        virtualObject.objectRef = obj;
                        obj.GetComponent<ObjectController>().clipRef = clip;
                        obj.GetComponent<ObjectController>().objectRef = virtualObject;
                    }

                    if (virtualObject.objectName == "Crate")
                    {
                        GameObject obj = Instantiate(Crate, virtualObject.Position, virtualObject.Rotation) as GameObject;
                        obj.transform.localScale = virtualObject.Scale;
                        virtualObject.objectRef = obj;
                        obj.GetComponent<ObjectController>().clipRef = clip;
                        obj.GetComponent<ObjectController>().objectRef = virtualObject;
                    }

                    if (virtualObject.objectName == "Spike")
                    {
                        GameObject obj = Instantiate(Spike, virtualObject.Position, virtualObject.Rotation) as GameObject;
                        obj.transform.localScale = virtualObject.Scale;
                        virtualObject.objectRef = obj;
                        obj.GetComponent<ObjectController>().clipRef = clip;
                        obj.GetComponent<ObjectController>().objectRef = virtualObject;
                    }

                    if (virtualObject.objectName == "Bow")
                    {
                        GameObject obj = Instantiate(Bow, virtualObject.Position, virtualObject.Rotation) as GameObject;
                        obj.transform.localScale = virtualObject.Scale;
                        virtualObject.objectRef = obj;
                        obj.GetComponent<ObjectController>().clipRef = clip;
                        obj.GetComponent<ObjectController>().objectRef = virtualObject;
                    }

                    if (virtualObject.objectName == "Arrow")
                    {
                        GameObject obj = Instantiate(Arrow, virtualObject.Position, virtualObject.Rotation) as GameObject;
                        obj.transform.localScale = virtualObject.Scale;
                        virtualObject.objectRef = obj;
                        obj.GetComponent<ObjectController>().clipRef = clip;
                        obj.GetComponent<ObjectController>().objectRef = virtualObject;
                    }
                }
            }
            #endregion

            #region TRIGGERS
            if(clip.proximityObjects.Count > 0)
            {
                foreach(ProximityObject p in clip.proximityObjects)
                {
                    GameObject obj = Instantiate(ProximityTrigger) as GameObject;
                    p.proximityRef = obj;

                    obj.GetComponent<ProximityController>().clip = clip;
                    obj.GetComponent<ProximityController>().proximityObject = p;
                    
                    

                    if(p.AttachedGameObjectName == "")
                    {
                        obj.transform.position = p.Position;
                        obj.transform.rotation = p.Rotation;
                        obj.transform.localScale = p.Scale;
                    }
                    else
                    {
                        obj.transform.parent = GameObject.Find(p.AttachedGameObjectName).transform;
                        obj.transform.localPosition = p.Position;
                        obj.transform.localRotation = p.Rotation;
                        obj.transform.localScale = p.Scale;
                    }
                    
                }
            }
            #endregion
        }
    }
}
