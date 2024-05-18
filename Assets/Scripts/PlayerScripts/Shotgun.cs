using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Rigidbody rigidbody;
    public SphereCollider SC;
    public float Bullet;
    public float Mass;
    public float Spread;
    public float maxSpread;
    public float minSpread;
    void Start()
    {
        
        Spread = Random.Range(minSpread, maxSpread);
        rigidbody.mass = Mass;
    }

    // Update is called once per frame
    void Update()
    {
        
        rigidbody.AddForce(transform.forward * Bullet, ForceMode.Impulse);
        rigidbody.AddForce(transform.up * Spread, ForceMode.Impulse);
        rigidbody.AddForce(transform.right * Spread, ForceMode.Impulse);
    }
    void DestroyingObject()
    {
        Destroy(this.gameObject);
    }


    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 6 || col.gameObject.layer == 10 || col.gameObject.layer == 11)
        {   
            DestroyingObject();
            Debug.Log("Hited");
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 10 || col.gameObject.layer == 11)
        {
            DestroyingObject();
            Debug.Log("Hited");
        }
    }
}
