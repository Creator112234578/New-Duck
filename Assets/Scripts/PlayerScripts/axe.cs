using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour
{
    public Transform rotation;
    public GameObject axeObject;
    public KeyCode axeKey;
    public float destroingSpeed;
    public bool axeSwinging;
    void Start()
    {
        axeSwinging = false;
	axeObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(axeKey))
        {
            axeSwinging = true;
            axeObject.SetActive(true);
            Invoke(nameof(objectDestroy), destroingSpeed);
        }
        if (axeSwinging == false)
        {
            rotation.localRotation = Quaternion.Euler(0, 120, 0);
        }
        rotation.Rotate(0, 0, 1080 * Time.deltaTime);
    }
    void objectDestroy()
    {
        axeSwinging = false;
        rotation.localRotation = Quaternion.Euler(0, 120, 0);
        axeObject.SetActive(false);
    }
}
