using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameControl : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Adam Test");
    }
}
