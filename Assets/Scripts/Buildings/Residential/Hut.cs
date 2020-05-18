using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hut : ResidentialBuilding
{
	private bool conditionsMet()
	{
		//1 type of food
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
}
