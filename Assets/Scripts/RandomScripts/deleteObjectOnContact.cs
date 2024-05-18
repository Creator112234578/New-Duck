using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObjectOnContact : MonoBehaviour
{
    public GameObject ObjectToDelete;
    public int Layer;
    public int Layer1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == Layer || collision.gameObject.layer == Layer1)
        {
            Destroy(ObjectToDelete);
        }
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == Layer || collider.gameObject.layer == Layer1)
        {
            Destroy(ObjectToDelete);
        }
    }
}
