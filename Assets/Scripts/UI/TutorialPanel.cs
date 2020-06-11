using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
	public GameObject next;
	

    void Update()
    {
        if(Input.anyKey)
		{
			if(next != null) Instantiate(next, transform.position, Quaternion.identity, transform);
			Destroy(gameObject);
		}	
    }
}
