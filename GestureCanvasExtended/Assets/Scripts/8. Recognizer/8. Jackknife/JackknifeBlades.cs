/// <summary>
/// Jackknife supports a number of different DTW-based measurement techniques.
/// Select an approach that is appropriate for your situation by setting the
/// associated options in this structure.
/// </summary>

using System;

[Serializable]
public class JackknifeBlades 
{

    /**
     * No matter which measure is used, the trajectory is first resampled
     * to a fixed number of points.
     */
    public int ResampleCnt;

    /**
     * Sakoe-Chiba band size. This is one type of constraint that specifies
     * how much warping is allowed between two time series. A common value
     * is 10% of the resample_cnt.
     */
    public int Radius;

    /**
     * Utilize the squared Euclidean distance measure. This flag is mutually
     * exclusive with the inner product flag.
     */
    public bool EuclideanDistance;

    /**
     * Z-score normalize the resampled points. If using Euclidean distance,
     * you will normally need to do this. Not recommended for inner product
     * measures though.
     */
    public bool ZNormalize;

    /**
         * Extract and normalize the direction vectors between the resampled
         * points, and use the inner product of the direction vectors. Note,
         * this flag is mutually exclusive with the Euclidean distance flag.
         */
    public bool InnerProduct;

    /**
     * Use lower bounding to cull full DTW evaluations.
     */
    public bool LowerBound;

    /**
     * Utilize the absolute distance correction factor -- the distance
     * traversed by each component in a time series.
     */
    public bool CFAbsDistance;

    /**
    * Utilize the bounding box width correction factor -- the difference
    * between the maximum and minimum value of each component.
    */
    public bool CFBbWidths;

    /**
         * Setup defaults for inner product measure.
         */
    public void SetIPDefaults()
    {
        ResampleCnt = 16;
        Radius = 2;
        EuclideanDistance = false;
        ZNormalize = false;
        InnerProduct = true;
        LowerBound = true;
        CFAbsDistance = true;
        CFBbWidths = true;
    }

    /**
     * Setup defaults for Euclidean distance measure.
     */
    public void SetEDDefaults()
    {
        ResampleCnt = 16;
        Radius = 2;
        EuclideanDistance = true;
        ZNormalize = true;
        InnerProduct = false;
        LowerBound = true;
        CFAbsDistance = true;
        CFBbWidths = true;
    }
}
