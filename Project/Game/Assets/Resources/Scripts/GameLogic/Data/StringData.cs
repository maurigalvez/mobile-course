using UnityEngine;
using System.Collections;

public class StringData : Data {

	public string data;
	public string Get()
	{
		return data;
	}

	public void Set(string d)
	{
		data = d;
	}
}
