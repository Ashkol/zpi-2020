using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : RawProductionBuilding
{
    [Header("Chain links")]
    public Mill nextInChain;
	public Distillery alternativeChain;
	
	void Update()
    {
        if (timeSinceLastProduction == 0f && (nextInChain || alternativeChain))
            StartCoroutine(Produce());
        if (currentResources.grain >= producedResources.grain && timeSinceLastPass == 0f && (nextInChain || alternativeChain))
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
        if(nextInChain) nextInChain.currentResources += producedResources;
		if(alternativeChain) alternativeChain.currentResources += producedResources;
    }

    public override bool CheckForNeighbouringBuildings()
    {
        Debug.Log("Checks for mill");
        List<Mill> chainBuildings = GetNeighbouringBuildings<Mill>();
        if (nextInChain == null && chainBuildings.Count >= 1)
        {
            Debug.Log(">= 1");
            nextInChain = chainBuildings[0];
            
        }

		Debug.Log("Checks for distillery");
        List<Distillery> chainBuildings2 = GetNeighbouringBuildings<Distillery>();
        if (alternativeChain == null && chainBuildings2.Count >= 1)
        {
            Debug.Log(">= 1");
            alternativeChain = chainBuildings2[0];
            
        }
		
        return (nextInChain == null && chainBuildings.Count >= 1) || (alternativeChain == null && chainBuildings2.Count >= 1); 
    }
}
