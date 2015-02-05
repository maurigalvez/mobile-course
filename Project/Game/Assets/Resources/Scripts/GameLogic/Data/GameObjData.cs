using UnityEngine;
using System.Collections;

public class GameObjData : Data {

	public GameObject data;
	public GameObject Get()
	{
		return data;
	}
	
	public void Set(GameObject d)
	{
		data = d;
	}

	public void OnEnable()
	{
		if (data == null)
			data = this.gameObject;
	}
}
