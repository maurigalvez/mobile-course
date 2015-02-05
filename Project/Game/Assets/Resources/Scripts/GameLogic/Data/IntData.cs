using UnityEngine;
using System.Collections;

public class IntData : Data {

	public int data;
	public int Get()
	{
		return data;
	}
	
	public void Set(int d)
	{
		data = d;
	}

	public void Add(int delta)
	{
		data += delta;
	}
}
