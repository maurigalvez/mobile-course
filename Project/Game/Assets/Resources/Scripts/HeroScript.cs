using UnityEngine;
using System.Collections;

public class HeroScript : MonoBehaviour 
{
   private Animator _animator;  // animator instance
   public float maxSpeed = 100.0f;      // speed of character movement
   public float moveForce = 365.0f;

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
         _animator.SetBool("MoveFwd", (v < 0));
         _animator.SetBool("MoveBack", (v > 0));
         _animator.SetBool("MoveRight", (h > 0));
         _animator.SetBool("MoveLeft", (h < 0));
      }
      if (h != 0)
         transform.Translate(Vector3.right * h * Time.deltaTime);
      if (v != 0)
         transform.Translate(Vector3.up * v * Time.deltaTime);
   }
}
