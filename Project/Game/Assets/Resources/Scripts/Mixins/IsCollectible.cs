using UnityEngine;
using System.Collections;

public class IsCollectible : Mixin
{
   public string collectionName;         // name of collection
   public UniqueData collection;         // collection item
   public int value;
   public void Add()
   {
      if(recipient)
      {
         bool exists = false;
         // obtain component
         UniqueData[] cdata = recipient.GetComponents<UniqueData>();
         foreach (UniqueData coldat in cdata)
         {
            // find the collection we should insert into, by name
            if (coldat.name == collectionName)
            {
               exists = true;
               collection = coldat;
               collection.amount += value;
               this.gameObject.SetActive(false);
               break;
            }
         }
         // check if it doesn't exist
         if(!exists)
         {
            // add the collection
            UniqueData col = recipient.AddComponent<UniqueData>();      
            col.name = collectionName;
            collection = col;
            collection.amount = value;
            this.gameObject.SetActive(false);
         }
      }
   }
   // Use this for initialization
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }	
}
