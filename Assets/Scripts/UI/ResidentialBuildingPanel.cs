using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
	public Image fill;
	public Color color;
	
	void Update()
	{
		bodyCount.text = "Residents number: " + building.getResidents();
		if(building.updateConditionsMet() && !updateButton.activeSelf) updateButton.SetActive(true);
		else if(!building.updateConditionsMet() && updateButton.activeSelf) updateButton.SetActive(false);
		
		getCurrentFill();
	}
	
	public void upgrade(){
	
		building.updateToBetterHouse();
	}
	
	void getCurrentFill(){
	
		float fillAmount = (float) building.getResidents() / (float) building.rasidentsMax;
		
		RectTransform rt = fill.GetComponent<RectTransform>();
		rt.localScale = new Vector3(fillAmount, 1, 1);
		
		fill.color = color;
	}
}
