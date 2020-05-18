using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichHouse : ResidentialBuilding
{
    private bool conditionsMet()
   {
	   //3 types of food, 2 types of alcohol, 2 types of luxury good
	   
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
