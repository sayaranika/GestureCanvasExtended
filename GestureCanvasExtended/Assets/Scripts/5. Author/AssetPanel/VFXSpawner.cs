using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSpawner : MonoBehaviour
{
    [SerializeField] GameObject DragonPunch;
    [SerializeField] GameObject IceWall;
    [SerializeField] GameObject AppleBombs;
    [SerializeField] GameObject Chidori;
    [SerializeField] GameObject FireSpray;
    [SerializeField] GameObject SnowStar;

    [SerializeField] private Transform spawnPoint;

    public void spawnObject(string objectName)
    {
        if (AvatarPlayback.currentClip != null)
        {
            GameObject prefab = null;
            string objName = "";
            switch (objectName)
            {
                case "DragonPunch":
                    prefab = DragonPunch;
                    objName = "DragonPunch";
                    break;
                case "IceWall":
                    prefab = IceWall;
                    objName = "IceWall";
                    break;
                case "AppleBombs":
                    prefab = AppleBombs;
                    objName = "AppleBombs";
                    break;
                case "Chidori":
                    prefab = Chidori;
                    objName = "Chidori";
                    break;
                case "FireSpray":
                    prefab = FireSpray;
                    objName = "FireSpray";
                    break;
                case "SnowStar":
                    prefab = SnowStar;
                    objName = "SnowStar";
                    break;

            }
            spawnVFX(prefab, objName);
        }
    }


    public void spawnVFX(GameObject prefab, string objName)
    {
        GameObject obj = Instantiate(prefab) as GameObject;
        obj.transform.position = spawnPoint.transform.position;

        VFXObject ob = new VFXObject(obj, objName, obj.transform.position, obj.transform.rotation);


        obj.GetComponent<VFXController>().clipRef = AvatarPlayback.currentClip;
        obj.GetComponent<VFXController>().vfxObjectRef = ob;

        AvatarPlayback.currentClip.vfxObjects.Add(ob);
    }
}
