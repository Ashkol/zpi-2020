using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resources", menuName = "ScriptableObjects/Resources", order = 2)]
public class Resources : ScriptableObject
{
    [Header("Materials")]
    public int wood;
    public int stone;
    public int clay;
	public int meat;
	public int grain;
	public int fish;
	public int cotton;
	
	public int boards;
	public int bricks;
	public int wieners;
	public int wine;
	public int bread;
	public int vodka;
	public int clothes;
	public int pottery;
	public int flour;

		public static Resources operator +(Resources r1, Resources r2)
	{
		Resources summedResources = (Resources)ScriptableObject.CreateInstance(typeof(Resources));
        
		summedResources.wood = r1.wood + r2.wood;
		summedResources.stone = r1.stone + r2.stone;
		summedResources.clay = r1.clay + r2.clay;
		summedResources.meat = r1.meat + r2.meat;
		summedResources.grain = r1.grain + r2.grain;
		summedResources.fish = r1.fish + r2.fish;
		summedResources.cotton = r1.cotton + r2.cotton;
		
		summedResources.boards = r1.boards + r2.boards;
        summedResources.bricks = r1.bricks + r2.bricks;
		summedResources.wieners = r1.wieners + r2.wieners;
		summedResources.wine = r1.wine + r2.wine;
		summedResources.bread = r1.bread + r2.bread;
		summedResources.vodka = r1.vodka + r2.vodka;
		summedResources.clothes = r1.clothes + r2.clothes;
		summedResources.pottery = r1.pottery + r2.pottery;
		summedResources.flour = r1.flour + r2.flour;
		return summedResources;
    }

    public static Resources operator -(Resources r1, Resources r2)
    {
		Resources summedResources = (Resources)ScriptableObject.CreateInstance(typeof(Resources));
        
		summedResources.wood = r1.wood - r2.wood;
		summedResources.stone = r1.stone - r2.stone;
		summedResources.clay = r1.clay - r2.clay;
		summedResources.meat = r1.meat + r2.meat;
		summedResources.grain = r1.grain + r2.grain;
		summedResources.fish = r1.fish + r2.fish;
		summedResources.cotton = r1.cotton + r2.cotton;
		
		summedResources.boards = r1.boards - r2.boards;
        summedResources.bricks = r1.bricks - r2.bricks;
		summedResources.wieners = r1.wieners - r2.wieners;
		summedResources.wine = r1.wine - r2.wine;
		summedResources.bread = r1.bread - r2.bread;
		summedResources.vodka = r1.vodka - r2.vodka;
		summedResources.clothes = r1.clothes - r2.clothes;
		summedResources.pottery = r1.pottery - r2.pottery;
		summedResources.flour = r1.flour - r2.flour;
        return summedResources;
    }

    public static bool operator >=(Resources r1, Resources r2)
    {        
        if (r1.wood < r2.wood)
            return false;
        if (r1.stone < r2.stone)
            return false;
        if (r1.clay < r2.clay)
            return false;
		if (r1.meat < r2.meat)
            return false;
        if (r1.grain < r2.grain)
            return false;
		if (r1.fish < r2.fish)
            return false;
        if (r1.cotton < r2.cotton)
            return false;
		
		if (r1.boards < r2.boards)
            return false;
        if (r1.bricks < r2.bricks)
            return false;
		if (r1.wieners < r2.wieners)
            return false;
        if (r1.wine < r2.wine)
            return false;
		if (r1.bread < r2.bread)
            return false;
        if (r1.vodka < r2.vodka)
            return false;
		if (r1.clothes < r2.clothes)
            return false;
        if (r1.pottery < r2.pottery)
            return false;
		if (r1.flour < r2.flour)
            return false;
        return true;
    }

    public static bool operator <=(Resources r1, Resources r2)
    {        
        if (r1.wood > r2.wood)
            return false;
        if (r1.stone > r2.stone)
            return false;
        if (r1.clay > r2.clay)
            return false;
		if (r1.meat > r2.meat)
            return false;
        if (r1.grain > r2.grain)
            return false;
		if (r1.fish > r2.fish)
            return false;
        if (r1.cotton > r2.cotton)
            return false;
		
		if (r1.boards > r2.boards)
            return false;
        if (r1.bricks > r2.bricks)
            return false;
		if (r1.wieners > r2.wieners)
            return false;
        if (r1.wine > r2.wine)
            return false;
		if (r1.bread > r2.bread)
            return false;
        if (r1.vodka > r2.vodka)
            return false;
		if (r1.clothes > r2.clothes)
            return false;
        if (r1.pottery > r2.pottery)
            return false;
		if (r1.flour > r2.flour)
            return false;
        return true;
    }
}
