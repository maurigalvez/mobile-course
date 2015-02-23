using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IsDamageable : Mixin
{
   public FloatData maxHP;          // Instance of FloatData with maxHP
   public FloatData HP;             // Instance of FloatData with current HP
   public string OnDead;            // Message to be sent on death

   void Start()
   {
      init();
   }

   private void init()
   {
      if (maxHP && HP)
      {
         // initialize data
         HP.data = maxHP.data;
      }
   }

   public void TakeDamage(DamageMessage _dmsg)
   {
      float dmg = _dmsg.damageAmount;
      // compare _dsg type with player's damage resistances
      ResistanceType[] res = GetComponents<ResistanceType>();
      // Iterate over resistances
      foreach(ResistanceType r in res)
      {
         // check if there's a resistance to damage type
         if (r.resType == _dmsg.damageType.dType)
            dmg -= _dmsg.damageAmount * (r.resistanceChance * 0.01f);
      }
      // Deal the damage
      if (HP.data > 0.0f)
         HP.data -= dmg;
      
      // if dead - destroy obj
      if (HP.data <= 0.0f)
         SendMessage(OnDead);
   }

   void Update()
   {

   }
}
