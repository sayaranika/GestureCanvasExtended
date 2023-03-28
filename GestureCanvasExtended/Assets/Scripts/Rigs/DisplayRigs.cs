using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRigs : MonoBehaviour
{
    public GameObject spherePrefab;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    public static bool displayRigs = false;
    public static bool hideRigs = false;
    public List<GameObject> rigsPoint = new List<GameObject>();

    private void Update()
    {
        if(displayRigs == true)
        {
            ShowRigs();
            displayRigs = false;
        }
        if(hideRigs == true)
        {
            HideRigs();
            hideRigs = false;
        }
    }

    void ShowRigs()
    {
        Transform[] bones = skinnedMeshRenderer.bones;

        foreach (Transform bone in bones)
        {
            //GameObject sphere = Instantiate(spherePrefab, bone.position, bone.rotation);
            //sphere.transform.parent = bone;
            

            GameObject sphere = Instantiate(spherePrefab, bone.position, bone.rotation);
            sphere.transform.parent = bone;
            rigsPoint.Add(sphere);
            //sphere.transform.localPosition = Vector3.zero;
            //sphere.transform.localRotation = Quaternion.identity;
        }
    }

    void HideRigs()
    {
        Debug.Log("4000A: Destroying rigs");
        foreach(GameObject item in rigsPoint)
        {
            Debug.Log("4000B: Destroying rigs");

            Destroy(item);
        }
        rigsPoint.Clear();
    }
}
