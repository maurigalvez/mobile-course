using UnityEngine;
using System.Collections;

public class IsHero : MonoBehaviour 
{
   private Animator _animator;  // animator instance
   public float maxSpeed = 100.0f;      // speed of character movement
   public float moveForce = 365.0f;
   public float direction;
	// Use this for initialization
	void Start () 
   {
      _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
   {
      UpdateMovement();
	}
   // Takes input and updates character movement
   private void UpdateMovement()
   {
      float h = Input.GetAxis("Horizontal");
      float v = Input.GetAxis("Vertical");

      if(_animator)
      {
         bool fwd = (v < 0);
         bool back = (v > 0);
         bool right = (h > 0);
         bool left = (h < 0);
         //-------------------
         // SET DIRECTION
         //--------------------
         if (fwd)
            direction = 0.0f;
         if (right)
            direction = 0.33f;
         if (back)
            direction = 0.667f;         
         if (left)
            direction = 1f;
         _animator.SetFloat("direction", direction);
         //-------------------
         // MOVEMENT
         //-------------------
         if(h != 0 || v != 0)
            _animator.SetBool("Move", true);
         else
            _animator.SetBool("Move", false);
    
        
      }
      if (h != 0)
         transform.Translate(Vector3.right * h * Time.deltaTime * maxSpeed);
      if (v != 0)
         transform.Translate(Vector3.up * v * Time.deltaTime * maxSpeed);
   }

   
}
