using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xyz : MonoBehaviour
{
    public Vector3 rotationChange;
    public Vector3 positionChange;
    public Vector3 scaleChange;
    void Start()
    {

    }

    void Update()
    {
        transform.localScale += scaleChange;
        transform.Rotate(rotationChange);
        transform.localPosition += positionChange;

    }
}