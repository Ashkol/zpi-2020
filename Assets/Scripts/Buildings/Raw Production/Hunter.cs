﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : RawProductionBuilding
{
   [Header("Chain links")]
    public Butcher nextInChain;
	
	void Update()
    {
        if (timeSinceLastProduction == 0f && nextInChain)
            StartCoroutine(Produce());
        if (currentResources.meat >= producedResources.meat && timeSinceLastPass == 0f && nextInChain)
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
        currentResources -= producedResources;
        while (timeSinceLastPass < passProductTime)
        {
            timeSinceLastPass += Time.deltaTime;
            passProgress = timeSinceLastPass / passProductTime;
            yield return null;
        }
        timeSinceLastPass = 0f;
        passProgress = timeSinceLastPass / passProductTime;
        nextInChain.currentResources += producedResources;
    }

    public override bool CheckForNeighbouringBuildings()
    {
        Debug.Log("Checks for Butcher");
        List<Butcher> chainBuildings = GetNeighbouringBuildings<Butcher>();
        if (nextInChain == null && chainBuildings.Count >= 1)
        {
            Debug.Log(">= 1");
            nextInChain = chainBuildings[0];
            return true;
        }

        return false;
    }
}
