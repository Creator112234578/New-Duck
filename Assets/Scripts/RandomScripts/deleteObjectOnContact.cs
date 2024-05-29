using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObjectOnContact: MonoBehaviour
{
    public GameObject Object;
    public int layer1;
    public int layer2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == layer1 || collision.gameObject.layer == layer2)
        {
            Destroy(Object);
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == layer1 || collision.gameObject.layer == layer2)
        {
            Destroy(Object);
        }
    }
}
