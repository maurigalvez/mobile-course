using UnityEngine;
using System.Collections;

public class OnMouseDownHelper : ConditionHelper {

	public bool hasBeenClicked = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEnable()
	{
		Reset ();
	}

	public void Reset()
	{
		hasBeenClicked = false;
	}

	public void OnMouseDown()
	{
		hasBeenClicked = true;
	}
}
