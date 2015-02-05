using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CollectionEntry {

	public int count;
	public string name;
	public List<Mixin> data;

	public void init()
	{
		name = "unassigned";
		data = new List<Mixin>();
	}

	public void Add(Mixin m)
	{
		count++;
		name = m.name; // we store by uniqueness of isInventoriable name
		data.Add (m);
	}

	public void Stack(Mixin m)
	{
		data.Add(m);
	}
}
