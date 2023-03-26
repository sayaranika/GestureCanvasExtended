using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GestureRecognizer_L : MonoBehaviour
{
    Interaction Target = null;
    PoseRecognizer poseRecognizer;
    PlaytestingManager playtestManager;
    OVRHand ovrHandLeft;
    OVRSkeleton ovrSkeletonLeft;


    public Thread producerThread;
    public Thread consumerThread;
    public List<RealtimeHandData> RealtimeDataStream;
    public MySynchronizedQueue<ProducerData> ProducerDataStream;
    public int frameNumber = 0;
    public int RealtimeDataStreamLength = 0;
    public int ReadDataFrame = 0;
    public int detectedId = -1;
    configuartion_parameters_t parameters;
    public int window = -1;

    public bool active = false;

    private void Start()
    {
        GameObject leftHandAnchor = GameObject.Find("LeftHandAnchor");
        if (leftHandAnchor != null)
        {
            Transform leftHand = leftHandAnchor.transform.Find("LeftOVRHand");
            if (leftHand != null)
            {
                ovrHandLeft = leftHand.GetComponent<OVRHand>();
                ovrSkeletonLeft = leftHand.GetComponent<OVRSkeleton>();
            }
        }
    }

    public void Initialize(Interaction i, PoseRecognizer p, PlaytestingManager play)
    {
        Debug.Log("4000L");

        Target = i;
        poseRecognizer = p;
        playtestManager = play;

        RealtimeDataStream = new List<RealtimeHandData>();
        ProducerDataStream = new MySynchronizedQueue<ProducerData>();
        Debug.Log("4000M");

        producerThread = new Thread(ProduceData);
        consumerThread = new Thread(ConsumeData);

        window = Target.GestureLength_L * 3;

        active = true;
    }


    #region PRODUCE AND CONSUME DATA
    public void ProduceData()
    {
        int j = RealtimeDataStreamLength;
        List<double> pt = new List<double>();
        ReadDataFrame = RealtimeDataStream[j - 1].FrameNumber;

        int start = -1;
        int end = -1;
        int check = -1;

        for (int i = 0; i < j; i++)
        {
            if (check == -1) { start = RealtimeDataStream[i].FrameNumber; check = 3; }
            if (check != -1) end = RealtimeDataStream[i].FrameNumber;

            pt.Add(RealtimeDataStream[i].HandPosition.x);
            pt.Add(RealtimeDataStream[i].HandPosition.y);
            pt.Add(RealtimeDataStream[i].HandPosition.z);

            pt.Add(RealtimeDataStream[i].WristPosition.x);
            pt.Add(RealtimeDataStream[i].WristPosition.y);
            pt.Add(RealtimeDataStream[i].WristPosition.z);

            pt.Add(RealtimeDataStream[i].ForearmStubPosition.x);
            pt.Add(RealtimeDataStream[i].ForearmStubPosition.y);
            pt.Add(RealtimeDataStream[i].ForearmStubPosition.z);

            pt.Add(RealtimeDataStream[i].Index1Position.x);
            pt.Add(RealtimeDataStream[i].Index1Position.y);
            pt.Add(RealtimeDataStream[i].Index1Position.z);

            pt.Add(RealtimeDataStream[i].Index2Position.x);
            pt.Add(RealtimeDataStream[i].Index2Position.y);
            pt.Add(RealtimeDataStream[i].Index2Position.z);

            pt.Add(RealtimeDataStream[i].Index3Position.x);
            pt.Add(RealtimeDataStream[i].Index3Position.y);
            pt.Add(RealtimeDataStream[i].Index3Position.z);

            pt.Add(RealtimeDataStream[i].Thumb0Position.x);
            pt.Add(RealtimeDataStream[i].Thumb0Position.y);
            pt.Add(RealtimeDataStream[i].Thumb0Position.z);

            pt.Add(RealtimeDataStream[i].Thumb1Position.x);
            pt.Add(RealtimeDataStream[i].Thumb1Position.y);
            pt.Add(RealtimeDataStream[i].Thumb1Position.z);

            pt.Add(RealtimeDataStream[i].Thumb2Position.x);
            pt.Add(RealtimeDataStream[i].Thumb2Position.y);
            pt.Add(RealtimeDataStream[i].Thumb2Position.z);

            pt.Add(RealtimeDataStream[i].Thumb3Position.x);
            pt.Add(RealtimeDataStream[i].Thumb3Position.y);
            pt.Add(RealtimeDataStream[i].Thumb3Position.z);

            pt.Add(RealtimeDataStream[i].Middle1Position.x);
            pt.Add(RealtimeDataStream[i].Middle1Position.y);
            pt.Add(RealtimeDataStream[i].Middle1Position.z);

            pt.Add(RealtimeDataStream[i].Middle2Position.x);
            pt.Add(RealtimeDataStream[i].Middle2Position.y);
            pt.Add(RealtimeDataStream[i].Middle2Position.z);

            pt.Add(RealtimeDataStream[i].Middle3Position.x);
            pt.Add(RealtimeDataStream[i].Middle3Position.y);
            pt.Add(RealtimeDataStream[i].Middle3Position.z);

            pt.Add(RealtimeDataStream[i].Ring1Position.x);
            pt.Add(RealtimeDataStream[i].Ring1Position.y);
            pt.Add(RealtimeDataStream[i].Ring1Position.z);

            pt.Add(RealtimeDataStream[i].Ring2Position.x);
            pt.Add(RealtimeDataStream[i].Ring2Position.y);
            pt.Add(RealtimeDataStream[i].Ring2Position.z);

            pt.Add(RealtimeDataStream[i].Ring3Position.x);
            pt.Add(RealtimeDataStream[i].Ring3Position.y);
            pt.Add(RealtimeDataStream[i].Ring3Position.z);

            pt.Add(RealtimeDataStream[i].Pinky0Position.x);
            pt.Add(RealtimeDataStream[i].Pinky0Position.y);
            pt.Add(RealtimeDataStream[i].Pinky0Position.z);

            pt.Add(RealtimeDataStream[i].Pinky1Position.x);
            pt.Add(RealtimeDataStream[i].Pinky1Position.y);
            pt.Add(RealtimeDataStream[i].Pinky1Position.z);

            pt.Add(RealtimeDataStream[i].Pinky2Position.x);
            pt.Add(RealtimeDataStream[i].Pinky2Position.y);
            pt.Add(RealtimeDataStream[i].Pinky2Position.z);

            pt.Add(RealtimeDataStream[i].Pinky3Position.x);
            pt.Add(RealtimeDataStream[i].Pinky3Position.y);
            pt.Add(RealtimeDataStream[i].Pinky3Position.z);

            ProducerDataStream.Enqueue(new ProducerData(RealtimeDataStream[i].FrameNumber, new Vector(pt)));
            pt.Clear();
        }
    }

    public void ConsumeData()
    {

        List<Vector> points = new List<Vector>();
        List<Frame> frames = new List<Frame>();
        List<Vector> buffer = new List<Vector>();


        while (ProducerDataStream.Count != 0)
        {

            ProducerData p = ProducerDataStream.Dequeue();
            points.Add(p.point);
            frames.Add(new Frame(p.point));
        }
        //Debug.Log("800B");
        if (points.Count > 2)
        {
            ExponentialMovingAverage filter = new ExponentialMovingAverage(frames[0].pt);
            Vector pts;
            //Debug.Log("800C");
            for (int s = 0; s < points.Count; s++)
            {
                pts = filter.Filter(points[s], 1 / (double)parameters.fps);
                buffer.Add(pts);

            }
            //Debug.Log("800D");
            detectedId = ClipHandler.ClipList[0].GestureRecognizer_L.Classify(buffer);
            buffer.Clear();
        }
    }
    #endregion

    private void LateUpdate()
    {
        if (active == true)
        {
            if (detectedId != -1)
            {
                if (Target.expectedGestureId_L == detectedId)
                {
                    Debug.Log("4000N");

                    if (Target.isPose_R == true)
                    {
                        bool isRecognized = poseRecognizer.Recognize(Handedness.Right, null, Target.expectedPose_R,
                            Target.isTransformConstraint_R, Target.isConditionSetToTrue);
                    }
                    else
                    {
                        playtestManager.Load(Target.transitionClip);
                    }
                }
            }

            if (ovrHandLeft.IsTracked && ovrHandLeft.IsDataValid)
            {
                Vector3 HandPosition = ovrSkeletonLeft.transform.position;
                Vector3 WristPosition = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_WristRoot].Transform.localPosition;
                Vector3 ForearmStubPosition = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_ForearmStub].Transform.localPosition;
                Vector3 Index1Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Index1].Transform.localPosition;
                Vector3 Index2Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Index2].Transform.localPosition;
                Vector3 Index3Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Index3].Transform.localPosition;
                Vector3 Thumb0Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Thumb0].Transform.localPosition;
                Vector3 Thumb1Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Thumb1].Transform.localPosition;
                Vector3 Thumb2Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Thumb2].Transform.localPosition;
                Vector3 Thumb3Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Thumb3].Transform.localPosition;
                Vector3 Middle1Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Middle1].Transform.localPosition;
                Vector3 Middle2Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Middle2].Transform.localPosition;
                Vector3 Middle3Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Middle3].Transform.localPosition;
                Vector3 Ring1Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Ring1].Transform.localPosition;
                Vector3 Ring2Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Ring2].Transform.localPosition;
                Vector3 Ring3Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Ring3].Transform.localPosition;
                Vector3 Pinky0Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Pinky0].Transform.localPosition;
                Vector3 Pinky1Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Pinky1].Transform.localPosition;
                Vector3 Pinky2Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Pinky2].Transform.localPosition;
                Vector3 Pinky3Position = ovrSkeletonLeft.Bones[(int)OVRPlugin.BoneId.Hand_Pinky3].Transform.localPosition;

                RealtimeDataStream.Add(new RealtimeHandData(frameNumber, HandPosition, WristPosition, ForearmStubPosition, Index1Position, Index2Position, Index3Position, Thumb0Position, Thumb1Position, Thumb2Position,
                    Thumb3Position, Middle1Position, Middle2Position, Middle3Position, Ring1Position, Ring2Position, Ring3Position, Pinky0Position, Pinky1Position, Pinky2Position, Pinky3Position));
                RealtimeDataStreamLength = RealtimeDataStream.Count; //need to put a lock here
                frameNumber++;
            }

            if (RealtimeDataStreamLength >= window && ReadDataFrame < RealtimeDataStream[window - 1].FrameNumber)
            {
                Debug.Log("4000O");

                RealtimeDataStream.RemoveRange(0, Target.GestureLength_L);
                RealtimeDataStreamLength = RealtimeDataStream.Count;
            }


            if (producerThread.IsAlive == false && ProducerDataStream.Count == 0)
            {
                Debug.Log("4000P");

                producerThread.Start();
            }

            if (consumerThread.IsAlive == false && ProducerDataStream.Count != 0)
            {
                Debug.Log("4000Q");

                consumerThread.Start();
            }
        }

    }
}
