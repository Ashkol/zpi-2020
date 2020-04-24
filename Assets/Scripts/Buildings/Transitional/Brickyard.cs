using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brickyard : TransitionalProductionBuilding
{
	[Header("Chain links")]
    public Storehouse nextInChain;
    public List<ClayMine> prevInChain = new List<ClayMine>();
    
	void Update()
    {
        if (requiredResources <= currentResources && timeSinceLastProduction == 0f)
        {
            Debug.Log("Production of bricks starts");
            StartCoroutine(Produce());
        }
        if (currentResources.bricks >= producedResources.bricks && timeSinceLastPass == 0f && nextInChain != null)
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
    }

    IEnumerator PassResources()
    {
        Debug.Log("Passing resources brickyard -> storehouse");
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
            List<Storehouse> chainBuildings = GetNeighbouringBuildings<Storehouse>();
            if (nextInChain == null && chainBuildings.Count >= 1)
            {
                nextInChain = chainBuildings[0];
                return true;
            }
        }
        prevInChain = GetNeighbouringBuildings<ClayMine>();

        foreach (ClayMine prev in prevInChain)
        {
            Debug.Log($"Checking for brickyards {prevInChain.Count}");
            prev.CheckForNeighbouringBuildings();
        }

        return false;
    }
	
}
