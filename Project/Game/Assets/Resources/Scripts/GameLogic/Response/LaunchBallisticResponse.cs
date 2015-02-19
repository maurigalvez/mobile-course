using UnityEngine;
using System.Collections;
/// <summary>
/// Class in charge of managing launch of ballistic items
/// </summary>
public class LaunchBallisticResponse : Response
{
   public Transform recipient;
   public DirectionData direction2D;
   public float range;
   public float angle;
   public GameObject projectile;
   public bool switch3D;
   private Vector3 recipientPos;
   public GameObject targetObject;

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
            if (switch3D == true)
            {
               // obtain rigid body from projectile
               Rigidbody rb = proj.GetComponent<Rigidbody>();
               // check if there's a rigidbody
               if (rb)
               {
                  //rb.AddForce(0);
               }//rigidbody check
            }//is 3D
            else
            {
               // obtain rigidbody 2d
               Rigidbody2D rb2d = proj.GetComponent<Rigidbody2D>();
               // ignore collisions
               Physics2D.IgnoreCollision(proj.collider2D, recipient.collider2D);               
               // check if rigidbody is not null
               if (rb2d)
               {
                  // create target
                  Vector3 target = new Vector3();
                  Vector3 targeto = new Vector3();
                  // obtain recipient position
                  recipientPos = recipient.transform.position;
                  // launch depending on direction
                  switch (direction2D.data)
                  {
                     case DirectionData.eDirection.SOUTH:
                        target = new Vector3(recipientPos.x,recipientPos.y - range);
                        targeto = new Vector3(target.x, target.y - 0.2f);
                        GameObject.Instantiate(targetObject, targeto, recipient.rotation);
                        break;

                     case DirectionData.eDirection.NORTH:
                        target = new Vector3(recipientPos.x, recipientPos.y + range);
                        targeto = new Vector3(target.x, target.y - 0.2f);
                        break;

                     case DirectionData.eDirection.EAST:
                        target = new Vector3(recipientPos.x + range, recipientPos.y);
                        targeto = new Vector3(target.x, target.y - 0.2f);
                        GameObject.Instantiate(targetObject, targeto, recipient.rotation);
                        break;

                     case DirectionData.eDirection.WEST:
                        target = new Vector3(recipientPos.x - range, recipientPos.y);
                        targeto = new Vector3(target.x, target.y - 0.2f);
                        GameObject.Instantiate(targetObject, targeto, recipient.rotation);
                        break;
                  }//switch direction               
                  // get target direction
                  Vector3 direction = target - recipientPos;
                  // get height diference
                  float h = direction.y;
                  // get horizontal distance
                  float dist = direction.magnitude;
                  // convert angle to radians
                  float a = angle * Mathf.Deg2Rad;
                  // set direction to the elevation angle
                  direction.y = dist * Mathf.Tan(a);
                  // cprrect for small height differences
                  dist += h / Mathf.Tan(a);
                  // calculate velocity magnitude
                  float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
                  Vector3 vel = velocity * direction.normalized;
                  if (rb2d)
                     rb2d.velocity = vel;                
               }//rb2d
            }//not3D
         }//projectile added
      }//recipient assigned
      else
         Debug.LogError("Recipient has not been assigned!");
   }
	
}
