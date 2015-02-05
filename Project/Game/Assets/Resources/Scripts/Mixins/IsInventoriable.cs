using UnityEngine;
using System.Collections;

public class IsInventoriable : Mixin {
	
	public string collectionName;
	public CollectionData collection;

	public void Insert()
	{
		if (recipient)
		{
			CollectionData[] cdata = recipient.GetComponents<CollectionData>();
			for (int i = 0; i < cdata.Length; i++)
			{
				CollectionData coldat = cdata[i];

				// find the collection we should insert into, by name
				if (coldat.name == collectionName)
				{
					coldat.Insert(this);
					this.gameObject.SetActive(false);
					break;
				}
			}
		}

	}

	public void Remove()
	{
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
