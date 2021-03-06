﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mill : TransitionalProductionBuilding
{
    [Header("Chain links")]
    public Baker nextInChain;
    public List<Field> prevInChain = new List<Field>();

    protected override void Start()
    {
        base.Start();
        AssignCarrierDestination();
    }

    void Update()
    {
        if (requiredResources <= currentResources && timeSinceLastProduction == 0f)
        {
            Debug.Log("Production of bricks starts");
            StartCoroutine(Produce());
        }
        if (currentResources.flour >= producedResources.flour && timeSinceLastPass == 0f && nextInChain != null)
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
        carrier.MoveToDestination(passProductTime);
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
        if (nextInChain == null)
        {
            List<Baker> chainBuildings = GetNeighbouringBuildings<Baker>();
            if (nextInChain == null && chainBuildings.Count >= 1)
            {
                nextInChain = chainBuildings[0];
                AssignCarrierDestination();
                return true;
            }
        }
        prevInChain = GetNeighbouringBuildings<Field>();

        foreach (Field prev in prevInChain)
        {
            Debug.Log($"Checking for fields {prevInChain.Count}");
            prev.CheckForNeighbouringBuildings();
        }

        return false;
    }

    private void AssignCarrierDestination()
    {
        if (carrier.destinationBuilding == null)
        {
            carrier.destinationBuilding = nextInChain;
        }
    }
}
