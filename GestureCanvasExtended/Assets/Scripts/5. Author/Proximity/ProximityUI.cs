using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityUI : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] ProximityController proximityController;
    public bool isUIActive = true;
    public Vector3 previousScale;
    public Vector3 currentScale;

    private void Start()
    {
        previousScale = transform.localScale;
        currentScale = transform.localScale;
    }

    private void Update()
    {
        currentScale = transform.localScale;

        if (proximityController.proximityObject.ProximityConfigured == ProximityType.Touch)
        {
            UI.SetActive(false);
        }
        else
        {
            if (Vector3.Distance(previousScale, currentScale) != 0.0f)
            {
                if (isUIActive == true)
                {
                    UI.SetActive(false);
                    isUIActive = false;
                }
            }
            else
            {
                if (isUIActive == false)
                {
                    UI.SetActive(true);
                    isUIActive = true;
                }
            }
        }
        previousScale = currentScale;

    }
}
