using UnityEngine;
using System.Collections;

public class CollisionCondition : Condition{

	public GameObject obj1;
	public GameObject obj2;
	private CollisionHelper helper;

	public CollisionHelper GetHelper()
	{
		return helper;
	}

	public void OnEnable()
	{
		if (obj1)
		{
			helper = obj1.GetComponent<CollisionHelper>();
			if (helper == null)
			{
				helper = obj1.AddComponent<CollisionHelper>();
			}

			if (obj2)
				helper.other = obj2;
		}
	}

	public override bool eval()
	{
		bool rval = false;
		
		if (helper)
		{
			if (helper.hasCollided == true)
				rval = true;
		}
		
		return rval;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
