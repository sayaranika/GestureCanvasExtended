using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationPanelManager : MonoBehaviour
{
    [SerializeField] GameObject informationPanel;
    [SerializeField] private TMPro.TextMeshProUGUI informationTxt;

    public static bool showInformation = false;
    public static bool hideInformation = false;

    void Start()
    {
        informationPanel.SetActive(false);
    }

    private void Update()
    {
        if (showInformation == true) ShowInformation();
        if (hideInformation == true) HideInformation();
    }

    public void ShowInformation()
    {
        informationPanel.SetActive(true);
    }

    public void HideInformation()
    {
        informationPanel.SetActive(false);
    }
}
