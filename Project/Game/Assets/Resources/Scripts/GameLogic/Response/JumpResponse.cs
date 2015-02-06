using UnityEngine;
using System.Collections;
/// <summary>
/// Class in charge of managing a Jump Response 
/// </summary>
public class JumpResponse : Response
{
   public FloatData power;             // Player float data
   public float magnitude;             // Magnitude of jump
   public GameObject obj;              // Game Object that will jump

   public override void dispatch()
   {
      // check if there's an object
      if(obj)
      {
         // check if there's FloatData
         if(power)
         {
            // apply force
            obj.rigidbody.AddRelativeForce(new Vector3(0, power.data * magnitude, 0));
         }
      }
   }	
}
