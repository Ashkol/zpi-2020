using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harbour : Building
{
	private static List<Hut> hutList = new List<Hut>();
	private static List<House> houseList = new List<House>();
	private static List<RichHouse> richList = new List<RichHouse>();
	
	private int poorPopulation = 0;
	private int averagePopulation = 0;
	private int richPopulation = 0;
	
	public int poorPopulationRequired = 100;
	public int averagePopulationRequired = 100;
	public int richPopulationRequired = 100;
	
    void Update()
    {
        //countPeople();
    }
	
	public static void AddToPool(Hut toAdd)
	{
		hutList.Add(toAdd);
	}
	
	public static void AddToPool(House toAdd)
	{
		houseList.Add(toAdd);
	}
	
	public static void AddToPool(RichHouse toAdd)
	{
		richList.Add(toAdd);
	}
	
	private void countPeople()
	{
		poorPopulation = 0;
		averagePopulation = 0;
		richPopulation = 0;
	
		foreach(Hut h in hutList)
		{
			if(h != null) poorPopulation += h.getResidents();
		}
		
		foreach(House h in houseList)
		{
			if(h != null) averagePopulation += h.getResidents();
		}
		
		foreach(RichHouse h in richList)
		{
			if(h != null) richPopulation += h.getResidents();
		}
	}
	
	//enable or not "win the game" button
	public bool winConditionsMet()
	{
		countPeople();
		
		return poorPopulation >= poorPopulationRequired && 
			averagePopulation >=averagePopulationRequired && 
			richPopulation >= richPopulationRequired;
	}
	
	//attach to "win the game" button
	public void win()
	{
		//victorious things happen
	}
}
