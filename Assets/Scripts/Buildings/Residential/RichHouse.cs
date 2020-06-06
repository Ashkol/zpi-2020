using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichHouse : ResidentialBuilding
{
	void Start()
	{
		Harbour.AddToPool(this);
	}
	
    private bool conditionsMet()
   {
	   bool aa = false, ab = false, ac = false;
		
		bool ba = false, bb = false; 
		bool ca = false, cb = false;
		
	   foreach(DistributionBuilding db in prevInChain)
		{
			if(db.getResources().fish > 0) aa = true;
			if(db.getResources().wieners > 0) ab = true;
			if(db.getResources().bread > 0) ac = true;
			if(db.getResources().clothes > 0) ba = true;
			if(db.getResources().vodka > 0) bb = true;
			if(db.getResources().pottery > 0) ca = true;
			if(db.getResources().wine > 0) cb = true;
		}
		
		return aa && ab && ac && ba && bb && ca && cb;
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
