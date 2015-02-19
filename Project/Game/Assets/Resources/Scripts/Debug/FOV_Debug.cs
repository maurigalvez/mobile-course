using UnityEngine;
using UnityEditor;
using System.Collections;

// Debug info for character's field of view
public class FOV_Debug : MonoBehaviour
{
   public bool mode3D = true;

   public enum direction2D
   {
      left,
      right,
      up,
      down
   }

   // current hero movement direction
   public direction2D curDir2D;

   // params for Sight area arc
   public float radius = 10.0f;
   public float angle = 45.0f;
}

[CustomEditor(typeof(FOV_Debug))]
public class DrawSolidDisc : Editor
{
   void OnSceneGUI()
   {
      FOV_Debug myTarget = (FOV_Debug)target;

      if (myTarget.mode3D)
      {
         // character's range
         Handles.color = new Color(1, 0, 0, 0.2f);
         Handles.DrawSolidDisc(myTarget.transform.position, Vector3.up, myTarget.radius);

         // direction of sight
         Handles.color = new Color(0, 1, 0, 0.3f);
         // right
         Handles.DrawSolidArc(
            myTarget.transform.position,
            myTarget.transform.up,
            myTarget.transform.forward,
            myTarget.angle / 2,
            myTarget.radius);
         // left
         Handles.DrawSolidArc(
            myTarget.transform.position,
            myTarget.transform.up,
            myTarget.transform.forward,
            -myTarget.angle / 2,
            myTarget.radius);

         // character's forward
         Handles.color = new Color(0, 1, 1, 1f);
         myTarget.radius = Handles.ScaleValueHandle(myTarget.radius,
             myTarget.transform.position + myTarget.transform.forward * myTarget.radius,
             myTarget.transform.rotation,
             8f,
             Handles.ConeCap,
             1f);
      }
      else
      {
         Vector3 spritePos = new Vector3(myTarget.transform.position.x, myTarget.transform.position.y, 0);
         // character's range
         Handles.color = new Color(1, 0, 0, 0.2f);
         Handles.DrawSolidDisc(spritePos, Vector3.forward, myTarget.radius);

         switch (myTarget.curDir2D)
         {
            case FOV_Debug.direction2D.up:
               // direction of sight
               Handles.color = new Color(0, 1, 0, 0.3f);
               // right
               Handles.DrawSolidArc(
                  spritePos,
                  myTarget.transform.forward,
                  myTarget.transform.up,
                  -myTarget.angle / 2f,
                  myTarget.radius);
               // left
               Handles.DrawSolidArc(
                  spritePos,
                  myTarget.transform.forward,
                  myTarget.transform.up,
                  myTarget.angle / 2f,
                  myTarget.radius);
               break;

            case FOV_Debug.direction2D.down:
               // direction of sight
               Handles.color = new Color(0, 1, 0, 0.3f);
               // right
               Handles.DrawSolidArc(
                  spritePos,
                  myTarget.transform.forward,
                  new Vector3(myTarget.transform.right.x, -40f, 0f),
                  myTarget.angle / 2f,
                  myTarget.radius);
               Handles.DrawSolidArc(
                  spritePos,
                  myTarget.transform.forward,
                  new Vector3(myTarget.transform.right.x, -40f, 0f),
                  -myTarget.angle / 2f,
                  myTarget.radius);
               break;

            case FOV_Debug.direction2D.left:
               // direction of sight
               Handles.color = new Color(0, 1, 0, 0.3f);
               // right
               Handles.DrawSolidArc(
                  spritePos,
                  myTarget.transform.forward,
                  new Vector3(myTarget.transform.up.x - 50f, 0f, 0f),
                  myTarget.angle / 2f,
                  myTarget.radius);
               Handles.DrawSolidArc(
                  spritePos,
                  myTarget.transform.forward,
                  new Vector3(myTarget.transform.up.x - 50f, 0f, 0f),
                  -myTarget.angle / 2f,
                  myTarget.radius);
               break;

            case FOV_Debug.direction2D.right:
               // direction of sight
               Handles.color = new Color(0, 1, 0, 0.3f);
               // right
               Handles.DrawSolidArc(
                  spritePos,
                  myTarget.transform.forward,
                  new Vector3(myTarget.transform.up.x + 50f, 0f, 0f),
                  myTarget.angle / 2f,
                  myTarget.radius);
               Handles.DrawSolidArc(
                  spritePos,
                  myTarget.transform.forward,
                  new Vector3(myTarget.transform.up.x + 50f, 0f, 0f),
                  -myTarget.angle / 2f,
                  myTarget.radius);
               break;
         }
      }
   }
}
