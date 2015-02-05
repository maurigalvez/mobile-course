using UnityEngine;
using System.Collections;

public class Vector3Data : Data {

	public Vector3 data;
	public Vector3 Get()
	{
		return data;
	}
	
	public void Set(Vector3 d)
	{
		data = d;
	}
}
