using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinibossProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(15, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
