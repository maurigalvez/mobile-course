using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class IsDoor : Mixin
{
   public List<string> TouchTypes;
   public GameObject destination;               // Destination of this door
   public Transform destScreen;                 // Screen of destination
   public bool isActive = false;                // True if it's active, false otherwise.
   public float offset;
	// Use this for initialization
	void Start () 
   {
      init();
	}

   private void init()
   {

      // check if there's a destination
      if (!destination)
         Debug.LogError("Destination for door has not been set!!");
   }
	
   private void OnTriggerEnter2D(Collider2D other)
   {
      foreach (string s in TouchTypes)
      {
         if (other.gameObject.GetComponent(s))
         {           
            Vector3 newPosition = destination.transform.position;
            //---------------
            // transport to destination
            //----------------
            other.gameObject.transform.position = new Vector3(newPosition.x, newPosition.y + offset, newPosition.z);
            // get IsDoorComponent
         }
      }
   }
	// Update is called once per frame
	void Update () {
	
	}
}
