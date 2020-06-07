using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResidentialBuildingPanel : BuildingPanel
{
    private ResidentialBuilding building;

	public new ResidentialBuilding Building
    {
        get { return building; }
        set
        {
            building = value;
            header.text = building.description.name;
            description.text = building.description.description;
        }
    }
	
    protected override void Start()
    {
        base.Start();
    }

	public TextMeshProUGUI bodyCount;
	public GameObject updateButton;
	
	void Update()
	{
		bodyCount.text = "Residents number: " + building.getResidents();
		if(building.updateConditionsMet() && !updateButton.activeSelf) updateButton.SetActive(true);
		else if(!building.updateConditionsMet() && updateButton.activeSelf) updateButton.SetActive(false);
	}
	
	public void upgrade(){
	
		building.updateToBetterHouse();
	}
}
