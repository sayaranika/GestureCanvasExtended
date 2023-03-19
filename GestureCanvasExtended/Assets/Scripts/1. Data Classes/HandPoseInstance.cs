public class HandPoseInstance
{
    public HandPose handPose;
    public int frameNumber;
    public int count;

    public HandPoseInstance(HandPose handPoseData, int frameNumber, int count)
    {
        this.handPose = handPoseData;
        this.frameNumber = frameNumber;
        this.count = count;
    }
}
