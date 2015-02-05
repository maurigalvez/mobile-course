using UnityEngine;
using System.Collections;

public class TranslateResponse : Response {

	public GameObject obj;
	public Vector3 axis;
	public Space space;
	public float speed;
	public FloatData data;

	public override void dispatch()
	{
		Vector3 vTrans = data.Get () * speed * axis;
		if (obj)
			obj.transform.Translate(vTrans, space);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
