using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuildingPanel : MonoBehaviour
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
        transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, Vector3.one, 0.3f);
    }

    public void Close()
    {
        LeanTween.scale(gameObject, Vector3.zero, 0.3f).setDestroyOnComplete(true);
    }

}
