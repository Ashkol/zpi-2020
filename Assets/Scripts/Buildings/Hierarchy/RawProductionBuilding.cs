using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawProductionBuilding : ProductionBuilding
{
    public Carrier carrier;

    protected IEnumerator Produce()
    {
        while (timeSinceLastProduction < productionTime)
        {
            timeSinceLastProduction += Time.deltaTime;
            productionProgress = timeSinceLastProduction / productionTime;
            OnProductionProgress.Invoke();
            yield return null;
        }
        timeSinceLastProduction = 0f;
        productionProgress = timeSinceLastProduction / productionTime;
        currentResources += producedResources;
        OnProductionProgress.Invoke();
    }
}
