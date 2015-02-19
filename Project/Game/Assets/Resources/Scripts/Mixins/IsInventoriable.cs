using UnityEngine;
using System.Collections;

public class IsInventoriable : Mixin {
	
	public string collectionName;
	public CollectionData collection;

	public void Hide()
	{
		// bad, need a way to diable rendering and interaction but still
		// keep update
		gameObject.collider2D.enabled = false;

		if (gameObject.renderer != null)
			gameObject.renderer.enabled = false;
		else
		{
			// get all child renderer components and disable them
			Renderer[] renderers = GetComponentsInChildren<Renderer>() as Renderer[];
			foreach (Renderer r in renderers)
				r.enabled = false;
		}
		//transform.Translate (0.0f, -1000.0f, 0.0f);
	}

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

					// really, only activate passive aspects if we 
					// successfully inserted into inventory
					IsPassive pas = GetComponent<IsPassive>();
					if (pas)
					{
						pas.Activate ();
						pas.SetRecipient(this.GetRecipient());
					}

					Hide ();

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
