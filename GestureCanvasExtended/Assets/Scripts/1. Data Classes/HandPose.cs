using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

[Serializable]
public class HandPose 
{
    public int HandPoseId { get; private set; }
    [JsonIgnore] public int ParentConfigId { get; set; } //hand pose id with same config
    [JsonIgnore] public int ParentTransformId { get; set; } //hand pose id with same config
    [JsonIgnore] public List<int> ChildTransforms { get; set; } //the different transforms of this config

    //////////////////////////////////              CURL                //////////////////////////////////
    public bool CurlOpenIndex { get; private set; }
    public bool CurlOpenMiddle { get; private set; }
    public bool CurlOpenRing { get; private set; }
    public bool CurlOpenPinky { get; private set; }
    public bool CurlOpenThumb { get; private set; }
    public bool CurlClosedIndex { get; private set; }
    public bool CurlClosedMiddle { get; private set; }
    public bool CurlClosedRing { get; private set; }
    public bool CurlClosedPinky { get; private set; }
    public bool CurlClosedThumb { get; private set; }
    public bool CurlNeutralIndex { get; private set; }
    public bool CurlNeutralMiddle { get; private set; }
    public bool CurlNeutralRing { get; private set; }
    public bool CurlNeutralPinky { get; private set; }
    public bool CurlNeutralThumb { get; private set; }

    //////////////////////////////////             FLEXION              //////////////////////////////////

    public bool FlexionOpenIndex { get; private set; }
    public bool FlexionOpenMiddle { get; private set; }
    public bool FlexionOpenRing { get; private set; }
    public bool FlexionOpenPinky { get; private set; }
    public bool FlexionClosedIndex { get; private set; }
    public bool FlexionClosedMiddle { get; private set; }
    public bool FlexionClosedRing { get; private set; }
    public bool FlexionClosedPinky { get; private set; }
    public bool FlexionNeutralIndex { get; private set; }
    public bool FlexionNeutralMiddle { get; private set; }
    public bool FlexionNeutralRing { get; private set; }
    public bool FlexionNeutralPinky { get; private set; }

    //////////////////////////////////             ABDUCTION              //////////////////////////////////

    public bool AbductionOpenIndex { get; private set; }
    public bool AbductionOpenMiddle { get; private set; }
    public bool AbductionOpenRing { get; private set; }
    public bool AbductionOpenThumb { get; private set; }
    public bool AbductionClosedIndex { get; private set; }
    public bool AbductionClosedMiddle { get; private set; }
    public bool AbductionClosedRing { get; private set; }
    public bool AbductionClosedThumb { get; private set; }

    //////////////////////////////////             OPPOSITION              //////////////////////////////////

    public bool OppositionTouchingIndex { get; private set; }
    public bool OppositionTouchingMiddle { get; private set; }
    public bool OppositionTouchingRing { get; private set; }
    public bool OppositionTouchingPinky { get; private set; }
    public bool OppositionNearIndex { get; private set; }
    public bool OppositionNearMiddle { get; private set; }
    public bool OppositionNearRing { get; private set; }
    public bool OppositionNearPinky { get; private set; }
    public bool OppositionNoneIndex { get; private set; }
    public bool OppositionNoneMiddle { get; private set; }
    public bool OppositionNoneRing { get; private set; }
    public bool OppositionNonePinky { get; private set; }


    ////////////////////////////////// INFORMATION FOR TRANSFORM RECOGNIZER //////////////////////////////////

    public bool WristUp { get; private set; }
    public bool WristDown { get; private set; }
    public bool PalmUp { get; private set; }
    public bool PalmDown { get; private set; }
    public bool PalmTowardsFace { get; private set; }
    public bool PalmAwayFromFace { get; private set; }
    public bool FingersUp { get; private set; }
    public bool FingersDown { get; private set; }

    public HandPose(int HandPoseId,
    bool CurlOpenIndex,
    bool CurlOpenMiddle,
    bool CurlOpenRing,
    bool CurlOpenPinky,
    bool CurlOpenThumb,
    bool CurlClosedIndex,
    bool CurlClosedMiddle,
    bool CurlClosedRing,
    bool CurlClosedPinky,
    bool CurlClosedThumb,
    bool CurlNeutralIndex,
    bool CurlNeutralMiddle,
    bool CurlNeutralRing,
    bool CurlNeutralPinky,
    bool CurlNeutralThumb,
    bool FlexionOpenIndex,
    bool FlexionOpenMiddle,
    bool FlexionOpenRing,
    bool FlexionOpenPinky,
    bool FlexionClosedIndex,
    bool FlexionClosedMiddle,
    bool FlexionClosedRing,
    bool FlexionClosedPinky,
    bool FlexionNeutralIndex,
    bool FlexionNeutralMiddle,
    bool FlexionNeutralRing,
    bool FlexionNeutralPinky,
    bool AbductionOpenIndex,
    bool AbductionOpenMiddle,
    bool AbductionOpenRing,
    bool AbductionOpenThumb,
    bool AbductionClosedIndex,
    bool AbductionClosedMiddle,
    bool AbductionClosedRing,
    bool AbductionClosedThumb,
    bool OppositionTouchingIndex,
    bool OppositionTouchingMiddle,
    bool OppositionTouchingRing,
    bool OppositionTouchingPinky,
    bool OppositionNearIndex,
    bool OppositionNearMiddle,
    bool OppositionNearRing,
    bool OppositionNearPinky,
    bool OppositionNoneIndex,
    bool OppositionNoneMiddle,
    bool OppositionNoneRing,
    bool OppositionNonePinky,
    bool WristUp,
    bool WristDown,
    bool PalmUp,
    bool PalmDown,
    bool PalmTowardsFace,
    bool PalmAwayFromFace,
    bool FingersUp,
    bool FingersDown
        )
    {
        this.HandPoseId = HandPoseId;
        this.CurlOpenIndex = CurlOpenIndex;
        this.CurlOpenMiddle = CurlOpenMiddle;
        this.CurlOpenRing = CurlOpenRing;
        this.CurlOpenPinky = CurlOpenPinky;
        this.CurlOpenThumb = CurlOpenThumb;
        this.CurlClosedIndex = CurlClosedIndex;
        this.CurlClosedMiddle = CurlClosedMiddle;
        this.CurlClosedRing = CurlClosedRing;
        this.CurlClosedPinky = CurlClosedPinky;
        this.CurlClosedThumb = CurlClosedThumb;
        this.CurlNeutralIndex = CurlNeutralIndex;
        this.CurlNeutralMiddle = CurlNeutralMiddle;
        this.CurlNeutralRing = CurlNeutralRing;
        this.CurlNeutralPinky = CurlNeutralPinky;
        this.CurlNeutralThumb = CurlNeutralThumb;
        this.FlexionOpenIndex = FlexionOpenIndex;
        this.FlexionOpenMiddle = FlexionOpenMiddle;
        this.FlexionOpenRing = FlexionOpenRing;
        this.FlexionOpenPinky = FlexionOpenPinky;
        this.FlexionClosedIndex = FlexionClosedIndex;
        this.FlexionClosedMiddle = FlexionClosedMiddle;
        this.FlexionClosedRing = FlexionClosedRing;
        this.FlexionClosedPinky = FlexionClosedPinky;
        this.FlexionNeutralIndex = FlexionNeutralIndex;
        this.FlexionNeutralMiddle = FlexionNeutralMiddle;
        this.FlexionNeutralRing = FlexionNeutralRing;
        this.FlexionNeutralPinky = FlexionNeutralPinky;
        this.AbductionOpenIndex = AbductionOpenIndex;
        this.AbductionOpenMiddle = AbductionOpenMiddle;
        this.AbductionOpenRing = AbductionOpenRing;
        this.AbductionOpenThumb = AbductionOpenThumb;
        this.AbductionClosedIndex = AbductionClosedIndex;
        this.AbductionClosedMiddle = AbductionClosedMiddle;
        this.AbductionClosedRing = AbductionClosedRing;
        this.AbductionClosedThumb = AbductionClosedThumb;
        this.OppositionTouchingIndex = OppositionTouchingIndex;
        this.OppositionTouchingMiddle = OppositionTouchingMiddle;
        this.OppositionTouchingRing = OppositionTouchingRing;
        this.OppositionTouchingPinky = OppositionTouchingPinky;
        this.OppositionNearIndex = OppositionNearIndex;
        this.OppositionNearMiddle = OppositionNearMiddle;
        this.OppositionNearRing = OppositionNearRing;
        this.OppositionNearPinky = OppositionNearPinky;
        this.OppositionNoneIndex = OppositionNoneIndex;
        this.OppositionNoneMiddle = OppositionNoneMiddle;
        this.OppositionNoneRing = OppositionNoneRing;
        this.OppositionNonePinky = OppositionNonePinky;
        this.WristUp = WristUp;
        this.WristDown = WristDown;
        this.PalmUp = PalmUp;
        this.PalmDown = PalmDown;
        this.PalmTowardsFace = PalmTowardsFace;
        this.PalmAwayFromFace = PalmAwayFromFace;
        this.FingersUp = FingersUp;
        this.FingersDown = FingersDown;

        this.ParentConfigId = -1;
        this.ChildTransforms = new List<int>();
        this.ParentTransformId = -1;
    }

    #region IS HAND POSE EQUAL?
    public static bool IsEqual(HandPose template, HandPose realtime)
    {
        bool isEqual = false;

        if(template == null)
        {
            Debug.Log("5000: template is null");
            return isEqual;
        }

        if (realtime == null)
        {
            Debug.Log("5000: realtime is null");
            return isEqual;
        }

        #region MATCHING INDEX STATE

        //curl 
        if (template.CurlOpenIndex == true)
        {
            if (realtime.CurlOpenIndex == true || realtime.CurlNeutralIndex == true) isEqual = true;
            else return false;
        }
        else if (template.CurlClosedIndex == true)
        {
            if (realtime.CurlClosedIndex == true || realtime.CurlNeutralIndex == true) isEqual = true;
            else return false;
        }
        else if (template.CurlNeutralIndex == true) //not sure about this
        {
            /*if (realtime.CurlNeutralIndex == true || realtime.CurlOpenIndex == true || realtime.CurlClosedIndex == true) isEqual = true;
            else return false;*/


            if (realtime.CurlNeutralIndex == true || realtime.CurlOpenIndex == true) isEqual = true;
            else return false;
        }

        //flexion
        if (template.FlexionOpenIndex == true)
        {
            if (realtime.FlexionOpenIndex == true || realtime.CurlNeutralIndex == true) isEqual = true;
            else return false;
        }
        else if (template.FlexionClosedIndex == true)
        {
            if (realtime.FlexionClosedIndex == true || realtime.FlexionNeutralIndex == true) isEqual = true;
            else return false;
        }
        else if (template.FlexionNeutralIndex == true)
        {
            if (realtime.FlexionNeutralIndex == true || realtime.FlexionClosedIndex == true) isEqual = true;
            else return false;
        }


        //abduction
        if (template.FlexionOpenIndex == true && template.FlexionOpenMiddle == true)
        {
            if (template.AbductionOpenIndex == true)
            {
                if (realtime.AbductionOpenIndex == true) isEqual = true;
                else return false;
            }
            else if (template.AbductionClosedIndex == true)
            {
                if (realtime.AbductionClosedIndex == true) isEqual = true;
                else return false;
            }
        }

        //opposition
        if (template.OppositionTouchingIndex == true)
        {
            if (realtime.OppositionTouchingIndex == true) isEqual = true;
            else return false;
        }
        #endregion

        #region MATCHING MIDDLE STATE

        //curl 
        if (template.CurlOpenMiddle == true)
        {
            if (realtime.CurlOpenMiddle == true || realtime.CurlNeutralMiddle == true) isEqual = true;
            else return false;
        }
        else if (template.CurlClosedMiddle == true)
        {
            if (realtime.CurlClosedMiddle == true || realtime.CurlNeutralMiddle == true) isEqual = true;
            else return false;
        }
        else if (template.CurlNeutralMiddle == true)
        {
            if (realtime.CurlNeutralMiddle == true || realtime.CurlOpenMiddle == true) isEqual = true;
            else return false;
        }

        //flexion
        if (template.FlexionOpenMiddle == true)
        {
            if (realtime.FlexionOpenMiddle == true || realtime.FlexionNeutralMiddle == true) isEqual = true;
            else return false;
        }
        else if (template.FlexionClosedMiddle == true)
        {
            if (realtime.FlexionClosedMiddle == true || realtime.FlexionNeutralMiddle == true) isEqual = true;
            else return false;
        }
        else if (template.FlexionNeutralMiddle == true)
        {
            if (realtime.FlexionNeutralMiddle == true || realtime.FlexionClosedMiddle == true) isEqual = true;
            else return false;
        }


        //abduction
        if (template.FlexionOpenMiddle == true && template.FlexionOpenRing == true)
        {
            if (template.AbductionOpenMiddle == true)
            {
                if (realtime.AbductionOpenMiddle == true) isEqual = true;
                else return false;
            }
            else if (template.AbductionClosedMiddle == true)
            {
                if (realtime.AbductionClosedMiddle == true) isEqual = true;
                else return false;
            }
        }

        //opposition
        if (template.OppositionTouchingMiddle == true)
        {
            if (realtime.OppositionTouchingMiddle == true) isEqual = true;
            else return false;
        }
        #endregion

        #region MATCHING RING STATE

        //curl 
        if (template.CurlOpenRing == true)
        {
            if (realtime.CurlOpenRing == true || realtime.CurlNeutralRing == true) isEqual = true;
            else return false;
        }
        else if (template.CurlClosedRing == true)
        {
            if (realtime.CurlClosedRing == true || realtime.CurlNeutralRing == true) isEqual = true;
            else return false;
        }
        else if (template.CurlNeutralRing == true)
        {
            if (realtime.CurlNeutralRing == true || realtime.CurlOpenRing == true) isEqual = true;
            else return false;
        }

        //flexion
        if (template.FlexionOpenRing == true)
        {
            if (realtime.FlexionOpenRing == true || realtime.FlexionNeutralRing == true) isEqual = true;
            else return false;
        }
        else if (template.FlexionClosedRing == true)
        {
            if (realtime.FlexionClosedRing == true || realtime.FlexionNeutralRing == true) isEqual = true;
            else return false;
        }
        else if (template.FlexionNeutralRing == true)
        {
            if (realtime.FlexionNeutralRing == true || realtime.FlexionClosedRing == true) isEqual = true;
            else return false;
        }


        //abduction
        if (template.FlexionOpenRing == true && template.FlexionOpenPinky == true)
        {
            if (template.AbductionOpenRing == true)
            {
                if (realtime.AbductionOpenRing == true) isEqual = true;
                else return false;
            }
            else if (template.AbductionClosedRing == true)
            {
                if (realtime.AbductionClosedRing == true) isEqual = true;
                else return false;
            }
        }

        //opposition
        if (template.OppositionTouchingRing == true)
        {
            if (realtime.OppositionTouchingRing == true) isEqual = true;
            else return false;
        }
        #endregion

        #region MATCHING PINKY STATE

        //curl 
        if (template.CurlOpenPinky == true)
        {
            if (realtime.CurlOpenPinky == true || realtime.CurlNeutralPinky == true) isEqual = true;
            else return false;
        }
        else if (template.CurlClosedPinky == true)
        {
            if (realtime.CurlClosedPinky == true || realtime.CurlNeutralPinky == true) isEqual = true;
            else return false;
        }
        else if (template.CurlNeutralPinky == true)
        {
            if (realtime.CurlNeutralPinky == true || realtime.CurlOpenPinky == true) isEqual = true;
            else return false;
        }

        //flexion
        if (template.FlexionOpenPinky == true)
        {
            if (realtime.FlexionOpenPinky == true || realtime.FlexionNeutralPinky == true) isEqual = true;
            else return false;
        }
        else if (template.FlexionClosedPinky == true)
        {
            if (realtime.FlexionClosedPinky == true || realtime.FlexionNeutralPinky == true) isEqual = true;
            else return false;
        }
        else if (template.FlexionNeutralPinky == true)
        {
            if (realtime.FlexionNeutralPinky == true || realtime.FlexionClosedPinky == true) isEqual = true;
            else return false;
        }

        //opposition
        if (template.OppositionTouchingIndex == true)
        {
            if (realtime.OppositionTouchingIndex == true) isEqual = true;
            else return false;
        }
        #endregion

        #region MATCHING THUMB STATE

        //curl 
        if (template.CurlOpenThumb == true)
        {
            if (realtime.CurlOpenThumb == true || realtime.CurlNeutralThumb == true) isEqual = true;
            else return false;
        }
        else if (template.CurlClosedThumb == true)
        {
            if (realtime.CurlClosedThumb == true || realtime.CurlNeutralThumb == true) isEqual = true;
            else return false;
        }
        else if (template.CurlNeutralThumb == true)
        {
            if (realtime.CurlNeutralThumb == true || realtime.CurlOpenThumb == true) isEqual = true;
            else return false;
        }


        #endregion

        return isEqual;
    }
    #endregion

    public static bool isTransformEqual(HandPose template, HandPose realtime)
    {
        bool isEqual = false;

        if (template == null)
        {
            Debug.Log("6000: template is null");
            return isEqual;
        }

        if (realtime == null)
        {
            Debug.Log("6000: realtime is null");
            return isEqual;
        }

        if (template.WristUp == realtime.WristUp) isEqual = true;
        else return false;

        if (template.WristDown == realtime.WristDown) isEqual = true;
        else return false;

        if (template.PalmUp == realtime.PalmUp) isEqual = true;
        else return false;

        if (template.PalmDown == realtime.PalmDown) isEqual = true;
        else return false;

        if (template.PalmTowardsFace == realtime.PalmTowardsFace) isEqual = true;
        else return false;

        if (template.PalmAwayFromFace == realtime.PalmAwayFromFace) isEqual = true;
        else return false;

        if (template.FingersDown == realtime.FingersDown) isEqual = true;
        else return false;

        return isEqual;
    }
}
