using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : ResidentialBuilding
{
	void Start()
	{
		Harbour.AddToPool(this);
	}
	
   private bool conditionsMet()
   {
		bool aa = false, ab = false, ac = false;
		
		bool b = false; 
		bool c = false;
	   
		foreach(DistributionBuilding db in prevInChain)
		{
			if(db.getResources().fish > 0) aa = true;
			if(db.getResources().wieners > 0) ab = true;
			if(db.getResources().bread > 0) ac = true;
			if(db.getResources().clothes > 0 || db.getResources().pottery > 0) b = true;
			if(db.getResources().vodka > 0 || db.getResources().wine > 0) c = true;
		}
		
		return ((aa && ab) || (aa && ac) || (ab && ac)) && b && c;
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
}
