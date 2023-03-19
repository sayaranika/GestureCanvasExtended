using System.Collections.Generic;
using UnityEngine;

public class MasterRecording : MonoBehaviour
{
    [Header("Recorders")]
    [SerializeField] HandMotionRecorder handMotionRecorder;
    [SerializeField] HandSkeletonRecorder handSkeletonRecorder;
    [SerializeField] HandPoseRecorder handPoseRecorder;
    [SerializeField] HMDRecorder HMDRecorder;

    [Header("Right Hand")]
    [SerializeField] private OVRHand ovrHandRight;
    [SerializeField] private OVRSkeleton ovrSkeletonRight;

    [Header("Left Hand")]
    [SerializeField] private OVRHand ovrHandLeft;
    [SerializeField] private OVRSkeleton ovrSkeletonLeft;

    [Header("HMD")]
    [SerializeField] private GameObject HMD;

    [Header("UI")]
    [SerializeField] private GameObject RecordLabel;

    public static List<HandMotion> RightHandMotion = new List<HandMotion>();
    public static List<HandMotion> LeftHandMotion = new List<HandMotion>();
    public static List<HandSkeleton> RightHandSkeleton = new List<HandSkeleton>();
    public static List<HandSkeleton> LeftHandSkeleton = new List<HandSkeleton>();
    public static List<HandPose> RightHandPose = new List<HandPose>();
    public static List<HandPose> LeftHandPose = new List<HandPose>();
    public static List<HMDMotion> HMDMotion = new List<HMDMotion>();

    private bool isRecordRestarting = false;

    private void LateUpdate()
    {
        if (isRecordRestarting == false) RecordData();
    }

    public void RecordData()
    {
        RightHandMotion.Add(handMotionRecorder.GetHandMotion(ovrSkeletonRight, ovrHandRight));
        LeftHandMotion.Add(handMotionRecorder.GetHandMotion(ovrSkeletonLeft, ovrHandLeft));
        RightHandSkeleton.Add(handSkeletonRecorder.GetHandSkeleton(ovrSkeletonRight, ovrHandRight));
        LeftHandSkeleton.Add(handSkeletonRecorder.GetHandSkeleton(ovrSkeletonLeft, ovrHandLeft));
        RightHandPose.Add(handPoseRecorder.GetRightHandPose());
        LeftHandPose.Add(handPoseRecorder.GetLeftHandPose());
        HMDMotion.Add(HMDRecorder.GetHMDData(HMD));
    }

    public void Restart()
    {
        isRecordRestarting = true;
        RecordLabel.SetActive(false);

        RightHandMotion.Clear();
        LeftHandMotion.Clear();
        RightHandSkeleton.Clear();
        LeftHandSkeleton.Clear();
        RightHandPose.Clear();
        LeftHandPose.Clear();
        HMDMotion.Clear();

        isRecordRestarting = false;
        RecordLabel.SetActive(true);
    }


}
