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
    public BuildingDescPanel buildingDescPanelPrefab;
    BuildingDescPanel activeBuildingDescPanel;


    void Start()
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
        buildPanel.ShowBuildingInfo(building, GetComponent<RectTransform>().position);
        BuildManager.instance.SetBuildingToBuild(building);
        BuildManager.instance.BuildModeOn = true;

    }

    public void ShowBuildingInfo()
    {
        activeBuildingDescPanel = Instantiate(buildingDescPanelPrefab, transform);
        //activeBuildingDescPanel.GetComponent<RectTransform>().localPosition = transform.position + Vector3.left * 1000f;
        activeBuildingDescPanel.BuildingDesc = building.description;
        //LeanTween.moveLocalY(activeBuildingDescPanel.gameObject, 100, 0.3f);
    }

    public void HideBuildingInfo()
    {
        if (activeBuildingDescPanel != null)
            Destroy(activeBuildingDescPanel.gameObject);
    }
}
