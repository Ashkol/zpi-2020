using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanel : MonoBehaviour
{

	GameManager gameManager;
	
	private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if(Input.anyKey)
		{
			gameManager.LoadScene((int)SceneIndexes.MAIN_MENU);
		}
    }
}
