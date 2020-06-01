using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPanelBottom : BuildPanel
{

    void Awake()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>();
        if (hideOnStart)
        {
            rectTransform.localScale = new Vector3(0, 0, 0);
        }
    }

    public override void Show(Tile tile)
    {
        LeanTween.scale(rectTransform, Vector3.one, 0.5f);
        foreach(BuildIcon icon in GetComponentsInChildren<BuildIcon>())
        {
            icon.Refresh();
        }
    }

    public override void Hide()
    {
        LeanTween.scale(rectTransform, Vector3.zero, 0.5f);
        if (activeBuildingDescPanel != null)
            LeanTween.scale(activeBuildingDescPanel.gameObject, Vector3.zero, 0.3f).setDestroyOnComplete(true);
    }
}
