using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionVisibilityHandler : MonoBehaviour
{
    public static bool isInteractionBuilderOpen = false;
    public static bool hideInteractionBuilder = false;
    public static bool showInteractionBuilder = false;

    [SerializeField] private ToggleGroup clipToggleGroup;
    [SerializeField] private GameObject InteractionBuilder;
    [SerializeField] private GameObject InteractionBuilderOnButton;
    [SerializeField] private GameObject InteractionBuilderOffButton;
    [SerializeField] private AlertHandler alertHandler;

    private void Update()
    {
        if (hideInteractionBuilder == true)
        {
            HideInteractionBuilder();
            hideInteractionBuilder = false;
        }

        if (showInteractionBuilder == true)
        {
            ShowInteractionBuilder();
            showInteractionBuilder = false;
        }
    }

    private void Start()
    {
        HideInteractionBuilder();
    }

    public void ShowInteractionBuilder()
    {
        //if no clip is selected, show alert or else turn on interaction builder
        if (clipToggleGroup.GetFirstActiveToggle() != null)
        {
            isInteractionBuilderOpen = true;
            InteractionBuilder.SetActive(true);
            InteractionBuilderOnButton.SetActive(true);
            InteractionBuilderOffButton.SetActive(false);
        }
        else
        {
            isInteractionBuilderOpen = false;
            StartCoroutine(alertHandler.ShowAlert("select a clip to open the interaction builder", 2.0f));
        }
    }

    public void HideInteractionBuilder()
    {
        InteractionBuilder.SetActive(false);
        InteractionBuilderOnButton.SetActive(false);
        InteractionBuilderOffButton.SetActive(true);

        isInteractionBuilderOpen = false;
    }


}
