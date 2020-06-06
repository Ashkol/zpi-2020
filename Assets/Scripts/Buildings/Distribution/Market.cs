using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : DistributionBuilding
{	

	void Start()
    {
        resourcesOnMarket = (Resources)ScriptableObject.CreateInstance(typeof(Resources));
		lastResources = (Resources)ScriptableObject.CreateInstance(typeof(Resources));
    }
	
	void Update()
   {
		if(timeFromLastCheck < 0f) 
		{
			if(lastResources.fish >= resourcesOnMarket.fish)
			{
				resourcesOnMarket.fish = 0;
			}
			if(lastResources.bread >= resourcesOnMarket.bread)
			{
				resourcesOnMarket.bread = 0;
			}
			if(lastResources.wieners >= resourcesOnMarket.wieners)
			{
				resourcesOnMarket.wieners = 0;
			}
			if(lastResources.clothes >= resourcesOnMarket.clothes)
			{
				resourcesOnMarket.clothes = 0;
			}
			if(lastResources.pottery >= resourcesOnMarket.pottery)
			{
				resourcesOnMarket.pottery = 0;
			}
			
			lastResources = resourcesOnMarket;
			timeFromLastCheck = timeToReset;
		}
		else
		{
			timeFromLastCheck -= Time.deltaTime;
		}
   }	
}
