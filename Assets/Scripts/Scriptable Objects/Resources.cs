using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resources", menuName = "ScriptableObjects/Resources", order = 2)]
public class Resources : ScriptableObject
{
    [Header("Materials")]
    public int boards;
    public int wood;
    public int stone;
    public int clay;
    public int bricks;

    public static Resources operator +(Resources r1, Resources r2)
    {
        Resources summedResources = (Resources)ScriptableObject.CreateInstance(typeof(Resources));
        summedResources.boards = r1.boards + r2.boards;
        summedResources.wood = r1.wood + r2.wood;
        summedResources.stone = r1.stone + r2.stone;
        summedResources.clay = r1.clay + r2.clay;
        summedResources.bricks = r1.bricks + r2.bricks;
        return summedResources;
    }

    public static Resources operator -(Resources r1, Resources r2)
    {
        Resources summedResources = (Resources)ScriptableObject.CreateInstance(typeof(Resources));
        summedResources.boards = r1.boards - r2.boards;
        summedResources.wood = r1.wood - r2.wood;
        summedResources.stone = r1.stone - r2.stone;
        summedResources.clay = r1.clay - r2.clay;
        summedResources.bricks = r1.bricks - r2.bricks;
        return summedResources;
    }

    public static bool operator >=(Resources r1, Resources r2)
    {
        if (r1.boards < r2.boards)
            return false;
        if (r1.wood < r2.wood)
            return false;
        if (r1.stone < r2.stone)
            return false;
        if (r1.clay < r2.clay)
            return false;
        if (r1.bricks < r2.bricks)
            return false;
        return true;
    }

    public static bool operator <=(Resources r1, Resources r2)
    {
        if (r1.boards > r2.boards)
            return false;
        if (r1.wood > r2.wood)
            return false;
        if (r1.stone > r2.stone)
            return false;
        if (r1.clay > r2.clay)
            return false;
        if (r1.bricks > r2.bricks)
            return false;
        return true;
    }
}
