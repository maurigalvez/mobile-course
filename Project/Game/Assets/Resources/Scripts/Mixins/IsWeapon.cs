using UnityEngine;
using System.Collections;

public class IsWeapon : Mixin
{
   public DamageMessage msg;

	public void OnCollisionEnter(Collision col)
   {
      // Check if this weapon is equipped
      IsEquipable eq = GetComponent<IsEquipable>();
      if(eq)
      {
         // check for eq
         if(eq.isEquip())
         {
            // CHECK IF IT HAS AN ISDAMAGABLE COMP??
            IsDamageable dmg = col.gameObject.GetComponent<IsDamageable>();
            if (dmg)
            {
               dmg.TakeDamage(msg);
            }
         }
      }
   }
}
