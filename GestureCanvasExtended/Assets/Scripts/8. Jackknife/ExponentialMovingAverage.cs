
using System;

public class ExponentialMovingAverage
{
    public Vector Pt { get; set; }

    public double CutOffFrequencyHz { get; set; }

    /**
     * Constructor that allows you to select the cut off frequency.
     * One Hz may not be optimal but is probably a very good
     * starting point.
     */
    public ExponentialMovingAverage(Vector initialPt, double cuttoff = 1)
    {
        Pt = initialPt.Clone() as Vector;
        CutOffFrequencyHz = cuttoff;
    }

    /**
     * The duration_s parameter is the duration between the previous
     * and current points in seconds. If the exact time stamps are
     * unavailable, you can estimate using the input device sampling
     * rate, e.g., 1/30.
     */
    public Vector Filter(Vector pt, double durationS)
    {
        double tau = 1.0 / (2.0 * Math.PI * CutOffFrequencyHz);
        double alpha = 1.0 / (1.0 + tau / durationS);
        this.Pt = (pt * alpha) + (this.Pt * (1 - alpha));

        return this.Pt;
    }
}
