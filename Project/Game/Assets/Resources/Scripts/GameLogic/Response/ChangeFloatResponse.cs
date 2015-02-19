using UnityEngine;
using System.Collections;
/// <summary>
/// Changes the value of the valueToChange to newValue provided
/// </summary>
public class ChangeFloatResponse : Response
{
   public FloatData newValue;
   public FloatData valueToChange;

   public override void dispatch()
   {
      if (newValue && valueToChange)
         //set new value
         valueToChange.Set(newValue.data);
      else
         Debug.LogError("newValue or valueToChange is not provided!");
   }
}
