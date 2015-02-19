using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IsPassive : Mixin 
{
	public bool isActive;
	public IsBuffable buffs;
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

   public void ExpireOverTime()
   {
      // find all buffs on target and remove them when timer expires
      Data[] buffs = GetComponents<Data>();

      foreach (Data d in buffs)
      {
         //
         //	find variables that match (by name)
         //
         Data[] attributes = GetRecipient().GetComponents<Data>();
         foreach (Data attrib in attributes)
         {
            if (attrib.name == d.name)
            {
               IntData id = (attrib as IntData);
               if (id)
                  (id as IntData).Set(-(d as IntData).Get());

               FloatData fd = (attrib as FloatData);
               if (fd)
                  (fd as FloatData).Set(-(d as FloatData).Get());
            }
         }
      }

      Destroy(this.gameObject);
   }
}
