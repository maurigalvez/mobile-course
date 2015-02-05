using UnityEngine;
using System.Collections;

/*
 * Abstract base class for Pickups (loot on the map) and items in player's inventory
 */

public abstract class InventoryObject : MonoBehaviour
{
   // is the item currently in use
   protected bool isActive = false;

   protected bool getIsActive () 
   {
      return isActive;
	}

   protected void setIsActive(bool active)
   {
      isActive = active;
	}
}
