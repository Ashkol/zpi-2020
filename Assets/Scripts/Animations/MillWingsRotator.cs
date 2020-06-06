using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillWingsRotator : MonoBehaviour
{
    [SerializeField] float rotationTime = 20f;

    void Start()
    {
        LeanTween.rotateAround(gameObject, Vector3.forward, 360, rotationTime).setLoopClamp();
    }

}
