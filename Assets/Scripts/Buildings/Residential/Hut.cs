using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hut : ResidentialBuilding
{
	void Start()
	{
		Harbour.AddToPool(this);
	}
	
	private bool conditionsMet()
	{
		foreach(DistributionBuilding db in prevInChain)
		{
			if(db.getResources().fish > 0 || db.getResources().bread > 0 || db.getResources().wieners > 0) return true;
		}
		
		return false;
	}
	
	void Update()
   {
		if(conditionsMet() && timeFromLastGain < 0f) 
		{
			gainResidents();			
		}
		else if(!conditionsMet())
		{
			loseResidents();
		}
		else
		{
			timeFromLastGain -= Time.deltaTime;
		}
   }	
   
   //enable or not "update" button
   private bool updateConditionsMet()
   {
		foreach(DistributionBuilding db in prevInChain)
		{
			if(((db.getResources().fish > 0 && db.getResources().bread > 0) || 
					(db.getResources().fish > 0 && db.getResources().wieners > 0) || 
						(db.getResources().bread > 0 && db.getResources().wieners > 0)) && 
							(db.getResources().clothes > 0 || db.getResources().pottery > 0)) return true;
		}
		
		return false;
   }
}
