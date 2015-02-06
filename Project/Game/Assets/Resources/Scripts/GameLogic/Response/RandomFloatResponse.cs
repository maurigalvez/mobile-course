using UnityEngine;
using System.Collections;

public class RandomFloatResponse : Response
{
    public float min, max;               // Minimum and maximum values for data
    public FloatData data;               // Float data instance where random value will be stored

    public override void dispatch()
    {
        // check if there's data
        if (data)
            // assign random value
            data.data = Random.Range(min, max);
    }    
}
