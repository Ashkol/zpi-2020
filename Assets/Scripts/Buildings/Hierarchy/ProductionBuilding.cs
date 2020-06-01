using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProductionBuilding : Building
{

    public Resources currentResources;
    [Header("Production")]
    public Resources producedResources;
    public float productionTime;
    protected float timeSinceLastProduction = 0;
    public float productionProgress = 0;
    [Header("Passing resources")]
    public float passProductTime;
    protected float timeSinceLastPass = 0;
    public float passProgress = 0;
    public UnityEvent OnFinishProduction;
    public UnityEvent OnProductionProgress;

    protected virtual void Start()
    {
        Debug.Log("Production Buildings");
        currentResources = (Resources)ScriptableObject.CreateInstance(typeof(Resources));
        CheckForNeighbouringBuildings();
    }

}
