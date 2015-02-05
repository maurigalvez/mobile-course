using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class CollisionResponse : Response {

	public GameObject Obj;        // object that contains Collision data
   public GameObject colStorage; // object that will be used to store collision position data!! 
	public string ObjTypeName;  // 
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

      // CollisionHelper = CollisionData - Collision

      // cast Obj to appropriate reference and look for property to modify
      CollisionHelper c = Obj.GetComponent(ObjTypeName) as CollisionHelper;
      Collision tempCol = c.data.data;
      
      PropertyInfo[] properties = tempCol.GetType().GetProperties(flags);
      foreach (PropertyInfo propertyInfo in properties)
      {
         //Debug.Log("Obj: " + Obj.name + ", Property: " + propertyInfo.Name);

         // find the property on the component of ObjTypeName, and set it's value to propertyValue
         if (propertyInfo.Name == propertyName)
         {
            //propertyInfo.SetValue(c, Convert.ChangeType(propertyValue, propertyInfo.PropertyType), null);
            ContactPoint[] cPoints = propertyInfo.GetValue(tempCol, null) as ContactPoint[];
            colStorage.transform.position = cPoints[0].point;
         }
      }
   }
}
