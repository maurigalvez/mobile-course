using UnityEngine;
using System.Collections;

public class InstantiateResponse : Response {

	public GameObject obj;
	public GameObject instance;
	public GameObject data;

	public override void dispatch()
	{
		if (obj)
		{
			instance = (GameObject)Instantiate (obj, data.transform.position, data.transform.rotation);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
