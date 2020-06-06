using UnityEngine;

[CreateAssetMenu(fileName = "Building description", menuName = "ScriptableObjects/Building description", order = 1)]
public class BuildingDescription : ScriptableObject
{
    public new string name;
    [TextArea]
    public string description;
}
