using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{
    [SerializeField] GameObject SpawnedObject;
    [SerializeField] GameObject HandModel;
    [SerializeField] OVRSkeleton ovrSkeleton;
    GameObject ob;
    [SerializeField] GameObject bow;

    public float smoothness = 0.5f; // Controls the speed of interpolation
    public float distanceFactor = 0.1f; // Controls the distance factor
    public float speed = 10.0f;

    private void Start()
    {
        ob = Instantiate(SpawnedObject);
        ob.transform.parent = null;
        ob.transform.position = new Vector3(0,1,3);
       

        Vector3 forward = HandModel.transform.forward;
        forward.y = 0.0f;
        ob.transform.forward = forward;

    }

    private void Update()
    {
        Vector3 targetPosition = HandModel.transform.position;
        Quaternion targetRotation = HandModel.transform.rotation;

        ob.transform.position = Vector3.MoveTowards(ob.transform.position, targetPosition, speed * Time.deltaTime);
        
        ob.transform.rotation = Quaternion.Slerp(ob.transform.rotation, targetRotation, smoothness * speed * Time.deltaTime);

    }
}
