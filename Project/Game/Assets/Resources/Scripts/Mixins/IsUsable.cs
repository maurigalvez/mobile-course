using UnityEngine;
using System.Collections;

public class IsUsable : Mixin 
{
	public bool Use;
	public string OnUseCB;
   public ItemUsageCondition useCondition;

	void Start ()
   {
	}

	public void IsUsableUpdate()
	{
		if (Use == true)
		{
         if (OnUseCB != "")
         {
            if (useCondition is PotionCondition)
            {
               PotionCondition potionCond = useCondition as PotionCondition;
               if (potionCond.CheckUsage())
               {
                  SendMessage(OnUseCB);
                  Use = false;

                  // correct player's HP if needed
                  potionCond.CheckHP();
               }
            }
            else
            {
               SendMessage(OnUseCB);
               Use = false;
            }
            
         }
		}
	}

	void Update () {
	
		IsUsableUpdate ();
	}
}
