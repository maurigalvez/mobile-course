using UnityEngine;
using System.Collections;

public class RotateResponse : Response 
{

   public Transform obj;                      // object to rotate
   public float rotationSpeed;                // speed to rotate at
   public FloatData forwardValue;                // Value of axis to rotate at 
   public FloatData rightValue;
   private Vector3 rotDirection;
   public override void dispatch()
   {
      if (!obj)
      {
         Debug.LogError("Object to rotate has not been provided");
         return;
      }
      if(!forwardValue || !rightValue)
      {
         Debug.LogError("Axis Value for rotation has not been assigned");
         return;
      }
  
      // obtain moveDirection
      Vector3 moveDirection = forwardValue.data * Vector3.forward + rightValue.data * Vector3.right;
      rotDirection = Vector3.zero;
      // check if moveDirection != zero
      if(moveDirection != Vector3.zero)
      {
         rotDirection = Vector3.RotateTowards(rotDirection, moveDirection, (rotationSpeed), 1000.0f);
         rotDirection.Normalize();
      }
      if (rotDirection != Vector3.zero)
         obj.transform.rotation = Quaternion.LookRotation(rotDirection);
            
   }
}
