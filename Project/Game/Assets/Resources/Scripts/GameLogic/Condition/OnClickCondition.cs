using UnityEngine;
using System.Collections;

public class OnClickCondition : Condition {

	public GameObject obj;
	private OnMouseDownHelper helper;

	public OnMouseDownHelper GetHelper()
	{
		return helper;
	}

	public void OnEnable()
	{
		if (obj)
		{
			helper = obj.GetComponent<OnMouseDownHelper>();
			if (helper == null)
			{
				helper = obj.AddComponent<OnMouseDownHelper>();
			}
		}
	}

	public override bool eval()
	{
		bool rval = false;

		if (helper)
		{
			if (helper.hasBeenClicked == true)
				rval = true;
		}

		return rval;
	}
}
