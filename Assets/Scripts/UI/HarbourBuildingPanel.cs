using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HarbourBuildingPanel : BuildingPanel
{
    private Harbour building;
	public new static HarbourBuildingPanel instance;

	public new Harbour Building
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
		instance = this;
    }

	public TextMeshProUGUI bodyCount;
	public GameObject winButton;
	
	void Update()
	{
		if (building != null)
		{
			bodyCount.text = building.getResidents();
			if (building.winConditionsMet() && !winButton.activeSelf) winButton.SetActive(true);
			else if (!building.winConditionsMet() && winButton.activeSelf) winButton.SetActive(false);
		}

	}
	
	public void win(){
	
		building.win();
	}
}
