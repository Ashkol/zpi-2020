using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributionBuilding : Building
{
	protected Resources resourcesOnMarket;
	protected Resources lastResources;
	
	public float timeToReset = 10f;
	protected float timeFromLastCheck = 0f;
	
	public void AddResourcess(Resources newResources)
	{
		resourcesOnMarket += newResources;
	}
	
	public Resources getResources()
	{		
		return resourcesOnMarket;
	}
}
