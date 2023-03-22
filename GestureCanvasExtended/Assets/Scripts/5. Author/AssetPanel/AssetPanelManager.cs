using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetPanelManager : MonoBehaviour
{
    [SerializeField] GameObject PropsPanel;
    [SerializeField] GameObject AnimationPanel;
    [SerializeField] GameObject VFXPanel;

    public void ShowPropsPanel()
    {
        PropsPanel.SetActive(true);
        AnimationPanel.SetActive(false);
        VFXPanel.SetActive(false);
    }

    public void ShowAnimationPanel()
    {
        PropsPanel.SetActive(false);
        AnimationPanel.SetActive(true);
        VFXPanel.SetActive(false);
    }

    public void ShowVFXPanel()
    {
        PropsPanel.SetActive(false);
        AnimationPanel.SetActive(false);
        VFXPanel.SetActive(true);
    }
}
