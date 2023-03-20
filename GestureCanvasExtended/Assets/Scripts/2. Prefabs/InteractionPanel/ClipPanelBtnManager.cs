using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipPanelBtnManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI BtnTxt;
    public Clip clip;
    public Interaction interaction;
    public void ClipPanelBtnPressed()
    {
        interaction.transitionClip = clip;
        ClipManager.updateConnections = true;
        InteractionBuilderContent.refresh = true;

    }

    public void SetButtonText()
    {
        BtnTxt.text = "" + clip.Id;
    }
}
