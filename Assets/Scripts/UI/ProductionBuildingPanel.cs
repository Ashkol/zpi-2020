using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProductionBuildingPanel : BuildingPanel
{
    private ProductionBuilding building;

	public new ProductionBuilding Building
    {
        get { return building; }
        set
        {
            building = value;
            header.text = building.description.name;
            description.text = building.description.description;
        }
    }

	public Image fill;
	public Color color;
	
    protected override void Start()
    {
        base.Start();
    }
	
	void Update(){
		
		getCurrentFill();
	}
	
	void getCurrentFill(){
	
		float fillAmount = building.productionProgress;
		
		RectTransform rt = fill.GetComponent<RectTransform>();
		rt.localScale = new Vector3(fillAmount, 1, 1);
		
		fill.color = color;
	}
}
