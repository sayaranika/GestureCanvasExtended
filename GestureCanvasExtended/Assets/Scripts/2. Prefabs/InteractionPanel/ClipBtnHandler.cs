using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClipBtnHandler : MonoBehaviour
{
    public Clip clip;
    public Interaction interaction;
    public GameObject clipBtn;
    [SerializeField] Text btnText;
    [SerializeField] GameObject btn;
    public void AssociateClip(Clip clip)
    {
        this.clip = clip;
        btnText.text = "Clip " + clip.Id;
    }

    public void Detach()
    {
        interaction.transitionClip = null;

        InteractionBuilderContent.refresh = true;
        ClipManager.updateConnections = true;
    }
}
