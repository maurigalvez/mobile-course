using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IsConsumable : Mixin
{
   public IsBuffable buffs;

   public void Consume()
   {
      if (buffs)
      {
         // late bind recipient
         if (!buffs.GetRecipient())
            buffs.SetRecipient(GetRecipient());

         buffs.Apply();

         // check if item isPassive
         IsPassive passive = gameObject.GetComponent<IsPassive>();         
         if (passive == null)
         {
            // if not passive - remove from scene after usage
            Destroy(this.gameObject);
         }
         else
         {
            // do not destroy if passive so temp buffs can be applied that expire over time
            passive.Activate();
            passive.SetRecipient(this.GetRecipient());

            // hide after item is collected
            Hide();
         }
      }
   }

   public void Hide()
   {
      // bad, need a way to diable rendering and interaction but still
      // keep update
      gameObject.collider2D.enabled = false;

      if (gameObject.renderer != null)
         gameObject.renderer.enabled = false;
      else
      {
         // get all child renderer components and disable them
         Renderer[] renderers = GetComponentsInChildren<Renderer>() as Renderer[];
         foreach (Renderer r in renderers)
            r.enabled = false;
      }
      //transform.Translate (0.0f, -1000.0f, 0.0f);
   }
}