using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DecisionMgr : MonoBehaviour {

	public List<Logic>	expressions;

	//
	// loop over all Logic's.  Let the logic evalute condition and dispatch response
	//
	public void DecisionMgrUpdate()
	{
		foreach (Logic e in expressions)
		{
			if (e.activated)
			{
				bool success = e.VerifyCondition();
				{
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
		DecisionMgrUpdate ();
	}
}
