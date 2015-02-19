using UnityEngine;
using System.Collections;

public class DestroyWhenCollides : Mixin
{

   void OnCollisionEnter2D(Collision2D collision)
   {
      Destroy(this.gameObject);
   }

   void OnCollisionEnter(Collision collision)
   {
      Destroy(this.gameObject);
   }
}
