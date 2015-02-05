using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour 
{
   public Transform target;                  // Target of camera
   public Transform currentScreen;           // Current Screen in game
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
      // Obtain the view position 
      Vector3 viewPos = camera.WorldToViewportPoint(target.position);
      //Debug.Log(viewPos.y);
      //------------
      // RIGHT
      //------------
      // Check if there's a right screen and target's x pos is > 0.95
      if (currentScreen.GetComponent<ScreenScript>().rightScreen && viewPos.x > 1.0F)
      {
         //Debug.Log("target is on the right side!");
         // assign current screen to right Screen
         currentScreen = currentScreen.GetComponent<ScreenScript>().rightScreen;
         // translate camera
         this.camera.transform.position = new Vector3(currentScreen.position.x, currentScreen.position.y, -10);
      }
      //------------
      // LEFT
      //------------
      // Check if there's a left screen and target's x pos is > 0.015
      else if(currentScreen.GetComponent<ScreenScript>().leftScreen && viewPos.x < 0.0F)
      {
         //Debug.Log("target is on the left side!");
         // assign current screen to left Screen
         currentScreen = currentScreen.GetComponent<ScreenScript>().leftScreen;
         // translate camera
         this.camera.transform.position = new Vector3(currentScreen.position.x, currentScreen.position.y, -10);
      }
      //------------
      // TOP
      //------------
      // Check if there's a top screen and target's y pos is > 0.95
      else if(currentScreen.GetComponent<ScreenScript>().topScreen && viewPos.y > 1.0F)
      {
         // assign current screen to top Screen
         currentScreen = currentScreen.GetComponent<ScreenScript>().topScreen;
         // translate camera
         this.camera.transform.position = new Vector3(currentScreen.position.x, currentScreen.position.y, -10);
      }
      //------------
      // BOTTOM
      //------------
      // Check if there's a bottom screen and target's y pos is < 0.015
      else if (currentScreen.GetComponent<ScreenScript>().bottomScreen && viewPos.y < 0.0F)
      {
         // assign current screen to bottom Screen
         currentScreen = currentScreen.GetComponent<ScreenScript>().bottomScreen;
         // translate camera
         this.camera.transform.position = new Vector3(currentScreen.position.x, currentScreen.position.y, -10);
      }
	}
}
