using UnityEngine;
using System.Collections;

public class SendMessageResponse : Response
{

   public string message;     // Message to send when dispatched

   public override void dispatch()
   {
      if (message != "")
         SendMessage(message);
   }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
