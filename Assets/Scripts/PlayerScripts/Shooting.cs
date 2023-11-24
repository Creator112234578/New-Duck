using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject DuckInHand;
    public Transform Cam;

    public float shootCD;
    public bool readyToThrow;

    public LayerMask layer;

    Ray ray1;
    Ray ray2;

    RaycastHit hited1;
    RaycastHit hited2;

    public GameObject Object;
    public GameObject KaboomObject;

    private void Start()
    {
         DuckInHand.SetActive(true);
    }
    // Update is called once per frame
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection (Vector3.forward) * 1000, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out hited1, 1000, layer) && Input.GetMouseButton(0) && readyToThrow == true)
        {   
            Cam.LookAt(hited1.point);
            Shoot();
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out hited2, 1000, layer) && Input.GetMouseButton(1) && readyToThrow == true)
        {   
            Cam.LookAt(hited2.point);
            Kaboom();
        }
    }
    void Shoot()
    {   
        readyToThrow = false;

        Instantiate(Object, Cam.position, Cam.rotation);
        shootCD = 0.5f;
        Debug.Log("WorkingShot");
        DuckInHand.SetActive(false);
        Invoke(nameof(ResetShoot), shootCD);
    }
    void Kaboom()
    {   
        readyToThrow = false;
        Instantiate(KaboomObject, Cam.position, Cam.rotation);
        shootCD = 2.5f;
        Debug.Log("WorkingShot");
        DuckInHand.SetActive(false);
        Invoke(nameof(ResetShoot), shootCD);
    }
    void ResetShoot()
    {
        readyToThrow = true;
        DuckInHand.SetActive(true);
    }
}
