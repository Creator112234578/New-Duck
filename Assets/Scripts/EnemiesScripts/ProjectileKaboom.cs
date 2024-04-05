using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileKaboom : MonoBehaviour
{
    public Rigidbody rigidbody;
    public SphereCollider SC;
    public GameObject KaboomEffect;
    public float Bullet;
    public float Mass;
    public float kaboomRadius;
    public float force;
    void Start()
    {   
        SC = GetComponent<SphereCollider>();
        rigidbody.mass = Mass;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyingObject()
    {
        Destroy(KaboomEffect);
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer != 11)
        {
            Instantiate(KaboomEffect, transform.position, transform.rotation);
            Collider[] colliders = Physics.OverlapSphere(transform.position, kaboomRadius);
            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force, transform.position, kaboomRadius);
                }
            }
            Destroy(this.gameObject);
            Invoke(nameof(DestroyingObject), 0.5f);
            Debug.Log("Kaboom");
        }
    }
}
