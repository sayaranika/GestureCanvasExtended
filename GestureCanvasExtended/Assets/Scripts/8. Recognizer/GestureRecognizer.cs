using UnityEngine;
using CI.TaskParallel;
using System.Collections.Generic;
using System.Collections;


public class GestureRecognizer : MonoBehaviour
{
    [SerializeField] RealtimeData realtimeData;
    configuartion_parameters_t parameters;
    public Jackknife jackknife_R;
    public Jackknife jackknife_L;

    #region TRAIN
    public bool trained_R = true;
    public bool trained_L = true;
    public void Train(Handedness handedness)
    {
        if (handedness == Handedness.Right)
        {
            StartCoroutine(StartTraining(GestureDataset.GestureDataset_R, jackknife_R, handedness));
        }
        if (handedness == Handedness.Left) StartCoroutine(StartTraining(GestureDataset.GestureDataset_L, jackknife_L, handedness));

    }

    IEnumerator StartTraining(Dataset dataset, Jackknife jackknife, Handedness handedness)
    {
        JackknifeBlades blades = new JackknifeBlades();
        blades.SetIPDefaults();
        jackknife = new Jackknife(blades);

        foreach (int gesture in dataset.Gestures)
        {
            List<Sample> sampleList = dataset.SamplesByGesture[gesture];

            foreach (Sample sample in sampleList)
            {
                jackknife.AddTemplate(sample);
            }
        }

        parameters = new configuartion_parameters_t(2);
        jackknife.Train(6, 2, 1.00);

        if (handedness == Handedness.Right)
        {
            ClipHandler.ClipList[0].GestureRecognizer_R = jackknife;
            trained_R = true;
        }

        if (handedness == Handedness.Left)
        {
            ClipHandler.ClipList[0].GestureRecognizer_L = jackknife;
            trained_L = true;
        }
        yield return null;
    }

    #endregion

    /*#region CLASSIFY
    public bool recognizing_R = false;
    public bool recognizing_L = false;

    public bool Recognize(Handedness handedness, int expectedGestureId, bool isConditionSetToTrue)
    {
        bool isRecognized = false;
        if (handedness == Handedness.Right)
        {
            UnityTask.Run(() =>
            {
                isRecognized = ClassifyGesture_R(expectedGestureId, isConditionSetToTrue);
            });
        }

        else
        {
            UnityTask.Run(() =>
            {
                isRecognized = ClassifyGesture_L(expectedGestureId, isConditionSetToTrue);
            });
        }

        return isRecognized;
    }


    public bool ClassifyGesture_R(int expectedGestureId, bool isConditionSetToTrue)
    {
        Debug.Log("500: [Right] entered classifier");
        recognizing_R = true;
        List<Vector> points = new List<Vector>();

        List<Frame> frames = new List<Frame>();

        List<Vector> buffer = new List<Vector>();

        while (realtimeData.ProducerDataStream_R.Count != 0)
        {
            //Debug.Log("500: [Right] entered producerstream");
            GestureStream p = realtimeData.ProducerDataStream_R.Dequeue();

            points.Add(p.point);

            frames.Add(new Frame(p.point));
        }
        if (points.Count > 2)
        {
            //Debug.Log("500: [Right] entered points > 2");
            ExponentialMovingAverage filter = new ExponentialMovingAverage(frames[0].pt);
            Vector pts;
            //Debug.Log("800C");
            for (int s = 0; s < points.Count; s++)
            {
                pts = filter.Filter(points[s], 1 / (double)parameters.fps);
                buffer.Add(pts);

            }
            //Debug.Log("800D");
            int detectedId = ClipHandler.ClipList[0].GestureRecognizer_R.Classify(buffer);
            Debug.Log("500: [Right] detected id: " + detectedId + " expected id: " + expectedGestureId + " isconditiontrue" + isConditionSetToTrue);
            buffer.Clear();
            recognizing_R = false;

            if(detectedId == expectedGestureId)
            {
                Debug.Log("600: MATCHED!");
                if (isConditionSetToTrue == true) return true;
                else return false;
            }
            else
            {
                return false;
            }

        }
        else
        {
            recognizing_R = false;
            return false;
        }


    }

    public bool ClassifyGesture_L(int expectedGestureId, bool isConditionSetToTrue)
    {
        recognizing_L = true;
        List<Vector> points = new List<Vector>();

        List<Frame> frames = new List<Frame>();

        List<Vector> buffer = new List<Vector>();

        while (realtimeData.ProducerDataStream_L.Count != 0)
        {

            GestureStream p = realtimeData.ProducerDataStream_L.Dequeue();

            points.Add(p.point);

            frames.Add(new Frame(p.point));
        }
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
            int detectedId = ClipHandler.ClipList[0].GestureRecognizer_L.Classify(buffer);
            buffer.Clear();
            recognizing_L = false;

            if (detectedId == expectedGestureId)
            {
                if (isConditionSetToTrue == true) return true;
                else return false;
            }
            else
            {
                if (isConditionSetToTrue == false) return true;
                else return false;
            }

        }
        else
        {
            recognizing_R = false;
            return false;
        }
    }
    #endregion*/

}
