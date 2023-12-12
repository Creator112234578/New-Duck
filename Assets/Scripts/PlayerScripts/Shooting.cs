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
    public GameObject ShotgunObject;


    public Weapons weapon;

    public enum Weapons
    {
         pistol,
         shotgun
    }

    private void Start()
    {
         weapon = Weapons.pistol;
         DuckInHand.SetActive(true);
    }
    // Update is called once per frame
    private void Update()
    {
        WeaponSwitcher();
        Debug.DrawRay(transform.position, transform.TransformDirection (Vector3.forward) * 1000, Color.green);
        if (weapon == Weapons.pistol)
        {

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
        else if (weapon == Weapons.shotgun)
        {

             if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out hited1, 1000, layer) && Input.GetMouseButton(0) && readyToThrow == true)
             {    
                 Cam.LookAt(hited1.point);
                 Shotgun();
             }
        }
    }
    void WeaponSwitcher()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            weapon = Weapons.pistol;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            weapon = Weapons.shotgun;
        }
    }
    void Shoot()
    {   
        readyToThrow = false;

        Instantiate(Object, Cam.position, Cam.rotation);
        shootCD = 0.25f;
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
    void Shotgun()
    {   
        readyToThrow = false;
        Instantiate(ShotgunObject, Cam.position, Cam.rotation);
        shootCD = 0.5f;
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
