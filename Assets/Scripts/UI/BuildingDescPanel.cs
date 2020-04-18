using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuildingDescPanel : MonoBehaviour
{
    BuildingDescription _buildingDesc;
    public BuildingDescription BuildingDesc
    {
        get
        {
            return _buildingDesc;
        }
        set 
        {
            _buildingDesc = value;
            header.text = BuildingDesc.name;
            description.text = BuildingDesc.description;
        }
    }
    public TextMeshProUGUI header;
    public TextMeshProUGUI description;

    void Start()
    {
        header.text = BuildingDesc.name;
        description.text = BuildingDesc.description;
    }

}
