using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawmill : TransitionalProductionBuilding
{
    [Header("Chain links")]
    public Storehouse nextInChain;
    public List<WooodcutterHut> prevInChain = new List<WooodcutterHut>();

    void Update()
    {
        if (requiredResources <= currentResources && timeSinceLastProduction == 0f)
        {
            Debug.Log("Production of boards starts");
            StartCoroutine(Produce());
        }
        if (currentResources.boards >= producedResources.boards && timeSinceLastPass == 0f && nextInChain != null)
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
        Debug.Log("Passing resources sawmill -> storehouse");
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
        prevInChain = GetNeighbouringBuildings<WooodcutterHut>();

        foreach (WooodcutterHut prev in prevInChain)
        {
            Debug.Log($"Checking for sawmills {prevInChain.Count}");
            prev.CheckForNeighbouringBuildings();
        }

        return false;
    }
}
