using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baker : TransitionalProductionBuilding
{
    [Header("Chain links")]
    public Market nextInChain;
    public List<Mill> prevInChain = new List<Mill>();

    protected override void Start()
    {
        base.Start();
        AssignCarrierDestination();
    }
    void Update()
    {
        if (requiredResources <= currentResources && timeSinceLastProduction == 0f)
        {
            Debug.Log("Production of bread starts");
            StartCoroutine(Produce());
        }
        if (currentResources.bread >= producedResources.bread && timeSinceLastPass == 0f && nextInChain != null)
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
        Debug.Log("Passing resources baker -> market");
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
                AssignCarrierDestination();
                return true;
            }
        }
        prevInChain = GetNeighbouringBuildings<Mill>();

        foreach (Mill prev in prevInChain)
        {
            Debug.Log($"Checking for mills {prevInChain.Count}");
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
