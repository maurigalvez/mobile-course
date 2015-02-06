using UnityEngine;
using System.Collections;

public class AnimatorSetBoolResponse : Response {

	public bool value;
	public string propertyName;
	private Animator anim;

	public override void dispatch()
	{
		if (anim)
		{
			anim.SetBool (propertyName, value);
		}
		else
			Debug.Log ("AnimatorSetBoolResponse::dispatch(): Error, animator == null.  Must be attached to an obj with no animator...");
	}

	public void OnEnable()
	{
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
