using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IsEquipable : Mixin 
{
   public bool isEquiped = false;
   public string Equipmsg;
   public string dEquipmsg;
	public void Equip()
	{
      SendMessage(Equipmsg);
	}

	public void DeQuip()
	{
      SendMessage(dEquipmsg);
	}
	
   public void Use()
   {
      
   }
	void Start () 
   {}
	
	void Update () 
   {
      if (isEquiped)
         Equip();
      else
         DeQuip();
   }

  
}
