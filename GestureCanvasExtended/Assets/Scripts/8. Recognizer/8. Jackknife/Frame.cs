using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Frame
{
    /**
     * The expected gesture: the gesture that the
     * participant should execute.
     */
    //public int expected_gesture_id;

    /**
     * True if any component in vector is NAN or infinity.
     * This can happen if the input device loses tracking.
     */
    public bool bad_pt;

    /**
     * The actual input! :)
     */
    public Vector pt;

    /**
     *
     */

    public Frame(Vector pt)
    {

        this.pt = pt;

        this.bad_pt = false;
    }
};