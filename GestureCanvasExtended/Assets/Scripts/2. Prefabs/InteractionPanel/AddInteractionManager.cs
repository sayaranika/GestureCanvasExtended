using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddInteractionManager : MonoBehaviour
{
    public Clip clipRef;

    public static bool activateButton = false;
    public static bool deactivateButton = false;

    [SerializeField] Button addButton;

    private void Update()
    {
        if (activateButton == true)
        {
            addButton.interactable = true;
            activateButton = false;
        }

        if (deactivateButton == true)
        {
            addButton.interactable = false;
            deactivateButton = false;

        }


    }

    public void AddInteraction()
    {
        Interaction i = new Interaction(clipRef.interactions.Count);
        Interaction defaultInt = clipRef.DefaultInteraction;

        i.isGesture_R = defaultInt.isGesture_R;
        i.isGesture_L = defaultInt.isGesture_L;
        i.isPose_R = defaultInt.isPose_R;
        i.isPose_L = defaultInt.isPose_L;
        i.isTransformConstraint_R = defaultInt.isTransformConstraint_R;
        i.isTransformConstraint_L = defaultInt.isTransformConstraint_L;

        i.expectedGesture_R = defaultInt.expectedGesture_R;
        i.expectedGesture_L = defaultInt.expectedGesture_L;
        i.expectedGesture = defaultInt.expectedGesture;
        i.expectedPose_R = defaultInt.expectedPose_R;
        i.expectedPose_L = defaultInt.expectedPose_L;


        i.transitionClip = defaultInt.transitionClip;

        i.isConditionSetToTrue = defaultInt.isConditionSetToTrue;

        clipRef.interactions.Add(i);

        InteractionBuilderContent.refresh = true;
    }
}
