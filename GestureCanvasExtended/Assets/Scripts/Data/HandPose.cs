public class HandPose 
{
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

    public HandPose(
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
    }
}
