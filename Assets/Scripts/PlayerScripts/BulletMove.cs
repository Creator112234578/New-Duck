using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Rigidbody rigidbody;
    public SphereCollider SC;
    public float Bullet;
    public float Mass;
    void Start()
    {
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
    }


    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 6)
        {
            DestroyingObject();
            Debug.Log("Hited");
        }
        else if (col.gameObject.layer == 10)
        {
            Skeleton ems = GameObject.Find("Skeleton").GetComponent<Skeleton>();
            DestroyingObject();
            ems.TakeDamage(120);
            Debug.Log("Damage deal't");
        }
        else if (col.gameObject.layer == 11)
        {
            Zombie ems1 = GameObject.Find("Zombie").GetComponent<Zombie>();
            DestroyingObject();
            ems1.TakeDamage(120);
            Debug.Log("Damage deal't");
        }
    }
}
