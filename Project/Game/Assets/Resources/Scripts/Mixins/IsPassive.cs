using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IsPassive : Mixin 
{
	public bool isActive;
	public IsBuffable buffs;
	//public List<Data> buffs;
	public string OnTimeFrameElapsedCB;
	public float timeFrame;
	private float t;

	// Use this for initialization
	void Start () {

	}

	public void OnEnable()
	{
		init();
	}

	public void init()
	{
		t = 0.0f;
		isActive = false;
	}

	public void Activate()
	{
		isActive = true;
		t = timeFrame;
	}

	// Update is called once per frame
	void Update ()
	{
		if (isActive)
		{
			t -= Time.deltaTime;
			if (t <= 0.0f)
			{
				Dispatch ();
				t += timeFrame;
			}
		}
	}

	public void Dispatch()
	{
		if (OnTimeFrameElapsedCB != "")
			SendMessage (OnTimeFrameElapsedCB);

		if (buffs)
		{
			if (!buffs.GetRecipient())
				buffs.SetRecipient (GetRecipient ());

			buffs.Apply();
		}
	}
}
