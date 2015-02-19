using UnityEngine;
using System.Collections;

public class IsEquipable : Mixin {

	private bool isEquipped;
	public IsBuffable buffs;

	public void Equip()
	{
		if (isEquipped)
			_Dequip();
		else
			_Equip();
	}

	public void _Equip()
	{
		bool success = false;
		IsEquipmentSlot[] slots = FindObjectsOfType(typeof(IsEquipmentSlot)) as IsEquipmentSlot[];
		foreach(IsEquipmentSlot s in slots)
		{
			// if slot names match, then this is a compatible slot.
			// insert if this slot is open
			if (s.name == this.name)
			{
				if (s.IsEmpty())
				{
					s.Insert(this);
					success = true;
              
					break;
				}
			}
		}
		
		if (success)
		{
			// apply one time buffs
			if (buffs)
			{
				if (!buffs.GetRecipient())
					buffs.SetRecipient (GetRecipient ());

				buffs.Apply ();
            isEquipped = true;
			}
         // check if there's an animator override component
         AnimatorOverrideMixin ao = GetComponent<AnimatorOverrideMixin>();
         if (ao)
         {
            // check if there's no recipient
            if (!ao.GetRecipient())
               ao.SetRecipient(GetRecipient());
            // execute
            ao.overrideAnimation();
            isEquipped = true;
         }

         // check if its a weapon
         IsWeapon we = GetComponent<IsWeapon>();
         if(we)
         {
            // check if there's no recipient
            if (!we.GetRecipient())
               we.SetRecipient(GetRecipient());
            // execute
            isEquipped = true;
         }
		}
		else
		{
			Debug.Log("IsEquipable::Equip:  Error, no available slots to insert into! Try unequipping something will ya?");
		}
	}

	public void _Dequip()
	{
		bool success = false;
		IsEquipmentSlot[] slots = FindObjectsOfType(typeof(IsEquipmentSlot)) as IsEquipmentSlot[];
		foreach(IsEquipmentSlot s in slots)
		{
			// if slot names match, then this is a compatible slot.
			// insert if this slot is open
			if (s.name == this.name)
			{
				if (!s.IsEmpty())
				{
					s.Remove();
					success = true;
					break;
				}
			}
		}
		
		if (success)
		{
			// apply one time buffs
			if (buffs)
			{
				if (!buffs.GetRecipient())
					buffs.SetRecipient (GetRecipient ());
				
				buffs.Remove ();
				isEquipped = false;
			}
         // animations
         AnimatorOverrideMixin ao = GetComponent<AnimatorOverrideMixin>();
         if (ao)
         {
            // check if there's no recipient
            if (!ao.GetRecipient())
               ao.SetRecipient(GetRecipient());
            // execute!!!!
            ao.setDefaultAnimation();
            isEquipped = false;
         }
		}
		else
		{
			Debug.Log("IsEquipable::Dequip:  Error, dequip failed...?");
		}
	}
   /// <summary>
   /// Returns true if this item is equipped, false otherwise.
   /// </summary>
   public bool isEquip()
   {
      return isEquipped;
   }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
