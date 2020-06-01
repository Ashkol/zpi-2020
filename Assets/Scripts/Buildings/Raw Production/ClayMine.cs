using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayMine : RawProductionBuilding
{
    [Header("Chain links")]
    public Brickyard nextInChain;
	public Potter alternativeChain;
    [SerializeField] private Carrier carrierAlt;

    protected override void Start()
    {
        base.Start();
        AssignCarrierDestination();
    }

    void Update()
    {
        if (timeSinceLastProduction == 0f && (nextInChain || alternativeChain))
            StartCoroutine(base.Produce());
        if (currentResources.clay >= producedResources.clay && timeSinceLastPass == 0f && (nextInChain || alternativeChain))
            StartCoroutine(PassResources());
    }
	
	//IEnumerator Produce()
 //   {
 //       while(timeSinceLastProduction < productionTime)
 //       {
 //           timeSinceLastProduction += Time.deltaTime;
 //           productionProgress = timeSinceLastProduction / productionTime;
 //           yield return null;
 //       }
 //       timeSinceLastProduction = 0f;
 //       productionProgress = timeSinceLastProduction / productionTime;
 //       currentResources += producedResources;
 //   }

    IEnumerator PassResources()
    {
        carrier.MoveToDestination(passProductTime);
        carrierAlt.MoveToDestination(passProductTime);
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
        Debug.Log("Checks for Brickyard");
        List<Brickyard> chainBuildings = GetNeighbouringBuildings<Brickyard>();
        if (nextInChain == null && chainBuildings.Count >= 1)
        {
            Debug.Log(">= 1");
            nextInChain = chainBuildings[0];
            AssignCarrierDestination();
        }

		Debug.Log("Checks for Potter");
        List<Potter> chainBuildings2 = GetNeighbouringBuildings<Potter>();
        if (alternativeChain == null && chainBuildings2.Count >= 1)
        {
            Debug.Log(">= 1");
            alternativeChain = chainBuildings2[0];
            AssignCarrierAlternativeDestination();

        }
		
        return (nextInChain == null && chainBuildings.Count >= 1) || (alternativeChain == null && chainBuildings2.Count >= 1); 
    }

    private void AssignCarrierDestination()
    {
        if (carrier.destinationBuilding == null)
        {
            carrier.destinationBuilding = nextInChain;
        }
    }

    private void AssignCarrierAlternativeDestination()
    {
        if (carrierAlt.destinationBuilding == null)
        {
            carrierAlt.destinationBuilding = alternativeChain;
        }
    }
}
