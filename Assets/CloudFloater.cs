using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFloater : MonoBehaviour
{
    [SerializeField] float floatDistY = 2f;
    [SerializeField] float floatTime = 2f;

    void Start()
    {

        LeanTween.moveY(gameObject, gameObject.transform.position.y - floatDistY, floatTime).setLoopPingPong(int.MaxValue);
    }


}
