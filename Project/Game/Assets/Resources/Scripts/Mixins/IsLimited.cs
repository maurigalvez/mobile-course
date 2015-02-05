using UnityEngine;
using System.Collections;

public class IsLimited : Mixin
{
    public bool isActive;                   // True if its active, false otherwise.
    public FloatData value;                 // Value to reduce
    public float reduceRate;            // Value to be reduced per timeRate
    public float timeRate;                  // How often it will be reduced and applied
    public IsBuffable buffs;                // List of buffs
    private float t;                        // Current Timer

	// Use this for initialization
	void Start () 
    {
	
	}
	private void init()
    {
        isActive = false;
        t = 0.0f;
    }
	// Update is called once per frame
	void Update () 
    {
        // check if its active
        if (isActive)
        {
            // check for value and timer
            if (value.data > 0)
            {
                // check if timer is zero
                if (t < 0.0f)
                {
                    t = timeRate;
                    Dispatch();
                }
                else
                    t -= Time.deltaTime;
            }
            else
                Destroy(this.gameObject);
        }
	}
    //=============
    // ACTIVATE
    //=============   
    public void Activate()
    {
        isActive = true;
        t = timeRate;
    }
    //=============
    // DEACTIVATE
    //=============   
    public void Deactivate()
    {
        isActive = false;
    }
    //=============
    // DISPATCH
    //=============
    private void Dispatch()
    {
        // reduce value
        value.data -= reduceRate;
        // check if there are any buffs
        if(buffs)
        {
            // obtain recipient if buffs do not have one
            if (!buffs.GetRecipient())
                buffs.SetRecipient(GetRecipient());
            // apply
            buffs.Apply();
        }
    }
}
