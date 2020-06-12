using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vineyard : RawProductionBuilding
{
    [Header("Chain links")]
    //public Storehouse nextInChain;
    public Tavern nextInChain;
	
	void Update()
    {
        if (timeSinceLastProduction == 0f && nextInChain)
            StartCoroutine(Produce());
        if (currentResources.wine >= producedResources.wine && timeSinceLastPass == 0f && nextInChain)
            StartCoroutine(PassResources());
    }
	
	    IEnumerator Produce()
    {
        while(timeSinceLastProduction < productionTime)
        {
            timeSinceLastProduction += Time.deltaTime;
            productionProgress = timeSinceLastProduction / productionTime;
            yield return null;
        }
        timeSinceLastProduction = 0f;
        productionProgress = timeSinceLastProduction / productionTime;
        currentResources += producedResources;
		showFloatingPoint();
    }

    IEnumerator PassResources()
    {
        Debug.Log("Passing resources vineyard -> storehouse");
        currentResources -= producedResources;
        while (timeSinceLastPass < passProductTime)
        {
            timeSinceLastPass += Time.deltaTime;
            passProgress = timeSinceLastPass / passProductTime;
            yield return null;
        }
        timeSinceLastPass = 0f;
        passProgress = timeSinceLastPass / passProductTime;
        nextInChain.AddResourcess(producedResources);
    }

    public override bool CheckForNeighbouringBuildings()
    {
        Debug.Log("Checks for Storehouse");
        //List<Storehouse> chainBuildings = GetNeighbouringBuildings<Storehouse>();
        List<Tavern> chainBuildings = GetNeighbouringBuildings<Tavern>();
        if (nextInChain == null && chainBuildings.Count >= 1)
        {
            Debug.Log(">= 1");
            nextInChain = chainBuildings[0];
            return true;
        }

        return false;
    }
}
