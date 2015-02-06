using UnityEngine;
using System.Collections;
/// <summary>
/// Changes position of given object to a random position with respect to the camera. X and Z values depend on given min and max values.
/// </summary>
public class RandomPositionResponse : Response
{
    public Transform obj;          // Object to translate
    public float min;               // min value of range
    public float max;               // max value of range
    public float cameraRange;
    public override void dispatch()
    {
        // check if there's an object
        if(obj)
        {
            // obtain a random value for X from 50 to screen width-50
            float x = Random.Range(min, max);
            // obtain a random value for Y from 50 to screen height-50
            float z = Random.Range(min, max);
            // Obtain Ray
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, 0, z));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 300f))
            {
                //Debug.Log("Hit  x: " + hit.point.x + " z: " + hit.point.z);
                obj.position = new Vector3(hit.point.x, obj.position.y, hit.point.z);
            }
        }
    }
	
}
