using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributionBuilding : Building
{
	protected Resources resourcesOnMarket;
	protected Resources lastResources;
	
	public float timeToReset = 10f;
	protected float timeFromLastCheck = 0f;

	protected new virtual void Start()
	{
		buildingType = BuildingType.Normal;
		var bb = GetNeighbouringBuildings<Building>();
		foreach (Building neighbour in bb)
		{
			neighbour.CheckForNeighbouringBuildings();
		}
		// It is also created in children, but then it throws null in game - not sure why 
		// TO DO check why
		resourcesOnMarket = (Resources)ScriptableObject.CreateInstance(typeof(Resources));
	}

	public void AddResourcess(Resources newResources)
	{
		resourcesOnMarket += newResources;
	}
	
	public Resources getResources()
	{		
		return resourcesOnMarket;
	}
}
