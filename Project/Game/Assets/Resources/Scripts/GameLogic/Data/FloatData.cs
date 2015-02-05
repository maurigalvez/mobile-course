using UnityEngine;
using System.Collections;

public class FloatData : Data {

	public float data;
	public float Get()
	{
		return data;
	}
	
	public void Set(float d)
	{
		data = d;
	}

	public void Add(float delta)
	{
		data += delta;
	}
}
