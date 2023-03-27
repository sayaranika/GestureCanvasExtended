using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximitySpawner : MonoBehaviour
{
    [SerializeField] GameObject ProximityTrigger;

    [SerializeField] private Transform spawnPoint;

    public void SpawnProximity()
    {
        if (AvatarPlayback.currentClip != null)
        {
            GameObject obj = Instantiate(ProximityTrigger) as GameObject;
            obj.transform.position = spawnPoint.transform.position;
            ProximityObject p = new ProximityObject(obj, obj.transform.position, obj.transform.rotation, obj.transform.localScale);
            obj.GetComponent<ProximityController>().clip = AvatarPlayback.currentClip;
            obj.GetComponent<ProximityController>().proximityObject = p;

            AvatarPlayback.currentClip.proximityObjects.Add(p);
        }
    }
}
