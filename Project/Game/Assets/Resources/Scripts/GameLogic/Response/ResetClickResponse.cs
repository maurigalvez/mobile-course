using UnityEngine;
using System.Collections;

public class ResetClickResponse : Response {

	public Condition con;
	
	public override void dispatch()
	{
		if (con)
		{
			OnMouseDownHelper h = (con as OnClickCondition).GetHelper();
			if (h)
			{
				h.hasBeenClicked = false;
			}
		}
	}
}
