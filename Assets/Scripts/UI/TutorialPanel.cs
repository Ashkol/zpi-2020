using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Needs parent object, other instantiated panels are also set as children of this object
public class TutorialPanel : MonoBehaviour
{
	public GameObject next;
	

    void Update()
    {
        if(Input.anyKeyDown)
		{
			if(next != null) Instantiate(next, transform.position, Quaternion.identity, transform.parent);
			gameObject.SetActive(false);
		}	
    }
}
