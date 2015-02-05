using UnityEngine;
using System.Collections;
/// <summary>
/// Class in charge of checking distance between two objects
/// </summary>
public class DistanceCondition : Condition 
{
   public Transform obj1;
   public Transform obj2;
   public float distance;

   public override bool eval()
   {
      bool rval = false;
      // check if both objects exists
      if(obj1 && obj2)
      {
         // obtain distance between both
         float dist = Vector3.Distance(obj1.position, obj2.position);        
         // check if distance is lower than given
         if(dist < distance)
         {
            rval = true;
         }
      }
      return rval;
   }

}
