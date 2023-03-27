using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRadar : MonoBehaviour
{
    public List<GameObject> TriggerObjectsList = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (!TriggerObjectsList.Contains(other.gameObject))
        {
            //add the object to the list
            TriggerObjectsList.Add(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //if the object is in the list
        if (TriggerObjectsList.Contains(other.gameObject))
        {
            //remove it from the list
            TriggerObjectsList.Remove(other.gameObject);
        }
    }

    
}
