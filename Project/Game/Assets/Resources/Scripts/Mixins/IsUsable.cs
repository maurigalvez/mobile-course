using UnityEngine;
using System.Collections;

public class IsUsable : Mixin {

	public bool Use;
	public string OnUseCB;

	// Use this for initialization
	void Start () {
	
	}

	public void IsUsableUpdate()
	{
		if (Use == true)
		{
			if (OnUseCB != "")
			{
				SendMessage (OnUseCB);
				Use = false;
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
		IsUsableUpdate ();
	}
}
