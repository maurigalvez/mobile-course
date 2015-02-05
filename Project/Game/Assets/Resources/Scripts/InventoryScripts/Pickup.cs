using UnityEngine;
using System.Collections;

/*
 * Class for Pickups (loot on the map)
 * Items are added to player's inventory based on the pickup type
 */

public class Pickup : InventoryObject
{
   // sprite for display on the scene
   public GameObject image;

   // will be executed if pickup is used ie. isActive = true
   public GameObject script;

   // pickup position on the map
   public Vector2 position;

   public enum PickupType
   {  
      Potion,
      Weapon,
      Gold,
      Key,
      Equipable  // ie PowerBracelet used to move wall segments
   };

   // current object
   public PickupType itemType;

   // spawns pickup on the map
   public GameObject InstantiatePickup(Vector2 _position)
   {
      return Instantiate(image, _position, Quaternion.identity) as GameObject;
   }

   public void setType(PickupType _type)
   {
      itemType = _type;
   }

   public void setScript(GameObject _script)
   {
      script = _script;
   }

   public void AddToInventory()
   {
      // requires player and concrete item classes
   }
}
