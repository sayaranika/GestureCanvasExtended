using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GestureDetection : MonoBehaviour
{
    [SerializeField] public GameObject RightHandVisual;
    [SerializeField] public HandSkeletonRecorder handSkeletonRecorder;
    [SerializeField] public OVRSkeleton ovrSkeleton_R;
    [SerializeField] public OVRSkeleton ovrSkeleton_L;
    [SerializeField] public OVRHand ovrHand_R;
    [SerializeField] public OVRHand ovrHand_L;

    public static int RealtimeDataStreamLength = 0;
    public static int ReadDataFrame = 0;

    public static List<RealtimeHandData> RealtimeDataStream = new List<RealtimeHandData>();
    public static MySynchronizedQueue<ProducerData> ProducerDataStream = new MySynchronizedQueue<ProducerData>();

    configuartion_parameters_t parameters;
    public int detectedId = -1;
    public int expectedId = -1;
    public int frameNumber = 0;
    HandSkeleton handData;
    public int gestureLength;
    public int len;
    public Thread producerThread;
    public Thread consumerThread;

    public bool isRecoOn = false;


    public Handedness handedness;

    private void Awake()
    {
        producerThread = new Thread(ProduceData);
        consumerThread = new Thread(ConsumeData);
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
        Dataset dataset = GetDataset();
        Jackknife jk = GetRecognizer();
        List<Vector> points = new List<Vector>();
        List<Frame> frames = new List<Frame>();
        List<Vector> buffer = new List<Vector>();


        while (ProducerDataStream.Count != 0)
        {
            ProducerData p = ProducerDataStream.Dequeue();
            points.Add(p.point);
            frames.Add(new Frame(p.point));
        }
        if (points.Count > 2)
        {
            ExponentialMovingAverage filter = new ExponentialMovingAverage(frames[0].pt);
            Vector pts;
            for (int s = 0; s < points.Count; s++)
            {
                pts = filter.Filter(points[s], 1 / (double)parameters.fps);
                buffer.Add(pts);
            }
            detectedId = jk.Classify(buffer);
            buffer.Clear();
        }
    }

    private void LateUpdate()
    {
        if (expectedId != -1 && detectedId == expectedId) StartCoroutine(ShowMessage(1.0f));

        if (handedness == Handedness.Right) {
            handData = handSkeletonRecorder.GetHandSkeleton(ovrSkeleton_R, ovrHand_R);
        }

        RealtimeDataStream.Add(new RealtimeHandData(frameNumber, handData.HandPosition,
                handData.WristPosition,
                handData.ForearmStubPosition,
                handData.Index1Position,
                handData.Index2Position,
                handData.Index3Position,
                handData.Thumb0Position,
                handData.Thumb1Position,
                handData.Thumb2Position,
                handData.Thumb3Position,
                handData.Middle1Position,
                handData.Middle2Position,
                handData.Middle3Position,
                handData.Ring1Position,
                handData.Ring2Position,
                handData.Ring3Position,
                handData.Pinky0Position,
                handData.Pinky1Position,
                handData.Pinky2Position,
                handData.Pinky3Position));

                RealtimeDataStreamLength = RealtimeDataStream.Count; 
                frameNumber++;

        Debug.Log("RealtimeDataStreamLength" + RealtimeDataStreamLength);
        Debug.Log("Frame: " + frameNumber);
        Debug.Log("Len: " + len);
        Debug.Log("ProducerDataStreamLength" + ProducerDataStream.Count);

        if (RealtimeDataStreamLength >= len && ReadDataFrame < RealtimeDataStream[len - 1].FrameNumber)
        {
            Debug.Log("Removing Range");
            RealtimeDataStream.RemoveRange(0, gestureLength);
            RealtimeDataStreamLength = RealtimeDataStream.Count;
        }

        if(producerThread.ThreadState == ThreadState.Running)
        {
            // do nothing
            Debug.Log("Inside producer thread running");
        }
        else
        {
            Debug.Log("Inside producer thread NOT running");
            if (ProducerDataStream.Count == 0) producerThread.Start();

        }


        if (consumerThread.ThreadState == ThreadState.Running)
        {
            // do nothing
            Debug.Log("Inside consumer thread running");
        }
        else
        {
            Debug.Log("Inside consumer thread NOT running");
            consumerThread.Start();

        }

        /*if (producerThread.IsAlive == false)
            Debug.Log("Producer not alive");
        else
            Debug.Log("Producer alive");

        if (consumerThread.IsAlive == false)
            Debug.Log("Consumer not alive");
        else
            Debug.Log("Consumer alive");

        if (producerThread.IsAlive == false && ProducerDataStream.Count == 0)
        {
            Debug.Log("Inside producer is alive");
            producerThread.Start();
        }

        if (consumerThread.IsAlive == false && ProducerDataStream.Count != 0)
        {
            Debug.Log("Inside consumer is alive");
            consumerThread.Start();
        }*/
    }

    #region HELPERS

    private void OnDestroy()
    {
        //producerThread.Abort();
        //consumerThread.Abort();
    }
    public Dataset GetDataset()
    {
        if (handedness == Handedness.Right)
            return GestureDataset.GestureDataset_R;
        else 
            return GestureDataset.GestureDataset_L;
    }

    public Jackknife GetRecognizer()
    {
        if (handedness == Handedness.Right)
            return ClipHandler.ClipList[0].GestureRecognizer_R;
        else
            return ClipHandler.ClipList[0].GestureRecognizer_L;

    }

    IEnumerator ShowMessage(float waitTime)
    {
        RightHandVisual.GetComponent<HighlightPlus.HighlightEffect>().highlighted = true;
        yield return new WaitForSeconds(waitTime);
        RightHandVisual.GetComponent<HighlightPlus.HighlightEffect>().highlighted = false;
    }
    #endregion
}


public class ProducerData
{
    public Vector point;
    public int frame;

    public ProducerData(int frame, Vector point)
    {
        this.frame = frame;
        this.point = point;
    }
}


public class RealtimeHandData
{
    public int FrameNumber;

    public Vector3 HandPosition;
    public Vector3 WristPosition;
    public Vector3 ForearmStubPosition;
    public Vector3 Index1Position;
    public Vector3 Index2Position;
    public Vector3 Index3Position;
    public Vector3 Thumb0Position;
    public Vector3 Thumb1Position;
    public Vector3 Thumb2Position;
    public Vector3 Thumb3Position;
    public Vector3 Middle1Position;
    public Vector3 Middle2Position;
    public Vector3 Middle3Position;
    public Vector3 Ring1Position;
    public Vector3 Ring2Position;
    public Vector3 Ring3Position;
    public Vector3 Pinky0Position;
    public Vector3 Pinky1Position;
    public Vector3 Pinky2Position;
    public Vector3 Pinky3Position;

    public Vector3 HandPosition_L;
    public Vector3 WristPosition_L;
    public Vector3 ForearmStubPosition_L;
    public Vector3 Index1Position_L;
    public Vector3 Index2Position_L;
    public Vector3 Index3Position_L;
    public Vector3 Thumb0Position_L;
    public Vector3 Thumb1Position_L;
    public Vector3 Thumb2Position_L;
    public Vector3 Thumb3Position_L;
    public Vector3 Middle1Position_L;
    public Vector3 Middle2Position_L;
    public Vector3 Middle3Position_L;
    public Vector3 Ring1Position_L;
    public Vector3 Ring2Position_L;
    public Vector3 Ring3Position_L;
    public Vector3 Pinky0Position_L;
    public Vector3 Pinky1Position_L;
    public Vector3 Pinky2Position_L;
    public Vector3 Pinky3Position_L;

    public RealtimeHandData(int FrameNumber, Vector3 HandPosition,
        Vector3 WristPosition,
        Vector3 ForearmStubPosition,
        Vector3 Index1Position,
        Vector3 Index2Position,
        Vector3 Index3Position,
        Vector3 Thumb0Position,
        Vector3 Thumb1Position,
        Vector3 Thumb2Position,
        Vector3 Thumb3Position,
        Vector3 Middle1Position,
        Vector3 Middle2Position,
        Vector3 Middle3Position,
        Vector3 Ring1Position,
        Vector3 Ring2Position,
        Vector3 Ring3Position,
        Vector3 Pinky0Position,
        Vector3 Pinky1Position,
        Vector3 Pinky2Position,
        Vector3 Pinky3Position,

        Vector3 HandPosition_L,
        Vector3 WristPosition_L,
        Vector3 ForearmStubPosition_L,
        Vector3 Index1Position_L,
        Vector3 Index2Position_L,
        Vector3 Index3Position_L,
        Vector3 Thumb0Position_L,
        Vector3 Thumb1Position_L,
        Vector3 Thumb2Position_L,
        Vector3 Thumb3Position_L,
        Vector3 Middle1Position_L,
        Vector3 Middle2Position_L,
        Vector3 Middle3Position_L,
        Vector3 Ring1Position_L,
        Vector3 Ring2Position_L,
        Vector3 Ring3Position_L,
        Vector3 Pinky0Position_L,
        Vector3 Pinky1Position_L,
        Vector3 Pinky2Position_L,
        Vector3 Pinky3Position_L
        )
    {
        this.FrameNumber = FrameNumber;
        this.HandPosition = HandPosition;

        this.WristPosition = WristPosition;
        this.ForearmStubPosition = ForearmStubPosition;
        this.Index1Position = Index1Position;
        this.Index2Position = Index2Position;
        this.Index3Position = Index3Position;
        this.Thumb0Position = Thumb0Position;
        this.Thumb1Position = Thumb1Position;
        this.Thumb2Position = Thumb2Position;
        this.Thumb3Position = Thumb3Position;
        this.Middle1Position = Middle1Position;
        this.Middle2Position = Middle2Position;
        this.Middle3Position = Middle3Position;
        this.Ring1Position = Ring1Position;
        this.Ring2Position = Ring2Position;
        this.Ring3Position = Ring3Position;
        this.Pinky0Position = Pinky0Position;
        this.Pinky1Position = Pinky1Position;
        this.Pinky2Position = Pinky2Position;
        this.Pinky3Position = Pinky3Position;

        this.HandPosition_L = HandPosition_L;
        this.WristPosition_L = WristPosition_L;
        this.ForearmStubPosition_L = ForearmStubPosition_L;
        this.Index1Position_L = Index1Position_L;
        this.Index2Position_L = Index2Position_L;
        this.Index3Position_L = Index3Position_L;
        this.Thumb0Position_L = Thumb0Position_L;
        this.Thumb1Position_L = Thumb1Position_L;
        this.Thumb2Position_L = Thumb2Position_L;
        this.Thumb3Position_L = Thumb3Position_L;
        this.Middle1Position_L = Middle1Position_L;
        this.Middle2Position_L = Middle2Position_L;
        this.Middle3Position_L = Middle3Position_L;
        this.Ring1Position_L = Ring1Position_L;
        this.Ring2Position_L = Ring2Position_L;
        this.Ring3Position_L = Ring3Position_L;
        this.Pinky0Position_L = Pinky0Position_L;
        this.Pinky1Position_L = Pinky1Position_L;
        this.Pinky2Position_L = Pinky2Position_L;
        this.Pinky3Position_L = Pinky3Position_L;
    }


    #region CONSTRUCTOR OVERLOAD
    public RealtimeHandData(int FrameNumber, Vector3 HandPosition,
        Vector3 WristPosition,
        Vector3 ForearmStubPosition,
        Vector3 Index1Position,
        Vector3 Index2Position,
        Vector3 Index3Position,
        Vector3 Thumb0Position,
        Vector3 Thumb1Position,
        Vector3 Thumb2Position,
        Vector3 Thumb3Position,
        Vector3 Middle1Position,
        Vector3 Middle2Position,
        Vector3 Middle3Position,
        Vector3 Ring1Position,
        Vector3 Ring2Position,
        Vector3 Ring3Position,
        Vector3 Pinky0Position,
        Vector3 Pinky1Position,
        Vector3 Pinky2Position,
        Vector3 Pinky3Position)
    {
        this.FrameNumber = FrameNumber;
        this.HandPosition = HandPosition;

        this.WristPosition = WristPosition;
        this.ForearmStubPosition = ForearmStubPosition;
        this.Index1Position = Index1Position;
        this.Index2Position = Index2Position;
        this.Index3Position = Index3Position;
        this.Thumb0Position = Thumb0Position;
        this.Thumb1Position = Thumb1Position;
        this.Thumb2Position = Thumb2Position;
        this.Thumb3Position = Thumb3Position;
        this.Middle1Position = Middle1Position;
        this.Middle2Position = Middle2Position;
        this.Middle3Position = Middle3Position;
        this.Ring1Position = Ring1Position;
        this.Ring2Position = Ring2Position;
        this.Ring3Position = Ring3Position;
        this.Pinky0Position = Pinky0Position;
        this.Pinky1Position = Pinky1Position;
        this.Pinky2Position = Pinky2Position;
        this.Pinky3Position = Pinky3Position;
    }
    #endregion
}
