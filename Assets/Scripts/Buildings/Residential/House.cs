using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : ResidentialBuilding
{
   private bool conditionsMet()
   {
		//2 types of food, 1 type of alcohol, 1 type of luxury good
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
