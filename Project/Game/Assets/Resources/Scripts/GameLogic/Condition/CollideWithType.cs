using UnityEngine;
using System.Collections;

public class CollideWithType : Condition {

	public string objType;
	private Component typeComp;

	public void OnEnable()
	{
		typeComp = GetComponent(objType);
	}

	public override bool eval()
	{
		bool rval = false;
		
		return rval;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
