using UnityEngine;
using System.Collections;

public class DirectionData : Data
{
   public enum eDirection
   {
      NORTH,
      SOUTH,
      WEST,
      EAST
   }

   public eDirection data;

   //--------------
   // GO NORTH
   //--------------
   /// <summary>
   /// Changes the the direction to North
   /// </summary>
   public void goNorth()
   {
      data = eDirection.NORTH;
   }

   //--------------
   // GO SOUTH
   //--------------
   /// <summary>
   /// Changes the the direction to South
   /// </summary>
   public void goSouth()
   {
      data = eDirection.SOUTH;
   }

   //--------------
   // GO EAST
   //--------------
   /// <summary>
   /// Changes the the direction to East
   /// </summary>
   public void goEast()
   {
      data = eDirection.EAST;
   }

   //--------------
   // GO WEST
   //--------------
   /// <summary>
   /// Changes the the direction to WEst
   /// </summary>
   public void goWest()
   {
      data = eDirection.WEST;
   }

}
