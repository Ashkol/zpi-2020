using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMine : RawProductionBuilding
{
    [Header("Chain links")]
    public Storehouse nextInChain;

    protected override void Start()
    {
        base.Start();
        AssignCarrierDestination();
    }
    void Update()
    {
        if (timeSinceLastProduction == 0f && nextInChain)
            StartCoroutine(Produce());
        if (currentResources.stone >= producedResources.stone && timeSinceLastPass == 0f && nextInChain)
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
        carrier.MoveToDestination(passProductTime);
        Debug.Log("Passing resources stone mine -> storehouse");
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
        List<Storehouse> chainBuildings = GetNeighbouringBuildings<Storehouse>();
        if (nextInChain == null && chainBuildings.Count >= 1)
        {
            Debug.Log(">= 1");
            nextInChain = chainBuildings[0];
            AssignCarrierDestination();
            return true;
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
