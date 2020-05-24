using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuildingPanel : MonoBehaviour
{
    Building building;
    RectTransform rectTransform;

    public Building Building
    {
        get { return building; }
        set
        {
            building = value;
            header.text = building.description.name;
            description.text = building.description.description;
        }
    }
    public static BuildingPanel instance;
    public TextMeshProUGUI header;
    public TextMeshProUGUI description;

    void Awake()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(0, 0, 0);
    }

    protected virtual void Start()
    {
        rectTransform.localScale = Vector3.zero;
    }

    public void Close()
    {
        LeanTween.scale(gameObject, Vector3.zero, 0.3f).setDestroyOnComplete(false);
    }

    public void Open()
    {
        LeanTween.scale(gameObject, Vector3.one, 0.3f).setDestroyOnComplete(false);
    }

}
