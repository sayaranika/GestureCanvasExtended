using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigsVisibility : MonoBehaviour
{
    public static bool hideRigs = false;

    [SerializeField] private GameObject ShowRigsButton;
    [SerializeField] private GameObject HideRigsButton;

    [SerializeField] private GameObject manipulableRigs;

    /*private void Update()
    {
        if (hideRigs == true)
        {
            HideRigs();
            hideRigs = false;
        }
    }*/

    private void Start()
    {
        //HideRigs();
    }

    public void ShowRigs()
    {
        ShowRigsButton.SetActive(false);
        HideRigsButton.SetActive(true);

        GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("RigPoint");
        foreach (GameObject obj in ObjectList)
        {
            obj.transform.GetComponent<MeshRenderer>().enabled = true;
            obj.transform.GetComponent<Oculus.Interaction.HandGrab.HandGrabInteractable>().enabled = true;
            obj.transform.GetComponent<Oculus.Interaction.Grabbable>().enabled = true;
        }
    }

    public void HideRigs()
    {
        ShowRigsButton.SetActive(true);
        HideRigsButton.SetActive(false);

        GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("RigPoint");
        foreach (GameObject obj in ObjectList)
        {
            obj.transform.GetComponent<MeshRenderer>().enabled = false;
            obj.transform.GetComponent<Oculus.Interaction.HandGrab.HandGrabInteractable>().enabled = false;
            obj.transform.GetComponent<Oculus.Interaction.Grabbable>().enabled = false;
        }
    }


}
