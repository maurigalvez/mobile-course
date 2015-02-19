using UnityEngine;
using System.Collections;

// if condition is true - consume item

public class PotionCondition : ItemUsageCondition
{
   public IntData curHP;
   public IntData maxHP;

   public bool CheckUsage()
   {
      // regenerate HP only if user has current HP < MaxHP
      if (curHP.data < maxHP.data)
      {
         return true;
      }

      return false;
   }

   public void CheckHP()
   {
      if (curHP.data > maxHP.data)
      {
         // HP correction
         curHP.Set(maxHP.data);
      }
   }

	void Start () 
   {
	}
	
	void Update () 
   {	
	}
}
