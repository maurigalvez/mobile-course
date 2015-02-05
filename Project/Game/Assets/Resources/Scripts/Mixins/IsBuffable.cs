using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IsBuffable : Mixin {

	public List<Data> buffs;
	public void Apply()
	{
		foreach (Data d in buffs)
		{
			//
			//	find variables that match (by name)
			//
			Data[] attributes = GetRecipient().GetComponents<Data>();
			foreach(Data attrib in attributes)
			{
				if (attrib.name == d.name)
				{
					IntData id = (attrib as IntData);
					if (id)
						(id as IntData).Add( (d as IntData).Get () );
					
					FloatData fd = (attrib as FloatData);
					if (fd)
						(fd as FloatData).Add ( (d as FloatData).Get () );
				}
			}
		}
	}

	public void Remove()
	{
		foreach (Data d in buffs)
		{
			//
			//	find variables that match (by name)
			//
			Data[] attributes = GetRecipient().GetComponents<Data>();
			foreach(Data attrib in attributes)
			{
				if (attrib.name == d.name)
				{
					IntData id = (attrib as IntData);
					if (id)
						(id as IntData).Add( -(d as IntData).Get () );
					
					FloatData fd = (attrib as FloatData);
					if (fd)
						(fd as FloatData).Add ( -(d as FloatData).Get () );
				}
			}
		}
	}
}
