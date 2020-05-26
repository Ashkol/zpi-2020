using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavern : DistributionBuilding
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
			if(lastResources.wine >= resourcesOnMarket.wine)
			{
				resourcesOnMarket.wine = 0;
			}
			if(lastResources.vodka >= resourcesOnMarket.vodka)
			{
				resourcesOnMarket.vodka = 0;
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
