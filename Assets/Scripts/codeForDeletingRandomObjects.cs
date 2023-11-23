using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeForDeletingRandomObjects : MonoBehaviour
{
    public GameObject objectToDestroy;
    public float deletingSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(("Destroy"), deletingSpeed);
    }
    void Destroy()
    {
    	Destroy(objectToDestroy);
    }
}
