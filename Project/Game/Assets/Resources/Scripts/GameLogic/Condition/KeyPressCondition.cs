using UnityEngine;
using System.Collections;

public class KeyPressCondition : Condition {

	public KeyCode key;

	public override bool eval()
	{
		bool rval = false;
		if (Input.GetKeyDown (key))
			rval = true;

		return rval;
	}
}
