using UnityEngine;
using System.Collections;

public class TimerCondition : Condition
{
    public float timeFrame;          // Time frame
    public bool onlyOnce;            // True if condition will run only once, false otherwise
    private bool triggeredOnce;      // True if this condition has been triggerd once
    private float t;                 // current time

	// Use this for initialization
	void Start () 
    {
        init();
	}

    private void init()
    {
        t = timeFrame;        
    }

    public override bool eval()
    {
        bool rval = false;
        //-------------
        // EVALUATE TIMER
        //-------------
        if (t <= 0.0f)
        {
            // check if it has been triggered
            if (triggeredOnce)
            {
                if (!onlyOnce)
                {
                    rval = true;
                    t = timeFrame;
                }
            }
            else
            {
                triggeredOnce = true;
                t = timeFrame;
                rval = true;
            }
        }
        else
            // reduce timer
            t -= Time.deltaTime;
        // return rva;
        return rval;
    }
	// Update is called once per frame
	void Update () 
    {
	
	}

   
}
