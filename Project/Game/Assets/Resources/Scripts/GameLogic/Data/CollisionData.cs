using UnityEngine;
using System.Collections;

public class CollisionData : Data {

	public Collision data;
	public Collision Get()
	{
		return data;
	}
	
	public void Set(Collision d)
	{
		data = d;
	}
}
