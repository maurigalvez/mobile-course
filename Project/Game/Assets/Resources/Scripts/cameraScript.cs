using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour 
{
   public Transform target;                  // Target of camera
   public Transform currentScreen;           // Current Screen in game
   public float minDistance;                 // min distance between camera and destination
   private Vector2 destination;

	// Use this for initialization
	void Start () 
    {
	    // Set target
		 //this.camera.transform.LookAt(target.transform);
       this.camera.transform.position = new Vector3(currentScreen.position.x, currentScreen.position.y, -10);        
	}
	
	// Update is called once per frame
	void Update () 
	{
      updateCamera();
     // goToDestination();
	}

   private void updateCamera()
   {
      // Obtain the view position 
      Vector3 viewPos = camera.WorldToViewportPoint(target.position);
      // Obtain ScreenScript component
      ScreenScript cam = currentScreen.GetComponent<ScreenScript>();
      // check if there;s a screenscrpt
      if (cam)
      {
         //Debug.Log(viewPos.y);
         //------------
         // RIGHT
         //------------
         // Check if there's a right screen and target's x pos is > 0.95
         if (cam.rightScreen && viewPos.x > 1.0F)
         {
            //Debug.Log("target is on the right side!");
            // assign current screen to right Screen
            currentScreen = cam.rightScreen;
            // translate camera
            this.camera.transform.position = new Vector3(currentScreen.position.x, currentScreen.position.y,-10);
         }
         //------------
         // LEFT
         //------------
         // Check if there's a left screen and target's x pos is > 0.015
         else if (cam.leftScreen && viewPos.x < 0.0F)
         {
            //Debug.Log("target is on the left side!");
            // assign current screen to left Screen
            currentScreen = cam.leftScreen;
            // translate camera
            this.camera.transform.position = new Vector3(currentScreen.position.x, currentScreen.position.y,-10);
         }
         //------------
         // TOP
         //------------
         // Check if there's a top screen and target's y pos is > 0.95
         else if (cam.topScreen && viewPos.y > 1.0F)
         {
            // assign current screen to top Screen
            currentScreen = cam.topScreen;
            // translate camera
            this.camera.transform.position = new Vector3(currentScreen.position.x, currentScreen.position.y,-10);
         }
         //------------
         // BOTTOM
         //------------
         // Check if there's a bottom screen and target's y pos is < 0.015
         else if (cam.bottomScreen && viewPos.y < 0.0F)
         {
            // assign current screen to bottom Screen
            currentScreen = cam.bottomScreen;
            // translate camera
            this.camera.transform.position = new Vector3(currentScreen.position.x, currentScreen.position.y,-10);
         }
      }//check for camscript
   }
   //==================
   // GO TO DESTINATION
   //==================
   public void goToDestination()
   {
      /*Vector2 cPosition = new Vector2(transform.position.x, transform.position.y);
      Vector2 moveDirection = (destination - cPosition).normalized;
      float distance = Vector2.Distance(camera.transform.position, destination);
      // check distance 
      while(distance > minDistance)
      {
         Vector2 pos = moveDirection * distance * Time.deltaTime;
         this.transform.position += new Vector3(pos.x,pos.y,0);
      }*/
   }
   //===============
   // SET SCREEN
   //===============
   public void setScreen(Transform _t)
   {
      currentScreen = _t;
      // translate Camera
      this.camera.transform.position = new Vector3(currentScreen.position.x, currentScreen.position.y, -10);
   }
}
