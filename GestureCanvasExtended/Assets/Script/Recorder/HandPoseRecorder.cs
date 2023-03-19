using UnityEngine;

public class HandPoseRecorder : MonoBehaviour
{
    #region Right Hand Pose Properties

    #region CURL
    /////////////////////////////////////////////// RIGHT CURL ///////////////////////////////////////////////

    private bool rightCurlOpenIndex = false;
    private bool rightCurlOpenMiddle = false;
    private bool rightCurlOpenRing = false;
    private bool rightCurlOpenPinky = false;
    private bool rightCurlOpenThumb = false;

    private bool rightCurlClosedIndex = false;
    private bool rightCurlClosedMiddle = false;
    private bool rightCurlClosedRing = false;
    private bool rightCurlClosedPinky = false;
    private bool rightCurlClosedThumb = false;

    private bool rightCurlNeutralIndex = false;
    private bool rightCurlNeutralMiddle = false;
    private bool rightCurlNeutralRing = false;
    private bool rightCurlNeutralPinky = false;
    private bool rightCurlNeutralThumb = false;

    public void SetRightCurlOpenIndex(bool state) { rightCurlOpenIndex = state; }
    public void SetRightCurlOpenMiddle(bool state) { rightCurlOpenMiddle = state; }
    public void SetRightCurlOpenRing(bool state) { rightCurlOpenRing = state; }
    public void SetRightCurlOpenPinkie(bool state) { rightCurlOpenPinky = state; }
    public void SetRightCurlOpenThumb(bool state) { rightCurlOpenThumb = state; }
    public void SetRightCurlClosedIndex(bool state) { rightCurlClosedIndex = state; }
    public void SetRightCurlClosedMiddle(bool state) { rightCurlClosedMiddle = state; }
    public void SetRightCurlClosedRing(bool state) { rightCurlClosedRing = state; }
    public void SetRightCurlClosedPinkie(bool state) { rightCurlClosedPinky = state; }
    public void SetRightCurlClosedThumb(bool state) { rightCurlClosedThumb = state; }
    public void SetRightCurlNeutralIndex(bool state) { rightCurlNeutralIndex = state; }
    public void SetRightCurlNeutralMiddle(bool state) { rightCurlNeutralMiddle = state; }
    public void SetRightCurlNeutralRing(bool state) { rightCurlNeutralRing = state; }
    public void SetRightCurlNeutralPinkie(bool state) { rightCurlNeutralPinky = state; }
    public void SetRightCurlNeutralThumb(bool state) { rightCurlNeutralThumb = state; }  

    #endregion

    #region FLEXION
    /////////////////////////////////////////////// RIGHT FLEXION ///////////////////////////////////////////////

    private bool rightFlexionOpenIndex = false;
    private bool rightFlexionOpenMiddle = false;
    private bool rightFlexionOpenRing = false;
    private bool rightFlexionOpenPinky = false;

    private bool rightFlexionClosedIndex = false;
    private bool rightFlexionClosedMiddle = false;
    private bool rightFlexionClosedRing = false;
    private bool rightFlexionClosedPinky = false;

    private bool rightFlexionNeutralIndex = false;
    private bool rightFlexionNeutralMiddle = false;
    private bool rightFlexionNeutralRing = false;
    private bool rightFlexionNeutralPinky = false;


    public void SetRightFlexionOpenIndex(bool state) { rightFlexionOpenIndex = state; }
    public void SetRightFlexionOpenMiddle(bool state) { rightFlexionOpenMiddle = state; }
    public void SetRightFlexionOpenRing(bool state) { rightFlexionOpenRing = state; }
    public void SetRightFlexionOpenPinky(bool state) { rightFlexionOpenPinky = state; }
    public void SetRightFlexionClosedIndex(bool state) { rightFlexionClosedIndex = state; }    
    public void SetRightFlexionClosedMiddle(bool state) { rightFlexionClosedMiddle = state; }    
    public void SetRightFlexionClosedRing(bool state) { rightFlexionClosedRing = state; }
    public void SetRightFlexionClosedPinky(bool state) { rightFlexionClosedPinky = state; }
    public void SetRightFlexionNeutralIndex(bool state) { rightFlexionNeutralIndex = state; } 
    public void SetRightFlexionNeutralMiddle(bool state) { rightFlexionNeutralMiddle = state; }
    public void SetRightFlexionNeutralRing(bool state) { rightFlexionNeutralRing = state; }
    public void SetRightFlexionNeutralPinky(bool state) { rightFlexionNeutralPinky = state; }

    #endregion

    #region ABDUCTION
    /////////////////////////////////////////////// RIGHT ABDUCTION ///////////////////////////////////////////////

    private bool rightAbductionOpenIndex = false;
    private bool rightAbductionOpenMiddle = false;
    private bool rightAbductionOpenRing = false;
    private bool rightAbductionOpenThumb = false;

    private bool rightAbductionClosedIndex = false;
    private bool rightAbductionClosedMiddle = false;
    private bool rightAbductionClosedRing = false;
    private bool rightAbductionClosedThumb = false;

    public void SetRightAbductionOpenIndex(bool state) { rightAbductionOpenIndex = state; }
    public void SetRightAbductionOpenMiddle(bool state) { rightAbductionOpenMiddle = state; }
    public void SetRightAbductionOpenRing(bool state) { rightAbductionOpenRing = state; }
    public void SetRightAbductionOpenThumb(bool state) { rightAbductionOpenThumb = state; }
    public void SetRightAbductionClosedIndex(bool state) { rightAbductionClosedIndex = state; }
    public void SetRightAbductionClosedMiddle(bool state) { rightAbductionClosedMiddle = state; }
    public void SetRightAbductionClosedRing(bool state) { rightAbductionClosedRing = state; }
    public void SetRightAbductionClosedThumb(bool state) { rightAbductionClosedThumb = state; } 

    #endregion

    #region OPPOSITION
    /////////////////////////////////////////////// RIGHT OPPOSITION ///////////////////////////////////////////////

    private bool rightOppositionTouchingIndex = false;
    private bool rightOppositionTouchingMiddle = false;
    private bool rightOppositionTouchingRing = false;
    private bool rightOppositionTouchingPinky = false;

    private bool rightOppositionNearIndex = false;
    private bool rightOppositionNearMiddle = false;
    private bool rightOppositionNearRing = false;
    private bool rightOppositionNearPinky = false;

    private bool rightOppositionNoneIndex = false;
    private bool rightOppositionNoneMiddle = false;
    private bool rightOppositionNoneRing = false;
    private bool rightOppositionNonePinky = false;

    public void SetRightOppositionTouchingIndex(bool state) { rightOppositionTouchingIndex = state; }
    public void SetRightOppositionTouchingMiddle(bool state) { rightOppositionTouchingMiddle = state; }
    public void SetRightOppositionTouchingRing(bool state) { rightOppositionTouchingRing = state; }
    public void SetRightOppositionTouchingPinky(bool state) { rightOppositionTouchingPinky = state; }
    public void SetRightOppositionNearIndex(bool state) { rightOppositionNearIndex = state; }
    public void SetRightOppositionNearMiddle(bool state) { rightOppositionNearMiddle = state; }
    public void SetRightOppositionNearRing(bool state) { rightOppositionNearRing = state; }
    public void SetRightOppositionNearPinky(bool state) { rightOppositionNearPinky = state; }
    public void SetRightOppositionNoneIndex(bool state) { rightOppositionNoneIndex = state; }
    public void SetRightOppositionNoneMiddle(bool state) { rightOppositionNoneMiddle = state; }
    public void SetRightOppositionNoneRing(bool state) { rightOppositionNoneRing = state; }
    public void SetRightOppositionNonePinky(bool state) { rightOppositionNonePinky = state; }

    #endregion

    #region TRANSFORM
    /////////////////////////////////////////////// RIGHT TRANSFORM ///////////////////////////////////////////////

    private bool rightWristUp = false;
    private bool rightWristDown = false;
    private bool rightPalmUp = false;
    private bool rightPalmDown = false;
    private bool rightPalmTowardsFace = false;
    private bool rightPalmAwayFromFace = false;
    private bool rightFingersUp = false;
    private bool rightFingersDown = false;

    public void SetRightWristUp(bool state) { rightWristUp = state; }
    public void SetRightWristDown(bool state) { rightWristDown = state; }
    public void SetRightPalmUp(bool state) { rightPalmUp = state; }
    public void SetRightPalmDown(bool state) { rightPalmDown = state; }
    public void SetRightPalmTowardsFace(bool state) { rightPalmTowardsFace = state; }
    public void SetRightPalmAwayFromFace(bool state) { rightPalmAwayFromFace = state; }
    public void SetRightFingersUp(bool state) { rightFingersUp = state; }
    public void SetRightFingersDown(bool state) { rightFingersDown = state; }

    #endregion

    #endregion

    #region Left Hand Pose Properties
    #region CURL
    /////////////////////////////////////////////// LEFT CURL ///////////////////////////////////////////////

    private bool leftCurlOpenIndex = false;
    private bool leftCurlOpenMiddle = false;
    private bool leftCurlOpenRing = false;
    private bool leftCurlOpenPinky = false;
    private bool leftCurlOpenThumb = false;

    private bool leftCurlClosedIndex = false;
    private bool leftCurlClosedMiddle = false;
    private bool leftCurlClosedRing = false;
    private bool leftCurlClosedPinky = false;
    private bool leftCurlClosedThumb = false;

    private bool leftCurlNeutralIndex = false;
    private bool leftCurlNeutralMiddle = false;
    private bool leftCurlNeutralRing = false;
    private bool leftCurlNeutralPinky = false;
    private bool leftCurlNeutralThumb = false;

    public void SetLeftCurlOpenIndex(bool state) { leftCurlOpenIndex = state; }
    public void SetLeftCurlOpenMiddle(bool state) { leftCurlOpenMiddle = state; }
    public void SetLeftCurlOpenRing(bool state) { leftCurlOpenRing = state; }
    public void SetLeftCurlOpenPinkie(bool state) { leftCurlOpenPinky = state; }
    public void SetLeftCurlOpenThumb(bool state) { leftCurlOpenThumb = state; }
    public void SetLeftCurlClosedIndex(bool state) { leftCurlClosedIndex = state; }
    public void SetLeftCurlClosedMiddle(bool state) { leftCurlClosedMiddle = state; }
    public void SetLeftCurlClosedRing(bool state) { leftCurlClosedRing = state; }
    public void SetLeftCurlClosedPinkie(bool state) { leftCurlClosedPinky = state; }
    public void SetLeftCurlClosedThumb(bool state) { leftCurlClosedThumb = state; }
    public void SetLeftCurlNeutralIndex(bool state) { leftCurlNeutralIndex = state; }
    public void SetLeftCurlNeutralMiddle(bool state) { leftCurlNeutralMiddle = state; }
    public void SetLeftCurlNeutralRing(bool state) { leftCurlNeutralRing = state; }
    public void SetLeftCurlNeutralPinkie(bool state) { leftCurlNeutralPinky = state; }
    public void SetLeftCurlNeutralThumb(bool state) { leftCurlNeutralThumb = state; }

    #endregion

    #region FLEXION
    /////////////////////////////////////////////// LEFT FLEXION ///////////////////////////////////////////////

    private bool leftFlexionOpenIndex = false;
    private bool leftFlexionOpenMiddle = false;
    private bool leftFlexionOpenRing = false;
    private bool leftFlexionOpenPinky = false;

    private bool leftFlexionClosedIndex = false;
    private bool leftFlexionClosedMiddle = false;
    private bool leftFlexionClosedRing = false;
    private bool leftFlexionClosedPinky = false;

    private bool leftFlexionNeutralIndex = false;
    private bool leftFlexionNeutralMiddle = false;
    private bool leftFlexionNeutralRing = false;
    private bool leftFlexionNeutralPinky = false;


    public void SetLeftFlexionOpenIndex(bool state) { leftFlexionOpenIndex = state; }
    public void SetLeftFlexionOpenMiddle(bool state) { leftFlexionOpenMiddle = state; }
    public void SetLeftFlexionOpenRing(bool state) { leftFlexionOpenRing = state; }
    public void SetLeftFlexionOpenPinky(bool state) { leftFlexionOpenPinky = state; }
    public void SetLeftFlexionClosedIndex(bool state) { leftFlexionClosedIndex = state; }
    public void SetLeftFlexionClosedMiddle(bool state) { leftFlexionClosedMiddle = state; }
    public void SetLeftFlexionClosedRing(bool state) { leftFlexionClosedRing = state; }
    public void SetLeftFlexionClosedPinky(bool state) { leftFlexionClosedPinky = state; }
    public void SetLeftFlexionNeutralIndex(bool state) { leftFlexionNeutralIndex = state; }
    public void SetLeftFlexionNeutralMiddle(bool state) { leftFlexionNeutralMiddle = state; }
    public void SetLeftFlexionNeutralRing(bool state) { leftFlexionNeutralRing = state; }
    public void SetLeftFlexionNeutralPinky(bool state) { leftFlexionNeutralPinky = state; }

    #endregion

    #region ABDUCTION
    /////////////////////////////////////////////// LEFT ABDUCTION ///////////////////////////////////////////////

    private bool leftAbductionOpenIndex = false;
    private bool leftAbductionOpenMiddle = false;
    private bool leftAbductionOpenRing = false;
    private bool leftAbductionOpenThumb = false;

    private bool leftAbductionClosedIndex = false;
    private bool leftAbductionClosedMiddle = false;
    private bool leftAbductionClosedRing = false;
    private bool leftAbductionClosedThumb = false;

    public void SetLeftAbductionOpenIndex(bool state) { leftAbductionOpenIndex = state; }
    public void SetLeftAbductionOpenMiddle(bool state) { leftAbductionOpenMiddle = state; }
    public void SetLeftAbductionOpenRing(bool state) { leftAbductionOpenRing = state; }
    public void SetLeftAbductionOpenThumb(bool state) { leftAbductionOpenThumb = state; }
    public void SetLeftAbductionClosedIndex(bool state) { leftAbductionClosedIndex = state; }
    public void SetLeftAbductionClosedMiddle(bool state) { leftAbductionClosedMiddle = state; }
    public void SetLeftAbductionClosedRing(bool state) { leftAbductionClosedRing = state; }
    public void SetLeftAbductionClosedThumb(bool state) { leftAbductionClosedThumb = state; }

    #endregion

    #region OPPOSITION
    /////////////////////////////////////////////// LEFT OPPOSITION ///////////////////////////////////////////////

    private bool leftOppositionTouchingIndex = false;
    private bool leftOppositionTouchingMiddle = false;
    private bool leftOppositionTouchingRing = false;
    private bool leftOppositionTouchingPinky = false;

    private bool leftOppositionNearIndex = false;
    private bool leftOppositionNearMiddle = false;
    private bool leftOppositionNearRing = false;
    private bool leftOppositionNearPinky = false;

    private bool leftOppositionNoneIndex = false;
    private bool leftOppositionNoneMiddle = false;
    private bool leftOppositionNoneRing = false;
    private bool leftOppositionNonePinky = false;

    public void SetLeftOppositionTouchingIndex(bool state) { leftOppositionTouchingIndex = state; }
    public void SetLeftOppositionTouchingMiddle(bool state) { leftOppositionTouchingMiddle = state; }
    public void SetLeftOppositionTouchingRing(bool state) { leftOppositionTouchingRing = state; }
    public void SetLeftOppositionTouchingPinky(bool state) { leftOppositionTouchingPinky = state; }
    public void SetLeftOppositionNearIndex(bool state) { leftOppositionNearIndex = state; }
    public void SetLeftOppositionNearMiddle(bool state) { leftOppositionNearMiddle = state; }
    public void SetLeftOppositionNearRing(bool state) { leftOppositionNearRing = state; }
    public void SetLeftOppositionNearPinky(bool state) { leftOppositionNearPinky = state; }
    public void SetLeftOppositionNoneIndex(bool state) { leftOppositionNoneIndex = state; }
    public void SetLeftOppositionNoneMiddle(bool state) { leftOppositionNoneMiddle = state; }
    public void SetLeftOppositionNoneRing(bool state) { leftOppositionNoneRing = state; }
    public void SetLeftOppositionNonePinky(bool state) { leftOppositionNonePinky = state; }

    #endregion

    #region TRANSFORM
    /////////////////////////////////////////////// LEFT TRANSFORM ///////////////////////////////////////////////

    private bool leftWristUp = false;
    private bool leftWristDown = false;
    private bool leftPalmUp = false;
    private bool leftPalmDown = false;
    private bool leftPalmTowardsFace = false;
    private bool leftPalmAwayFromFace = false;
    private bool leftFingersUp = false;
    private bool leftFingersDown = false;

    public void SetLeftWristUp(bool state) { leftWristUp = state; }
    public void SetLeftWristDown(bool state) { leftWristDown = state; }
    public void SetLeftPalmUp(bool state) { leftPalmUp = state; }
    public void SetLeftPalmDown(bool state) { leftPalmDown = state; }
    public void SetLeftPalmTowardsFace(bool state) { leftPalmTowardsFace = state; }

    public void SetLeftPalmAwayFromFace(bool state) { leftPalmAwayFromFace = state; }
    public void SetLeftFingersUp(bool state) { leftFingersUp = state; }
    public void SetLeftFingersDown(bool state) { leftFingersDown = state; }


    #endregion

    #endregion

    #region GET HAND POSE DATA
    public HandPose GetRightHandPose()
    {
        return new HandPose(
            rightCurlOpenIndex,
            rightCurlOpenMiddle,
            rightCurlOpenRing,
            rightCurlOpenPinky,
            rightCurlOpenThumb,
            rightCurlClosedIndex,
            rightCurlClosedMiddle,
            rightCurlClosedRing,
            rightCurlClosedPinky,
            rightCurlClosedThumb,
            rightCurlNeutralIndex,
            rightCurlNeutralMiddle,
            rightCurlNeutralRing,
            rightCurlNeutralPinky,
            rightCurlNeutralThumb,
            rightFlexionOpenIndex,
            rightFlexionOpenMiddle,
            rightFlexionOpenRing,
            rightFlexionOpenPinky,
            rightFlexionClosedIndex,
            rightFlexionClosedMiddle,
            rightFlexionClosedRing,
            rightFlexionClosedPinky,
            rightFlexionNeutralIndex,
            rightFlexionNeutralMiddle,
            rightFlexionNeutralRing,
            rightFlexionNeutralPinky,
            rightAbductionOpenIndex,
            rightAbductionOpenMiddle,
            rightAbductionOpenRing,
            rightAbductionOpenThumb,
            rightAbductionClosedIndex,
            rightAbductionClosedMiddle,
            rightAbductionClosedRing,
            rightAbductionClosedThumb,
            rightOppositionTouchingIndex,
            rightOppositionTouchingMiddle,
            rightOppositionTouchingRing,
            rightOppositionTouchingPinky,
            rightOppositionNearIndex,
            rightOppositionNearMiddle,
            rightOppositionNearRing,
            rightOppositionNearPinky,
            rightOppositionNoneIndex,
            rightOppositionNoneMiddle,
            rightOppositionNoneRing,
            rightOppositionNonePinky,
            rightWristUp,
            rightWristDown,
            rightPalmUp,
            rightPalmDown,
            rightPalmTowardsFace,
            rightPalmAwayFromFace,
            rightFingersUp,
            rightFingersDown
            );
    }

    public HandPose GetLeftHandPose()
    {
        return new HandPose(
            leftCurlOpenIndex,
            leftCurlOpenMiddle,
            leftCurlOpenRing,
            leftCurlOpenPinky,
            leftCurlOpenThumb,
            leftCurlClosedIndex,
            leftCurlClosedMiddle,
            leftCurlClosedRing,
            leftCurlClosedPinky,
            leftCurlClosedThumb,
            leftCurlNeutralIndex,
            leftCurlNeutralMiddle,
            leftCurlNeutralRing,
            leftCurlNeutralPinky,
            leftCurlNeutralThumb,
            leftFlexionOpenIndex,
            leftFlexionOpenMiddle,
            leftFlexionOpenRing,
            leftFlexionOpenPinky,
            leftFlexionClosedIndex,
            leftFlexionClosedMiddle,
            leftFlexionClosedRing,
            leftFlexionClosedPinky,
            leftFlexionNeutralIndex,
            leftFlexionNeutralMiddle,
            leftFlexionNeutralRing,
            leftFlexionNeutralPinky,
            leftAbductionOpenIndex,
            leftAbductionOpenMiddle,
            leftAbductionOpenRing,
            leftAbductionOpenThumb,
            leftAbductionClosedIndex,
            leftAbductionClosedMiddle,
            leftAbductionClosedRing,
            leftAbductionClosedThumb,
            leftOppositionTouchingIndex,
            leftOppositionTouchingMiddle,
            leftOppositionTouchingRing,
            leftOppositionTouchingPinky,
            leftOppositionNearIndex,
            leftOppositionNearMiddle,
            leftOppositionNearRing,
            leftOppositionNearPinky,
            leftOppositionNoneIndex,
            leftOppositionNoneMiddle,
            leftOppositionNoneRing,
            leftOppositionNonePinky,
            leftWristUp,
            leftWristDown,
            leftPalmUp,
            leftPalmDown,
            leftPalmTowardsFace,
            leftPalmAwayFromFace,
            leftFingersUp,
            leftFingersDown
            );
    }

    #endregion
}
