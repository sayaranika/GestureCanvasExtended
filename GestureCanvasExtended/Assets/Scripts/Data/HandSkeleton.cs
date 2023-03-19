using UnityEngine;

public class HandSkeleton
{
    ////////////////////////////////// POSITIONAL AND ROTATIONAL INFORMATION OF HAND //////////////////////////////////
    public Vector3 HandPosition { get; private set; }
    public Vector3 WristPosition { get; private set; }
    public Vector3 ForearmStubPosition { get; private set; }
    public Vector3 Index1Position { get; private set; }
    public Vector3 Index2Position { get; private set; }
    public Vector3 Index3Position { get; private set; }
    public Vector3 Thumb0Position { get; private set; }
    public Vector3 Thumb1Position { get; private set; }
    public Vector3 Thumb2Position { get; private set; }
    public Vector3 Thumb3Position { get; private set; }
    public Vector3 Middle1Position { get; private set; }
    public Vector3 Middle2Position { get; private set; }
    public Vector3 Middle3Position { get; private set; }
    public Vector3 Ring1Position { get; private set; }
    public Vector3 Ring2Position { get; private set; }
    public Vector3 Ring3Position { get; private set; }
    public Vector3 Pinky0Position { get; private set; }
    public Vector3 Pinky1Position { get; private set; }
    public Vector3 Pinky2Position { get; private set; }
    public Vector3 Pinky3Position { get; private set; }

    public Quaternion HandRotation { get; private set; }
    public Quaternion WristRotation { get; private set; }
    public Quaternion ForearmStubRotation { get; private set; }
    public Quaternion Index1Rotation { get; private set; }
    public Quaternion Index2Rotation { get; private set; }
    public Quaternion Index3Rotation { get; private set; }
    public Quaternion Thumb0Rotation { get; private set; }
    public Quaternion Thumb1Rotation { get; private set; }
    public Quaternion Thumb2Rotation { get; private set; }
    public Quaternion Thumb3Rotation { get; private set; }
    public Quaternion Middle1Rotation { get; private set; }
    public Quaternion Middle2Rotation { get; private set; }
    public Quaternion Middle3Rotation { get; private set; }
    public Quaternion Ring1Rotation { get; private set; }
    public Quaternion Ring2Rotation { get; private set; }
    public Quaternion Ring3Rotation { get; private set; }
    public Quaternion Pinky0Rotation { get; private set; }
    public Quaternion Pinky1Rotation { get; private set; }
    public Quaternion Pinky2Rotation { get; private set; }
    public Quaternion Pinky3Rotation { get; private set; }

    ////////////////////////////////// CONSTRUCTOR //////////////////////////////////

    public HandSkeleton(
        Vector3 HandPosition,
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
        Quaternion HandRotation,
        Quaternion WristRotation,
        Quaternion ForearmStubRotation,
        Quaternion Index1Rotation,
        Quaternion Index2Rotation,
        Quaternion Index3Rotation,
        Quaternion Thumb0Rotation,
        Quaternion Thumb1Rotation,
        Quaternion Thumb2Rotation,
        Quaternion Thumb3Rotation,
        Quaternion Middle1Rotation,
        Quaternion Middle2Rotation,
        Quaternion Middle3Rotation,
        Quaternion Ring1Rotation,
        Quaternion Ring2Rotation,
        Quaternion Ring3Rotation,
        Quaternion Pinky0Rotation,
        Quaternion Pinky1Rotation,
        Quaternion Pinky2Rotation,
        Quaternion Pinky3Rotation
        )
    {
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

        this.HandRotation = HandRotation;
        this.ForearmStubRotation = ForearmStubRotation;
        this.WristRotation = WristRotation;
        this.Index1Rotation = Index1Rotation;
        this.Index2Rotation = Index2Rotation;
        this.Index3Rotation = Index3Rotation;
        this.Thumb0Rotation = Thumb0Rotation;
        this.Thumb1Rotation = Thumb1Rotation;
        this.Thumb2Rotation = Thumb2Rotation;
        this.Thumb3Rotation = Thumb3Rotation;
        this.Middle1Rotation = Middle1Rotation;
        this.Middle2Rotation = Middle2Rotation;
        this.Middle3Rotation = Middle3Rotation;
        this.Ring1Rotation = Ring1Rotation;
        this.Ring2Rotation = Ring2Rotation;
        this.Ring3Rotation = Ring3Rotation;
        this.Pinky0Rotation = Pinky0Rotation;
        this.Pinky1Rotation = Pinky1Rotation;
        this.Pinky2Rotation = Pinky2Rotation;
        this.Pinky3Rotation = Pinky3Rotation;
    }
}
