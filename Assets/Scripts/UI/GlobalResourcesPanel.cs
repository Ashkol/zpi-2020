using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GlobalResourcesPanel : MonoBehaviour
{
	private Text boardsAmountText;
	private Text stonesAmountText;
	private Text bricksAmountText;
	
    // Start is called before the first frame update
    void Start()
    {
        boardsAmountText = this.gameObject.transform.GetChild(0).GetComponent<Text>();
		stonesAmountText = this.gameObject.transform.GetChild(1).GetComponent<Text>();
		bricksAmountText = this.gameObject.transform.GetChild(2).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        boardsAmountText.text = BuildManager.instance.playerResources.boards.ToString();
		stonesAmountText.text = BuildManager.instance.playerResources.stone.ToString();
		bricksAmountText.text = BuildManager.instance.playerResources.bricks.ToString();
    }
}
