using UnityEngine;
using System.Collections;

public class MouseCondition : Condition
{
    public enum eMouseButton
    {
        right, 
        left,
        middle
    }
    public eMouseButton mouseButton;
//    public BoolData data;
    public override bool eval()
    {
        bool rval = false;
       
        //------------
        // switch mousebutton
        //-------------
        switch(mouseButton)
        {
            case eMouseButton.left:
                rval = Input.GetMouseButtonDown(0);
            break;

            case eMouseButton.right:
                rval = Input.GetMouseButtonDown(1);
            break;

            case eMouseButton.middle:
                rval = Input.GetMouseButtonDown(2);
            break;
        }
      //  data.data = rval;
        return rval;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
