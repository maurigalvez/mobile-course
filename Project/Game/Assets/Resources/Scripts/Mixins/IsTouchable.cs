using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IsTouchable : Mixin {

	public List<string> TouchTypes;
	public List<Response> Actions;
	public string OnTouchCB;
	public bool hasTouched = false;

	public void OnEnable()
	{
		hasTouched = false;
	}

	// Use this for initialization
	void Start () {
	
	}

	void IsTouchableUpdate(){}

	public void OnCollisionEnter(Collision other)
	{
		foreach(string s in TouchTypes)
		{
			if (other.gameObject.GetComponent(s))
			{
				// pass reference to this, to consumable if this is consumable
				IsConsumable cons = GetComponent<IsConsumable>();
				if (cons)
					cons.SetRecipient(other.gameObject);

				IsInventoriable inv = GetComponent<IsInventoriable>();
				if (inv)
					inv.SetRecipient(other.gameObject);

				// sendmessage if we actually find a component who can listen for this
				SendMessage (OnTouchCB);
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
		IsTouchableUpdate();
	}
}
