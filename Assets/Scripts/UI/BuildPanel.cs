using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPanel : MonoBehaviour
{
    public static BuildPanel instance;
    protected RectTransform rectTransform;
    public BuildingDescPanel buildingDescPanelPrefab;
    protected BuildingDescPanel activeBuildingDescPanel;
    public bool hideOnStart = true;

    void Awake()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>();
        if (hideOnStart)
        {
            rectTransform.localScale = new Vector3(0, 0, 0);
        }
    }

    public virtual void Show(Tile tile)
    {
        LeanTween.scale(rectTransform, Vector3.one, 0.5f);
        foreach(BuildIcon icon in GetComponentsInChildren<BuildIcon>())
        {
            icon.Refresh();
        }
    }

    public virtual void Hide()
    {

        LeanTween.scale(rectTransform, Vector3.zero, 0.5f);
        if (activeBuildingDescPanel != null)
            LeanTween.scale(activeBuildingDescPanel.gameObject, Vector3.zero, 0.3f).setDestroyOnComplete(true);
    }

    public virtual void ShowBuildingInfo(Building building)
    {
        if (activeBuildingDescPanel != null)
            LeanTween.moveLocalX(activeBuildingDescPanel.gameObject, 0, 0.3f).setDestroyOnComplete(true);

        activeBuildingDescPanel = Instantiate(buildingDescPanelPrefab, transform.parent);
        transform.SetAsLastSibling();
        activeBuildingDescPanel.BuildingDesc = building.description;
        LeanTween.moveLocalX(activeBuildingDescPanel.gameObject, -400, 0.3f);
    }

    public virtual void ShowBuildingInfo(Building building, Vector3 position)
    {
        if (activeBuildingDescPanel != null)
            LeanTween.moveLocalX(activeBuildingDescPanel.gameObject, 0, 0.3f).setDestroyOnComplete(true);

        activeBuildingDescPanel = Instantiate(buildingDescPanelPrefab, transform.parent);
        transform.SetAsLastSibling();
        activeBuildingDescPanel.BuildingDesc = building.description;
        LeanTween.moveLocalX(activeBuildingDescPanel.gameObject, -400, 0.3f);
    }

}
