/* -----------------------------------------------------------------------------
FILE NAME:      Utils.cs
AUTHOR:         Zach Greenhill
E-MAIL:         zgreenhill@nevada.unr.edu
DESCRIPTION:    Static class of uitilies for other scripts
NOTES:          
---------------------------------------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    

    public static float EPSILON = 0.01f;
    public static bool ApproximatelyEqual(float a, float b)
    {
        return Mathf.Abs(a - b) < EPSILON;
    }

    public static float Clamp(float val, float min, float max)
    {
        if (val < min)
            val = min;
        if (val > max)
            val = max;
        return val;
    }

    public static float AngleDiffPosNeg(float a, float b)
    {
        float diff = a - b;

        if (diff > 180)
            return diff - 360;
        
        if (diff < -180)
            return diff + 360;
        
        return diff;
    }

    public static float Degrees360(float angleDegrees)
    {
        while (angleDegrees >= 360)
            angleDegrees -= 360;
        while (angleDegrees < 0)
            angleDegrees += 360;
        return angleDegrees;
    }

    public static float getComponentHeading(Vector3 a, Vector3 b)
    {
        Vector3 dest = a - b;
        float x = Mathf.Abs(dest.x);
        float z = Mathf.Abs(dest.z);
        float newHeading = Mathf.Atan(x / z) * Mathf.Rad2Deg;
        if (dest.x < 0)
        {
            if (dest.z < 0)
            {
                newHeading += 180;
            }
            else
            {
                newHeading = 360 - newHeading;
            }
        }
        else if (dest.z < 0)
        {
            newHeading += 90;
        }

        return newHeading;
    }
}
