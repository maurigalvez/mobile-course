using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class ModifyPropertyResponse : Response {

	public GameObject Obj;
	public string ObjTypeName;
	public string propertyName;
	public string propertyValue;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void dispatch()
	{
		const BindingFlags flags = /*BindingFlags.NonPublic | */BindingFlags.Public | 
		BindingFlags.Instance | BindingFlags.Static;

		// cast Obj to appropriate reference and look for property to modify
		Component c = Obj.GetComponent (ObjTypeName);
		PropertyInfo[] properties = c.GetType ().GetProperties (flags);
		foreach (PropertyInfo propertyInfo in properties)
		{
			//Debug.Log("Obj: " + Obj.name + ", Property: " + propertyInfo.Name);

			// find the property on the component of ObjTypeName, and set it's value to propertyValue
			if (propertyInfo.Name == propertyName)
			{
				propertyInfo.SetValue (c, Convert.ChangeType (propertyValue, propertyInfo.PropertyType), null);
			}
		}

	}
}
