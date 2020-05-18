using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialBuilding : Building
{
    private int residentsNumber = 0;
	public int rasidentsMax = 5;
	protected float timeFromLastGain = 0f;
	public float timeToGain = 5f;
	
	protected void gainResidents()
	{
		if(residentsNumber < rasidentsMax)
		{
			residentsNumber++;
			timeFromLastGain = timeToGain;
		}
	}
	
	protected void loseResidents()
	{
		residentsNumber = 0;
		timeFromLastGain = 0;
	}
}
