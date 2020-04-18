using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildIcon : MonoBehaviour
{
    Image icon;
    Toggle toggle;
    public Building building;
    BuildPanel buildPanel;


    void Awake()
    {
        toggle = GetComponent<Toggle>();
        icon = GetComponent<Image>();
        if (building.icon != null)
            icon.sprite = building.icon;
    }

    public void Refresh()
    {
        if (!(BuildManager.instance.tileToBuildOn.tileType == building.tileType))
        {
            toggle.interactable = false;
        }
        else
        {
            toggle.interactable = true;
        }
    }

    public void OnSelect()
    {
        Debug.Log(building.name);
        buildPanel = GetComponentInParent<BuildPanel>();
        buildPanel.ShowBuildingInfo(building);
        BuildManager.instance.SetBuildingToBuild(building);

    }
}
