using UnityEngine;

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
