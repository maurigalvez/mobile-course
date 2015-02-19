using UnityEngine;
using System.Collections;

public class LaunchProjectileResponse : Response
{
   public enum eDirection
   {
      Forward,
      Right,
      Back,
      Left,
   }

   public Transform recipient;              // Recipient that will launch the arrow
   public eDirection direction2D;           // Direction that projectile will be launched with respect to the recipient
   public GameObject projectile;            // Prefab projectile to  be launched
   public float magnitude;                  // Force magnitude to be applied
   public bool switch3D;                    // True if it's on 3D, false if it's on 2D
   
   public override void dispatch()
   {
      // check if recipient was provided
      if (recipient)
      {
         // check if a projectile hasn't been provided
         if (!projectile)
         {
            // send message
            Debug.LogError("Projectile prefab has not been provided!");
            return;
         }
         else
         {
            // Instantiate projectile
            GameObject proj = (GameObject)GameObject.Instantiate(projectile, recipient.position, recipient.rotation);
            // Apply force
            if(switch3D == true)
            {
               // obtain rigid body from projectile
               Rigidbody rb = proj.GetComponent<Rigidbody>();
               // check if there's a rigidbody
               if (rb)
               {
                  rb.AddForce(recipient.forward * magnitude);
               }//rigidbody check
            }//is 3D
            else
            {
               // obtain rigidbody 2d
               Rigidbody2D rb2d = proj.GetComponent<Rigidbody2D>();
               // check if rigidbody is not null
               if(rb2d)
               {
                  // launch depending on direction
                  switch(direction2D)
                  {
                     case eDirection.Forward:
                        rb2d.AddForce(-recipient.up  * magnitude);
                     break;

                     case eDirection.Back:
                        rb2d.AddForce(recipient.up * magnitude);
                     break;

                     case eDirection.Right:
                        rb2d.AddForce(recipient.right * magnitude);
                     break;

                     case eDirection.Left:
                        rb2d.AddForce(-recipient.right * magnitude);
                     break;
                  }//switch direction
               }//rb2d
            }//not3D
         }//projectile added
      }//recipient assigned
      else
         Debug.LogError("Recipient has not been assigned!");
   }
}
