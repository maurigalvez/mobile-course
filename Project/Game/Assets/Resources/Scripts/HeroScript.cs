using UnityEngine;
using System.Collections;

public class HeroScript : MonoBehaviour 
{
   private FOV_Debug fovDebug;
   private Animator _animator;  // animator instance
   public float maxSpeed = 100.0f;      // speed of character movement
   public float moveForce = 365.0f;

	// Use this for initialization
	void Start () 
   {
      _animator = GetComponent<Animator>();
      fovDebug = GetComponent<FOV_Debug>();
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
         if (v<0)
         {
            //Debug.Log("down");
            //fovDebug.curDir2D = FOV_Debug.direction2D.down;
         }
         _animator.SetBool("MoveBack", (v > 0));
         if (v > 0)
         {
            //Debug.Log("up");
            //fovDebug.curDir2D = FOV_Debug.direction2D.up;
         }
         _animator.SetBool("MoveRight", (h > 0));
         if (h > 0)
         {
            //Debug.Log("right");
            //fovDebug.curDir2D = FOV_Debug.direction2D.right;
         }
         _animator.SetBool("MoveLeft", (h < 0));
         if (h < 0)
         {
            //Debug.Log("left");
            //fovDebug.curDir2D = FOV_Debug.direction2D.left;
         }
      }
      if (h != 0)
         transform.Translate(Vector3.right * h * Time.deltaTime);
      if (v != 0)
         transform.Translate(Vector3.up * v * Time.deltaTime);
   }
}
