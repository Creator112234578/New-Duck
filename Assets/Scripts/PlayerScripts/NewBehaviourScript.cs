using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform shotgunDucksFolder;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shotgunDucksFolder.childCount <= 0)
        {
           Destroy(this.gameObject);
        }
    }

}
