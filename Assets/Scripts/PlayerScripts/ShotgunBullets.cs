using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullets : MonoBehaviour
{
    public Rigidbody rigidbody;
    public SphereCollider SC;
    public float Bullet;
    public float Mass;
    public float MinRandomSpread;
    public float MaxRandomSpread;
    public float Spread;
    void Start()
    {
        rigidbody.mass = Mass;
        Spread = Random.Range(MinRandomSpread, MaxRandomSpread);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(transform.forward * Bullet, ForceMode.Impulse);
        transform.localRotation = Quaternion.Euler(Spread, Spread, Spread);
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
    }


}
