using UnityEngine;
using System.Collections;

public class ForceResponse : Response {

	public Vector3 force;
	public GameObject obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void dispatch()
	{
		if (obj)
		{
			obj.rigidbody.AddForce(force);
		}
	}

}
