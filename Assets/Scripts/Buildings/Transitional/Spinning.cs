﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : TransitionalProductionBuilding
{
    [Header("Chain links")]
    public Market nextInChain;
    public List<CottonPlantation> prevInChain = new List<CottonPlantation>();

    void Update()
    {
        if (requiredResources <= currentResources && timeSinceLastProduction == 0f)
        {
            Debug.Log("Production of clothes starts");
            StartCoroutine(Produce());
        }
        if (currentResources.clothes >= producedResources.clothes && timeSinceLastPass == 0f && nextInChain != null)
        {
            StartCoroutine(PassResources());
        }
    }

    IEnumerator Produce()
    {
        currentResources -= requiredResources;
        while (timeSinceLastProduction < productionTime)
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
        Debug.Log("Passing resources spinning -> market");
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
        if (nextInChain == null)
        {
            List<Market> chainBuildings = GetNeighbouringBuildings<Market>();
            if (nextInChain == null && chainBuildings.Count >= 1)
            {
                nextInChain = chainBuildings[0];
                return true;
            }
        }
        prevInChain = GetNeighbouringBuildings<CottonPlantation>();

        foreach (CottonPlantation prev in prevInChain)
        {
            Debug.Log($"Checking for plantations {prevInChain.Count}");
            prev.CheckForNeighbouringBuildings();
        }

        return false;
    }
}
