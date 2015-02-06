using UnityEngine;
using System.Collections;

public class DecreaseFloatResponse : Response
{
    public float decreaseRate;              // Value to be reduced from data
    public FloatData data;                  // Instance of floatData containing data


    public override void dispatch()
    {
        // check if there's data
        if (data)
        {
            // check if data is higher than zero
            if(data.data > 0.0f)
                // reduce
                data.data -= decreaseRate;
        }
    }
}
