using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectionData : Data {

	public List<CollectionEntry> data;

	public void OnEnable()
	{
	}

	// Use this for initialization
	void Start () {
	

	}

	// called on IsInventoriable items...
	public void Insert(Mixin m)
	{
		// if name of IsInventoriable component is unique, insert in unique slot
		// otherwise, stack
		bool found = false;
		foreach (CollectionEntry e in data)
		{
			// if this the right collection
			if (m.name == e.name)
			{
				// insert it
				e.Add(m);
				found = true;
				break;
			}
		}

		// unique item, insert at end of list
		if (!found)
		{
			data.Add ( new CollectionEntry());

			// insert at end of data
			int index = data.Count-1;
			CollectionEntry e = data[index];
			e.init ();
			e.Add (m); //add inventory item at end
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
