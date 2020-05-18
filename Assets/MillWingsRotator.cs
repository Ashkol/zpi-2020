using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillWingsRotator : MonoBehaviour
{
    void Start()
    {
        LeanTween.rotateAround(gameObject, Vector3.forward, 360, 20f).setLoopClamp();
    }

}
