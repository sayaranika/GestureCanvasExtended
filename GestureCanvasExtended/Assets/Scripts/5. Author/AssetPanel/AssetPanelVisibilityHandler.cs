using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetPanelVisibilityHandler : MonoBehaviour
{
    public static bool hideAssetPanel = false;

    [SerializeField] private ToggleGroup clipToggleGroup;
    [SerializeField] private GameObject AssetPanel;
    [SerializeField] private GameObject AssetOnButton;
    [SerializeField] private GameObject AssetOffButton;
    [SerializeField] private AlertHandler alertHandler;

    [SerializeField] AssetPanelManager assetPanelManager;

    private void Update()
    {
        if (hideAssetPanel == true)
        {
            HideAssetPanel();
            hideAssetPanel = false;
        }
    }

    private void Start()
    {
        HideAssetPanel();
    }

    public void ShowAssetPanel()
    {
        //if no clip is selected, show alert or else turn on interaction builder
        if (clipToggleGroup.GetFirstActiveToggle() != null)
        {
            AssetPanel.SetActive(true);
            assetPanelManager.ShowPropsPanel();
            AssetOnButton.SetActive(true);
            AssetOffButton.SetActive(false);
        }
        else
        {
            StartCoroutine(alertHandler.ShowAlert("select a clip to add assets", 5.0f));
        }
    }

    public void HideAssetPanel()
    {
        AssetPanel.SetActive(false);
        AssetOnButton.SetActive(false);
        AssetOffButton.SetActive(true);
    }
}
