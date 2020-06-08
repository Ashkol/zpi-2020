using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialBuilding : Building
{
    private int residentsNumber = 0;
	public int rasidentsMax = 5;
	protected float timeFromLastGain = 0f;
	public float timeToGain = 5f;
	public List<DistributionBuilding> prevInChain = new List<DistributionBuilding>();
	
	protected void gainResidents()
	{
		if(residentsNumber < rasidentsMax)
		{
			residentsNumber++;
			showFloatingPoint();
			timeFromLastGain = timeToGain;
		}
	}
	
	protected void loseResidents()
	{
		residentsNumber = 0;
		timeFromLastGain = 0;
	}
	
	public override bool CheckForNeighbouringBuildings()
    {
        
        prevInChain = GetNeighbouringBuildingsFurther<DistributionBuilding>();


        return prevInChain.Count > 0;
    }
	
	public List<T> GetNeighbouringBuildingsFurther<T>()
    {
        List<T> buildings = new List<T>();
        foreach (Tile tile1 in tile.neighbours)
        {
            if (tile1.Building != null)
            {
                if (tile1.Building.TryGetComponent(out T building))
                {
                    buildings.Add(building);
                }
            }
			
			foreach (Tile tile2 in tile1.neighbours)
			{
            if (tile2.Building != null)
            {
                if (tile2.Building.TryGetComponent(out T building))
                {
                    buildings.Add(building);
                }
            }
			}			
           
        }
        return buildings;
    }
	
	public int getResidents(){
	
		return residentsNumber;
	}
	
	public virtual bool updateConditionsMet()
	{
		return false;
	}
	
	public virtual void updateToBetterHouse()
	{
		
	}
	
	public new BuildingType getBuildingType(){
		return BuildingType.Residential;
	}
}
