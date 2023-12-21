using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject DuckInHand;
    public Transform Cam;

    public float shootCD;
    public float kaboomCD;
    public float shotgunCD;
    public float currentShootCD;
    public float currentKaboomCD;
    public float currentShotgunCD;
    public bool readyToThrow;
    public float shotgunRageMeter;
    public bool shotgunRageMeterActive;

    public LayerMask layer;

    Ray ray1;
    Ray ray2;

    RaycastHit hited1;
    RaycastHit hited2;

    public KeyCode shoot1;
    public KeyCode shoot2;
    public KeyCode shotgun1;
    public KeyCode shotgunRageMeterActivator;
    public KeyCode shotgun2;

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
         shotgunRageMeterActive = false;
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
             if (Input.GetMouseButton(1) && shotgunRageMeter == 100)
             {
                 shootCD = shootCD - 0.15f;
                 kaboomCD = kaboomCD - 1.5f;
                 shotgunCD = shotgunCD - 0.75f;
                 shotgunRageMeterActive = true;
             }
        }
        if (shotgunRageMeterActive == true)
        {
            shotgunRageMeter -= Time.deltaTime * 10;
        }
        if (shotgunRageMeter <= 0)
        {
            shotgunRageMeterActive = false;
        }
        if (shotgunRageMeterActive == false)
        {
            shootCD = shootCD;
            kaboomCD = kaboomCD;
            shotgunCD = shotgunCD;
        }
    }
    void WeaponSwitcher()
    {
        if (Input.GetKeyDown(shoot1) || Input.GetKeyDown(shoot2))
        {
            weapon = Weapons.pistol;
        }
        if (Input.GetKeyDown(shotgun1) || Input.GetKeyDown(shotgun2))
        {
            weapon = Weapons.shotgun;
        }
    }
    void Shoot()
    {   
        readyToThrow = false;

        Instantiate(Object, Cam.position, Cam.rotation);
        Debug.Log("WorkingShot");
        DuckInHand.SetActive(false);
        Invoke(nameof(ResetShoot), shootCD);
    }
    void Kaboom()
    {   
        readyToThrow = false;
        Instantiate(KaboomObject, Cam.position, Cam.rotation);
        Debug.Log("WorkingShot");
        DuckInHand.SetActive(false);
        Invoke(nameof(ResetShoot), kaboomCD);
    }
    void Shotgun()
    {   
        readyToThrow = false;
        Instantiate(ShotgunObject, Cam.position, Cam.rotation);
        Debug.Log("WorkingShot");
        DuckInHand.SetActive(false);
        Invoke(nameof(ResetShoot), shotgunCD);
    }
    void ResetShoot()
    {
        readyToThrow = true;
        DuckInHand.SetActive(true);
    }
}
