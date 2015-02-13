using UnityEngine;
using System.Collections;

public class IsHero : MonoBehaviour 
{
   private Animator _animator;             // animator instance
   public float maxSpeed;                  // speed of character movement
   public float moveForce = 365.0f;
   public float direction;
   private Vector3 moveDirection;

	// Use this for initialization
	void Start () 
   {
      _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
   {
      //UpdateMovement();
      if(moveDirection != Vector3.zero)
         this.transform.Translate(moveDirection * Time.deltaTime);
	}
  
   public void MoveLeft()
   {
      direction = 1f;
      _animator.SetFloat("direction", direction);
      // Assign moveDirection
      moveDirection = -Vector3.right * maxSpeed;     
   }

   public void MoveRight()
   {
      direction = 0.33f;
      _animator.SetFloat("direction", direction);
      // Assign moveDirection
      moveDirection = Vector3.right * maxSpeed;      
   }
   public void MoveUp()
   {
      direction = 0.667f;
      _animator.SetFloat("direction", direction);
      // Assign moveDirection
      moveDirection = Vector3.up * maxSpeed;     
   }

   public void MoveDown()
   {
      direction = 0f; 
      _animator.SetFloat("direction", direction);
      // Assign moveDirection
      moveDirection = -Vector3.up * maxSpeed;   
   }

   public void StopMoving()
   {
      moveDirection = Vector3.zero;   
   }

   
}
