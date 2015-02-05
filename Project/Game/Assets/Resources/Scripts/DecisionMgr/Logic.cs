using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Logic {

	public List<Condition> Conditions;
	public List<Response> Responses;
	public bool activated;

	public bool HasCondition()
	{
		return (Conditions != null);
	}

	public bool HasResponse()
	{
		return (Responses != null);
	}

	public void DispatchResponses()
	{
		foreach (Response r in Responses)
		{
			r.dispatch ();
		}
	}
	
	public bool EvalConditions()
	{
		// assume all conditions are true
		bool rval = true;
		foreach (Condition c in Conditions)
		{
			bool result = c.eval();

			// if we find a false one, it means the entire 'poly expression' is false, so don't fire results
			if (result == false)
			{
				rval = false;
				break;
			}
		}

		return rval;
	}

	public bool VerifyCondition()
	{
		bool rval = false;
		if (HasCondition ()) //if all conditions are true
		{
			bool result = EvalConditions ();

			if (result == true)
			{
				if ( HasResponse())
				{
					DispatchResponses();
					rval = true;
				}
			}
		}

		return rval;
	}
}
