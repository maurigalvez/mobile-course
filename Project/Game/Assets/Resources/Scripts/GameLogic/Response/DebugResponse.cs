using UnityEngine;
using System.Collections;

public class DebugResponse : Response {

	public string outString;

	// Use this for initialization
	public override void dispatch()
	{
		Debug.Log (outString);
	}
}
