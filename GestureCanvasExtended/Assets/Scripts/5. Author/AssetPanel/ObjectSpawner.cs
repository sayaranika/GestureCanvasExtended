using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject Shield;
    [SerializeField] GameObject Spike;
    [SerializeField] GameObject Crate;
    [SerializeField] private Transform spawnPoint;

    public void spawnObject(string objectName)
    {
        if (AvatarPlayback.currentClip != null)
        {
            GameObject prefab = null;
            string objName = "";
            switch (objectName)
            {
                case "Shield":
                    prefab = Shield;
                    objName = "Shield";
                    break;
                case "Spike":
                    prefab = Spike;
                    objName = "Spike";
                    break;
                case "Crate":
                    prefab = Crate;
                    objName = "Crate";
                    break;
            }
            spawnObject(prefab, objName);
        }
    }

    public void spawnObject(GameObject prefab, string objName)
    {
        GameObject obj = Instantiate(prefab) as GameObject;
        obj.transform.position = spawnPoint.transform.position;
        VirtualObject ob = new VirtualObject(obj, objName, obj.transform.position, obj.transform.rotation, obj.transform.localScale);


        obj.GetComponent<ObjectController>().clipRef = AvatarPlayback.currentClip;
        obj.GetComponent<ObjectController>().objectRef = ob;

        AvatarPlayback.currentClip.virtualObjects.Add(ob);
    }
}
