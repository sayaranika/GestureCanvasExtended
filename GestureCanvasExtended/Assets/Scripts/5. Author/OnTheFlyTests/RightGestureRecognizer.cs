using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class RightGestureRecognizer : MonoBehaviour
{
    [SerializeField] GameObject RightHandVisual;
    [SerializeField] GestureRecognizer gestureRecognizer;

    public bool active = false;

    public static int frameNumber = 0;
    public static int RealtimeDataStreamLength = 0;
    public static int ReadDataFrame = 0;

    public int gestureLength;
    public int len;

    public static List<RealtimeHandData> RealtimeDataStream;
    public static MySynchronizedQueue<ProducerData> ProducerDataStream;

    public Thread producerThread;
    public Thread consumerThread;

    private OVRHand ovrHandRight;
    private OVRSkeleton ovrSkeletonRight;

    public static Clip TransitionClip = null;

    public int detectedId = -1;
    public int expectedId = -1;
    configuartion_parameters_t parameters;
    public Dataset ds;
    public static Interaction Target = null;

    public void Stop()
    {
        Target = null;
        active = false;
        producerThread.Abort();
        consumerThread.Abort();
        RealtimeDataStream.Clear();
        while (ProducerDataStream.Count != 0) ProducerDataStream.Dequeue();
    }

    public void Initialize(Interaction i)
    {
        active = true;
        Target = i;
        parameters = new configuartion_parameters_t(1);

        RealtimeDataStream = new List<RealtimeHandData>();
        ProducerDataStream = new MySynchronizedQueue<ProducerData>();

        producerThread = new Thread(ProduceData);
        consumerThread = new Thread(ConsumeData);

        int maxLength = -1;
        GestureDataset.Load();
        gestureRecognizer.Train(Handedness.Right);
        ds = GestureDataset.GestureDataset_R;
        foreach (Clip clip in ClipHandler.ClipList)
        {
            foreach (Interaction interaction in clip.interactions)
            {
                if (interaction.isGesture_R == true)
                {

                    int length = clip.endIndex - clip.startIndex;
                    if (length > maxLength) maxLength = length;
                }

            }
        }

        expectedId = Target.expectedGestureId_R;

        gestureLength = maxLength;
        len = gestureLength * 3;
    }

    private void Start()
    {
        GameObject rightHandAnchor = GameObject.Find("RightHandAnchor");
        if (rightHandAnchor != null)
        {
            Transform rightHand = rightHandAnchor.transform.Find("RightOVRHand");
            if (rightHand != null)
            {
                ovrHandRight = rightHand.GetComponent<OVRHand>();
                ovrSkeletonRight = rightHand.GetComponent<OVRSkeleton>();
            }
        }
    }

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
            detectedId = ClipHandler.ClipList[0].GestureRecognizer_R.Classify(buffer);



            buffer.Clear();
        }
    }

    private IEnumerator ShowMessage(float waitTime)
    {
        //detectedIdLabel.text = "Detected: Match " + detectedId;
        RightHandVisual.GetComponent<HighlightPlus.HighlightEffect>().highlighted = true;
        yield return new WaitForSeconds(waitTime);
        RightHandVisual.GetComponent<HighlightPlus.HighlightEffect>().highlighted = false;
        //detectedIdLabel.text = "Not Matched";
    }

    private void LateUpdate()
    {



        if (active == true && gestureRecognizer.trained_R == true)
        {
            if (expectedId != -1 && detectedId == expectedId)
            {
                StartCoroutine(ShowMessage(1.0f));

            }


            if (ovrHandRight.IsTracked && ovrHandRight.IsDataValid)
            {
                Vector3 HandPosition = ovrSkeletonRight.transform.position;
                Vector3 WristPosition = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_WristRoot].Transform.localPosition;
                Vector3 ForearmStubPosition = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_ForearmStub].Transform.localPosition;
                Vector3 Index1Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Index1].Transform.localPosition;
                Vector3 Index2Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Index2].Transform.localPosition;
                Vector3 Index3Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Index3].Transform.localPosition;
                Vector3 Thumb0Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Thumb0].Transform.localPosition;
                Vector3 Thumb1Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Thumb1].Transform.localPosition;
                Vector3 Thumb2Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Thumb2].Transform.localPosition;
                Vector3 Thumb3Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Thumb3].Transform.localPosition;
                Vector3 Middle1Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Middle1].Transform.localPosition;
                Vector3 Middle2Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Middle2].Transform.localPosition;
                Vector3 Middle3Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Middle3].Transform.localPosition;
                Vector3 Ring1Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Ring1].Transform.localPosition;
                Vector3 Ring2Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Ring2].Transform.localPosition;
                Vector3 Ring3Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Ring3].Transform.localPosition;
                Vector3 Pinky0Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Pinky0].Transform.localPosition;
                Vector3 Pinky1Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Pinky1].Transform.localPosition;
                Vector3 Pinky2Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Pinky2].Transform.localPosition;
                Vector3 Pinky3Position = ovrSkeletonRight.Bones[(int)OVRPlugin.BoneId.Hand_Pinky3].Transform.localPosition;

                RealtimeDataStream.Add(new RealtimeHandData(frameNumber, HandPosition, WristPosition, ForearmStubPosition, Index1Position, Index2Position, Index3Position, Thumb0Position, Thumb1Position, Thumb2Position,
                    Thumb3Position, Middle1Position, Middle2Position, Middle3Position, Ring1Position, Ring2Position, Ring3Position, Pinky0Position, Pinky1Position, Pinky2Position, Pinky3Position));
                RealtimeDataStreamLength = RealtimeDataStream.Count; //need to put a lock here
                frameNumber++;


            }

            if (RealtimeDataStreamLength >= len && ReadDataFrame < RealtimeDataStream[len - 1].FrameNumber)
            {
                RealtimeDataStream.RemoveRange(0, gestureLength);
                RealtimeDataStreamLength = RealtimeDataStream.Count;
            }


            if (producerThread.IsAlive == false && ProducerDataStream.Count == 0)
            {
                producerThread.Start();
            }

            if (consumerThread.IsAlive == false && ProducerDataStream.Count != 0)
            {
                consumerThread.Start();
            }
        }

    }
}
