using UnityEngine;
using System.Collections;

public class Follows : Mixin
{
   public Transform obj;                 // Object to Follow
   public bool IsFollowing;              // True if its following, false otherwise   
   public FloatData speed;               // Float data containing speed of object
   public float minDistance;             // Distance at which character will stop
   private Vector3 rotDirection;         // Direction of rotation of this object
   public void Follow()
   {
      IsFollowing = true;
   }

   public void Unfollow()
   {
      IsFollowing = false;
   }

	// Use this for initialization
	void Start () 
   {
      rotDirection = new Vector3();
	}
	
	// Update is called once per frame
	void Update () 
   {
      // check if IsFollowing
      if (IsFollowing == true)
         following();
	}

   private void following()
   {
      // move directoin
      Vector3 moveDirection = (obj.position - transform.position).normalized;
      float distance = (obj.position - transform.position).magnitude;
      // check if it hasn't reach minDistance
      if (distance > minDistance)
      {       // rotate
         if (moveDirection != Vector3.zero)
         {
            rotDirection = Vector3.RotateTowards(rotDirection, moveDirection, (speed.data), 1000.0f);
            rotDirection.Normalize();
         }
         if (rotDirection != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(rotDirection);
         // update position
         transform.position = transform.position + moveDirection * distance * Time.deltaTime * speed.data;
      }
   }
}
