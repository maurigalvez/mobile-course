using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Class in charge of processing triggable objects 
/// </summary>
public class IsTriggable : Mixin
{

    public List<string> triggerTypes;           // types that can trigger event
    public string onTriggerOn;                  // Message to be sent when TriggerEnter
    public string onTriggerOff;                 // Message to be sent when TriggerExit
    public bool isTriggered = false;            // True when istriggered, false otherwise.

    public void OnEnable()
    {
        isTriggered = false;
    }
    //================
    // ON TRIGGER ENTER
    //================
    public void OnTriggerEnter(Collider col)
    {
        foreach(string s in triggerTypes)
        {
            // Check if the other object has a component in triggerTypes
            if(col.gameObject.GetComponent(s))
            {
                // pass reference to this if its FloatLimited
                IsLimited fl = GetComponent<IsLimited>();
                if (fl)
                    // set recipient
                    fl.SetRecipient(col.gameObject);

                isTriggered = true;
                // send message
                SendMessage(onTriggerOn);
            }//check component
        }//triggerTypes
    }
    //================
    // ON TRIGGER EXIT
    //================
    public void OnTriggerExit(Collider col)
    {
        foreach (string s in triggerTypes)
        {
            // Check if the other object has a component in triggerTypes
            if (col.gameObject.GetComponent(s))
            {
                // check if it has been triggered
                if (isTriggered)
                {                    
                    //trigger off
                    isTriggered = false;
                    SendMessage(onTriggerOff);
                }//triggeroff
            }//check component
        }//triggerTypes
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
