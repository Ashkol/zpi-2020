using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : DistributionBuilding
{
	private Resources tempResources;
	
	public void AddResourcess(Resources newResources)
	{
		BuildManager.instance.playerResources += newResources;
	}
}
