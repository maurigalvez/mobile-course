using UnityEngine;
using System.Collections;

public class CollisionHelper : ConditionHelper {

	public GameObject other;
	public bool hasCollided = false;
	public CollisionData data;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter(Collision col)
	{
		if (col.collider.gameObject == other)
		{
			if (data)
				data.Set(col);
			hasCollided = true;
		}
	}
}
