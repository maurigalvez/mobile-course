using UnityEngine;
using System.Collections;

public class FloatAnimationResponse : Response 
{
   public string property;
   public FloatData data;
   private Animator _animator;

   public override void dispatch()
   {
      // check fo animator
      if(_animator)
      {
         // check for data
         if(data)
         {
            _animator.SetFloat(property, data.data * 0.01f);
         }
      }
   }
   public void OnEnable()
   {
      // obtain animator
      _animator = GetComponent<Animator>();
   }		
}
