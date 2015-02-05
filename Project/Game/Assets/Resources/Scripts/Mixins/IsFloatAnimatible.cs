using UnityEngine;
using System.Collections;
/// <summary>
/// Class used as component of objects that can be animated using float values
/// </summary>
public class IsFloatAnimatible : Mixin
{
   public bool isActive;                    // True, if this is active. False otherwise
   public FloatData fData;                  // Instance of float value
   private Animator _animator;              // Instance of animator

	// Use this for initialization
	void Start () {}
	
   public void OnEnable()
   {
      // obtain animator instance
      _animator = GetComponent<Animator>();
      isActive = false;
   }

   public void Animate()
   {      
      isActive = true;
   }

   public void NotAnimate()
   {
      isActive = false;
   }

	// Update is called once per frame
	void Update () 
   {
      // update animations
      animationUpdate();
	}
    /// <summary>
    /// Updates animation
    /// </summary>
   private void animationUpdate()
   {
      // check if there's an animator
      if (_animator && this.name != "")
      {
         // Check if it's active
         if (isActive == true && fData)
            // send float data
            _animator.SetFloat(this.name, fData.data);
         else
            // send ZERO
            _animator.SetFloat(this.name, 0.0f);
      }
   }
}
