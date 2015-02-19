using UnityEngine;
using System.Collections;

public class ItemUsageCondition : MonoBehaviour 
{
   public virtual bool CheckUsage()
   {
      return false;
   }

	void Start () 
   {	
	}
	
	void Update () 
   {	
	}
}
