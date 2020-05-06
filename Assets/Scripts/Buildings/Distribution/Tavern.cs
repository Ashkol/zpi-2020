using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavern : DistributionBuilding
{
    public void AddResourcess(Resources newResources)
    {
        BuildManager.instance.playerResources += newResources;
    }
}
