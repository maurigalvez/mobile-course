using UnityEngine;
using System.Collections;

public class cameraScript3D : MonoBehaviour 
{
   public Transform target;                  // Target of camera
   public Transform currentScreen;           // Current Screen in game
   public float minDistance;                 // min distance between camera and destination
   private Vector3 destination;
   private bool translate = false;
   private Vector3 viewPos;
   void Start()
   {
      // Set target
      this.camera.transform.position = new Vector3(currentScreen.position.x, 10, currentScreen.position.z);
      // initialize viewpos
      viewPos = Vector3.zero;
   }

   // Update is called once per frame
   void Update()
   {
      // Obtain the view position 
      viewPos = camera.WorldToViewportPoint(target.position);
      
      if (translate == true)
      { 
           goToDestination();
      }
      else
         updateCamera();
   }

   private void updateCamera()
   {
    
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
         if (cam.rightScreen && translate != true && viewPos.x > 1.1F)
         {
            //Debug.Log("target is on the right side!");
            // assign current screen to right Screen
            currentScreen = cam.rightScreen;
            // translate camera
            destination = new Vector3(currentScreen.position.x, 10, currentScreen.position.z);
            translate = true;
         }
         //------------
         // LEFT
         //------------
         // Check if there's a left screen and target's x pos is > 0.015
         else if (cam.leftScreen && translate != true && viewPos.x < 0.0F)
         {
            //Debug.Log("target is on the left side!");
            // assign current screen to left Screen
            currentScreen = cam.leftScreen;
            // translate camera
            destination = new Vector3(currentScreen.position.x, 10, currentScreen.position.z);
            translate = true;   
         }
         //------------
         // TOP
         //------------
         // Check if there's a top screen and target's y pos is > 0.95
         else if (cam.topScreen && translate != true && viewPos.y > 1.05F)
         {
            // assign current screen to atop Screen
            currentScreen = cam.topScreen;
            // translate camera
            destination = new Vector3(currentScreen.position.x, 10, currentScreen.position.z);
            translate = true;   
         }
         //------------
         // BOTTOM
         //------------
         // Check if there's a bottom screen and target's y pos is < 0.015
         else if (cam.bottomScreen && translate != true && viewPos.y < 0.09F)
         {
            // assign current screen to bottom Screen
            currentScreen = cam.bottomScreen;
            // translate camera
            destination = new Vector3(currentScreen.position.x, 10, currentScreen.position.z);
            translate = true;   
         }
      }//check for camscript
   }
   //==================
   // GO TO DESTINATION
   //==================
   public void goToDestination()
   {
      Vector3 cPosition = transform.position;
      Vector3 moveDirection = (destination - cPosition).normalized;
      float distance = Vector3.Distance(camera.transform.position, destination);
      // check distance 
      while (distance > minDistance)
      {
         Vector3 pos = moveDirection * distance * Time.deltaTime * 0.05f;
         this.transform.position = new Vector3(this.transform.position.x + pos.x, this.transform.position.y, this.transform.position.z + pos.z);
         distance = Vector3.Distance(camera.transform.position, destination);
      }
      translate = false;
   }
   //===============
   // SET SCREEN
   //===============
   public void setScreen(Transform _t)
   {
      currentScreen = _t;
      // translate Camera
      this.camera.transform.position = currentScreen.position;
   }
}
