using UnityEngine;
using System.Collections;

public class MousePositionResponse : Response
{
    public Transform obj;               // Object to translate to mouse position
	
    public override void dispatch()
    {
        // check that there's an instance of Vector3Data
       if (obj)
       {
          // obtain mouse position
          //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          //Debug.Log("Ray  x: " + ray.origin.x + " z: " + ray.origin.z);

          RaycastHit hit;
          if(Physics.Raycast(ray, out hit, 200f))
          {
             //Debug.Log("Hit  x: " + hit.point.x + " z: " + hit.point.z);
             obj.position = new Vector3(hit.point.x, obj.position.y, hit.point.z);
          }
          
       }
    }
    // Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
