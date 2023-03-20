using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionBuilderContent : MonoBehaviour
{
    [SerializeField] private ToggleGroup clipToggleGroup;
    [SerializeField] private Transform interactionContainer;

    [Header("Prefabs to Instantiate")]
    [SerializeField] GameObject addInteractionButton;
    [SerializeField] GameObject interactionPanelPrefab;

    public static bool refresh = false;

    public static List<GameObject> interactionPanelList = new List<GameObject>();
    public static List<GameObject> addInteractionButtonList = new List<GameObject>();

    private void Update()
    {
        if (refresh == true)
        {
            Refresh();
            refresh = false;
        }
    }

    public void ClearInteractionPanel()
    {
        foreach (GameObject o in interactionPanelList)
        {
            Destroy(o);
        }
        interactionPanelList.Clear();

        foreach (GameObject o in addInteractionButtonList)
        {
            Destroy(o);
        }
        addInteractionButtonList.Clear();
    }

    public void Refresh()
    {
        ClearInteractionPanel();
        if (clipToggleGroup.GetFirstActiveToggle() != null)
        {
            if (AvatarPlayback.currentClip != null)
            {
                List<Interaction> interactions = AvatarPlayback.currentClip.interactions;

                if (interactions.Count > 0)
                {
                    //add interaction panel for each interaction in the list
                    foreach (Interaction i in interactions)
                    {
                        GameObject interactionPanel = Instantiate(interactionPanelPrefab, interactionContainer);
                        interactionPanel.GetComponent<InteractionPanelManager>().clipRef = AvatarPlayback.currentClip;
                        interactionPanel.GetComponent<InteractionPanelManager>().interactionRef = i;
                        interactionPanel.GetComponent<InteractionPanelManager>().SetPanelContents();
                        interactionPanelList.Add(interactionPanel);
                    }
                }

                //add button for adding interaction

                GameObject addInteraction = Instantiate(addInteractionButton, interactionContainer);
                addInteraction.GetComponent<AddInteractionManager>().clipRef = AvatarPlayback.currentClip;
                addInteractionButtonList.Add(addInteraction);
            }
            else InteractionVisibilityHandler.hideInteractionBuilder = true;
        }
        else InteractionVisibilityHandler.hideInteractionBuilder = true;

    }
}
