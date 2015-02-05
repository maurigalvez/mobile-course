using UnityEngine;
using System.Collections;

public class GUiTextData : Data {

	public GUIText data;
	public GUIText Get()
	{
		return data;
	}

	public void Set(GUIText d)
	{
		data = d;
	}
}
