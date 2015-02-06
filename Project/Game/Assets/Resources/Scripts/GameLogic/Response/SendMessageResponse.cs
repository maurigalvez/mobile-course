using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SendMessageResponse : Response
{

   public List<string> messages;     // Messages to send when dispatched

   public override void dispatch()
   {
       // iterate over list
       foreach(string msg in messages)
       {
           // check if message is not empty
           if (msg != "")
               SendMessage(msg);
       }
      
   }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
