using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : ResidentialBuilding
{
	protected override void Start()
	{
		base.Start();
		Harbour.AddToPool(this);
	}

	private bool conditionsMet()
   {
		bool aa = false, ab = false, ac = false;
		
		bool b = false; 
		bool c = false;
	   
		foreach(DistributionBuilding db in prevInChain)
		{
			var resources = db.getResources();
			if (resources != null)
			{
				if (resources.fish > 0) aa = true;
				if (resources.wieners > 0) ab = true;
				if (resources.bread > 0) ac = true;
				if (resources.clothes > 0 || db.getResources().pottery > 0) b = true;
				if (resources.vodka > 0 || db.getResources().wine > 0) c = true;
			}
		}

		//return ((aa && ab) || (aa && ac) || (ab && ac)) && b && c;
		return (aa || ac) && c;
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
   public override bool updateConditionsMet()
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
   
	//attach to "update" button
	public override void updateToBetterHouse(){
	   
	   BuildManager.instance.updateToRichHouse(tile);
        
		Destroy(gameObject);
	}  
}
