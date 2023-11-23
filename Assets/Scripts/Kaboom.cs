using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaboom : MonoBehaviour
{
    public Rigidbody rigidbody;
    public SphereCollider SC;
    public GameObject KaboomEffect;
    public float Bullet;
    public float Mass;
    void Start()
    {   
        SC = GetComponent<SphereCollider>();
        rigidbody.mass = Mass;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(transform.forward * Bullet, ForceMode.Impulse);
    }
    void DestroyingObject()
    {
        Destroy(this.gameObject);
        Destroy(KaboomEffect);
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 6)
        {   
            SC.radius = 7.5f;
            Instantiate(KaboomEffect, transform.position, transform.rotation);
            Invoke(nameof(DestroyingObject), 0.5f);
            Debug.Log("Kaboom");
        }
    }


}
