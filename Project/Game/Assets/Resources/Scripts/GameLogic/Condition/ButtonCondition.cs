using UnityEngine;
using System.Collections;

public class ButtonCondition : Condition
{
   public enum eButton
   {
      Down,
      Up,
   }
   public string buttonName;
   public eButton condition;

   public override bool eval()
   {
      bool rval = false;
      //-----------
      // EVALUATE CONDITION
      //-----------
      switch(condition)
      {
         case eButton.Down:
            rval = Input.GetButtonDown(buttonName);
         break;

         case eButton.Up:
            rval = Input.GetButtonUp(buttonName);
         break;
      }
      return rval;
   }
}
