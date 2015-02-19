using UnityEngine;
using System.Collections;

public class IsEquipmentSlot : Mixin {

	public IsEquipable obj;

	public bool IsEmpty()
	{
		bool rval = false;
		if (obj == null)
			rval = true;

		return rval;
	}

	public void Insert(IsEquipable equipObj)
	{
		if (obj == null)
		{
			obj = equipObj;
			obj.transform.parent = this.transform;
			obj.transform.localPosition = Vector3.zero; // dhdh - attach directly to TForm of slot
			obj.transform.localRotation = Quaternion.identity;
         // enable collider
         //obj.gameObject.collider.enabled = true;
			obj.gameObject.collider2D.enabled = true;
			//obj.rigidbody.useGravity = false;
			//obj.rigidbody.isKinematic = true;
         obj.rigidbody2D.isKinematic = true;

			// turn on renderers
			if (obj.gameObject.renderer)
				obj.gameObject.renderer.enabled = true;
			// get all child renderer components and disable them
			Renderer[] renderers = GetComponentsInChildren<Renderer>() as Renderer[];
			foreach (Renderer r in renderers)
				r.enabled = true;
		}
	}

	public void Remove()
	{
		// turn off renderers
		if (obj.gameObject.renderer)
			obj.gameObject.renderer.enabled = false;
		// get all child renderer components and disable them
		Renderer[] renderers = GetComponentsInChildren<Renderer>() as Renderer[];
		foreach (Renderer r in renderers)
			r.enabled = false;

		obj.transform.parent = null;
		obj = null;
	}

	// Use this for initialization
	void Start () {
	
	}

	public void IsEquipmentSlotUpdate()
	{

	}
	
	// Update is called once per frame
	void Update () {
	
		IsEquipmentSlotUpdate();
	}
}
