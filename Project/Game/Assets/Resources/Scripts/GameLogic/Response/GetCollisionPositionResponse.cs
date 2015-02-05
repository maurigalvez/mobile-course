using UnityEngine;
using System.Collections;

public class GetCollisionPositionResponse : Response {

	public CollisionCondition con;
	public GameObjData data;

	public override void dispatch()
	{
		if (con)
		{
			if (data)
			{
				GameObject go = data.Get ();
				if (go == null)
					go = new GameObject();
				else
					go = data.Get ();

				go.transform.position = con.GetHelper ().data.data.contacts[0].point;
				go.transform.rotation = Quaternion.FromToRotation(Vector3.up, con.GetHelper ().data.data.contacts[0].normal);
				data.Set (go);
			}
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
