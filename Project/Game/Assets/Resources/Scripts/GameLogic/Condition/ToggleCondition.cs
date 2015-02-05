using UnityEngine;
using System.Collections;

public class ToggleCondition : Condition {

	public bool toggle;

	public override bool eval()
	{
		return toggle;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
