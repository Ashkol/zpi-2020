using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AshkolTools.UI;

public class ProductionBuildingPanel : BuildingPanel
{
    [SerializeField] ProductionBuilding building;
    [SerializeField] ProgressBar progressBar;
    public override Building Building
    {
        get { return building; }
        set
        {
            building = value as ProductionBuilding;
            header.text = building.description.name;
            description.text = building.description.description;
            building.OnProductionProgress.AddListener(UpdateProgressBar);
            progressBar.maximum = 1f;
            progressBar.current = 0f;
        }
    }

    protected override void Start()
    {
        base.Start();
    }

    void UpdateProgressBar()
    {
        progressBar.current = building.productionProgress;
    }
}
