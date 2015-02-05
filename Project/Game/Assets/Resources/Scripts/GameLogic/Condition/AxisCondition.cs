using UnityEngine;
using System.Collections;
/// <summary>
/// Class in charge of obtaining the value of the given Axis and store it in given FloatData instance
/// </summary>
public class AxisCondition : Condition 
{
	public string axis;	
	public float thresh = 0.1f;
	public FloatData data;
	
	public override bool eval()
	{
		bool rval = false;
		if (data)
			data.Set (Input.GetAxis (axis));
		
		if (Mathf.Abs (data.Get ()) > thresh)
			rval = true;
		
		return rval;
	}
}
