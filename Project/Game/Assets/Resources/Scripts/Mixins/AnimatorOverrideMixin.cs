using UnityEngine;
using System.Collections;

public class AnimatorOverrideMixin : Mixin 
{
   public AnimatorOverrideController animToOverride; // equipped state
   private RuntimeAnimatorController defaultCtrl;

   public void overrideAnimation()
   {
      // check if there's a recipient
      if (GetRecipient())
      {
         // Obtain animator component from recipient
         Animator an = GetRecipient().GetComponent<Animator>();
         if (an)
         {
            // obtain default controller
            defaultCtrl = an.runtimeAnimatorController;
            an.runtimeAnimatorController = animToOverride;
         }
      }         
   }
   public void setDefaultAnimation()
   {
      // Obtain animator component from recipient
      Animator an = GetRecipient().GetComponent<Animator>();
      if (an)
         an.runtimeAnimatorController = defaultCtrl;
   }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
