using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityController : MonoBehaviour
{
    [SerializeField] GameObject TouchButton;
    [SerializeField] GameObject DistanceButton;
    [SerializeField] TouchRadar touchRadar;

    [SerializeField] GameObject visualizer;

    [SerializeField] Oculus.Interaction.HandGrab.HandGrabInteractable handGrabInteractable;
    [SerializeField] Oculus.Interaction.Grabbable grabbable;
    [SerializeField] Oculus.Interaction.PhysicsGrabbable physicsGrabbable;
    [SerializeField] Oculus.Interaction.OneGrabFreeTransformer oneGrabFreeTransformer;
    [SerializeField] Oculus.Interaction.TwoGrabFreeTransformer twoGrabFreeTransformer;

    public Clip clip;
    public ProximityObject proximityObject;

    private void OnDestroy()
    {
        proximityObject.Position = gameObject.transform.localPosition;
        proximityObject.Rotation = gameObject.transform.localRotation;
        proximityObject.Scale = gameObject.transform.localScale;
    }

    private void Update()
    {
        if(proximityObject.attachmentType == AttachmentType.Object)
        {
            handGrabInteractable.enabled = false;
            grabbable.enabled = false;
            physicsGrabbable.enabled = false;
            oneGrabFreeTransformer.enabled = false;
            oneGrabFreeTransformer.enabled = false;
        }
    }

    private void Start()
    {
        proximityObject.proximityType = ProximityType.Touch;
        DistanceButton.SetActive(false);
        TouchButton.SetActive(true);
    }

    #region RECORD CONDITION
    public void RecordProximity()
    {
        RecordLabelHandler recordLabelHandler = GameObject.Find("UIManager").GetComponent<RecordLabelHandler>();
        recordLabelHandler.ShowRecordLabel();

        //if (proximityObject.proximityType == ProximityType.Touch)
            StartCoroutine(RecordTouchCondition(4.0f));
    }

    public IEnumerator RecordTouchCondition(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        foreach (GameObject triggerObject in touchRadar.TriggerObjectsList)
        {
            if(triggerObject.name.StartsWith("b_r"))
            {
                string touchPointName = triggerObject.name.Substring(4);
                if (touchPointName.StartsWith("index") && !proximityObject.TouchPoints_R.Contains("Index"))
                    proximityObject.TouchPoints_R.Add("Index");
                else if (touchPointName.StartsWith("middle") && !proximityObject.TouchPoints_R.Contains("Middle"))
                    proximityObject.TouchPoints_R.Add("Middle");
                else if (touchPointName.StartsWith("ring") && !proximityObject.TouchPoints_R.Contains("Ring"))
                    proximityObject.TouchPoints_R.Add("Ring");
                else if (touchPointName.StartsWith("thumb") && !proximityObject.TouchPoints_R.Contains("Thumb"))
                    proximityObject.TouchPoints_R.Add("Thumb");
                else if (touchPointName.StartsWith("pinky") && !proximityObject.TouchPoints_R.Contains("Pinky"))
                    proximityObject.TouchPoints_R.Add("Pinky");
            }
            else if (triggerObject.name.StartsWith("b_l"))
            {
                string touchPointName = triggerObject.name.Substring(4);
                if (touchPointName.StartsWith("index") && !proximityObject.TouchPoints_L.Contains("Index"))
                    proximityObject.TouchPoints_L.Add("Index");
                else if (touchPointName.StartsWith("middle") && !proximityObject.TouchPoints_L.Contains("Middle"))
                    proximityObject.TouchPoints_L.Add("Middle");
                else if (touchPointName.StartsWith("ring") && !proximityObject.TouchPoints_L.Contains("Ring"))
                    proximityObject.TouchPoints_L.Add("Ring");
                else if (touchPointName.StartsWith("thumb") && !proximityObject.TouchPoints_L.Contains("Thumb"))
                    proximityObject.TouchPoints_L.Add("Thumb");
                else if (touchPointName.StartsWith("pinky") && !proximityObject.TouchPoints_L.Contains("Pinky"))
                    proximityObject.TouchPoints_L.Add("Pinky");
            }
            else
            {
                Debug.Log("2000A: " + triggerObject.name);
                if (triggerObject.name == "ArrowAuthored")
                {
                    Debug.Log("2000B: " + triggerObject.transform.parent.gameObject.name);

                    proximityObject.AttachedGameObject = triggerObject.transform.parent.gameObject;
                    proximityObject.AttachedGameObjectName = triggerObject.transform.parent.gameObject.name;
                    proximityObject.attachmentType = AttachmentType.Object;
                }
                else if(triggerObject.CompareTag("SpawnedObject"))
                {
                    proximityObject.AttachedGameObject = triggerObject;
                    proximityObject.AttachedGameObjectName = triggerObject.name;
                    proximityObject.attachmentType = AttachmentType.Object;
                }
                
            }
        }

        proximityObject.Print();


        proximityObject.ProximityConfigured = ProximityType.Touch;
        if(proximityObject.attachmentType == AttachmentType.Object)
        {
            gameObject.transform.parent = proximityObject.AttachedGameObject.transform;
            
        }

        Interaction i = new Interaction(clip.interactions.Count);
        //spawn the visualizers and attach them if needed;
        foreach (string item in proximityObject.TouchPoints_R)
        {
            GameObject vis = Instantiate(visualizer);
            vis.GetComponent<VisualizerController>().AttachedBone = item;
            vis.GetComponent<VisualizerController>().handedness = Handedness.Right;
            vis.GetComponent<VisualizerController>().isSet = true;

            i.isTouch_R = true;
            i.TouchPoints_R.Add(item);
        }

        foreach (string item in proximityObject.TouchPoints_L)
        {
            GameObject vis = Instantiate(visualizer);
            vis.GetComponent<VisualizerController>().AttachedBone = item;
            vis.GetComponent<VisualizerController>().handedness = Handedness.Left;
            vis.GetComponent<VisualizerController>().isSet = true;

            i.isTouch_L = true;
            i.TouchPoints_L.Add(item);
        }

        i.triggerPosition = gameObject.transform.localPosition;
        i.triggerRotation = gameObject.transform.localRotation;
        i.triggerScale = gameObject.transform.localScale;

        i.isGesture_L = false;
        i.isGesture_R = false;
        i.isPose_R = false;
        i.isPose_L = false;

        i.triggerParent = proximityObject.AttachedGameObjectName;

        clip.interactions.Add(i);
        InteractionBuilderContent.refresh = true;

        RecordLabelHandler recordLabelHandler = GameObject.Find("UIManager").GetComponent<RecordLabelHandler>();
        recordLabelHandler.HideRecordLabel();
    }

    #endregion


    #region PROXIMITY TYPE
    public void ActivateDistance()
    {
        DistanceButton.SetActive(true);
        TouchButton.SetActive(false);

        proximityObject.proximityType = ProximityType.Distance;
    }

    public void ActivateTouch()
    {
        DistanceButton.SetActive(false);
        TouchButton.SetActive(true);

        proximityObject.proximityType = ProximityType.Touch;
    }
    #endregion
}
