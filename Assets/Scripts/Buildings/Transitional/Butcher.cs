using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butcher : TransitionalProductionBuilding
{
    [Header("Chain links")]
    public Market nextInChain;
    public List<Hunter> prevInChain = new List<Hunter>();
    
	void Update()
    {
        if (requiredResources <= currentResources && timeSinceLastProduction == 0f)
        {
            Debug.Log("Production of wieners starts");
            StartCoroutine(Produce());
        }
        if (currentResources.wieners >= producedResources.wieners && timeSinceLastPass == 0f && nextInChain != null)
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
        Debug.Log("Passing resources butcher -> market");
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
        prevInChain = GetNeighbouringBuildings<Hunter>();

        foreach (Hunter prev in prevInChain)
        {
            Debug.Log($"Checking for hunters {prevInChain.Count}");
            prev.CheckForNeighbouringBuildings();
        }

        return false;
    }
}
