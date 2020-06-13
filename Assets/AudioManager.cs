using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (musicSource.isPlaying)
            {
                musicSource.Pause();
            }
            else
            {
                musicSource.Play();
            }
        }
    }
}
