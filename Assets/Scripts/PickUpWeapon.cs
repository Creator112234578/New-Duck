using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PickUpWeapon : MonoBehaviour
{
    public GameObject camera;
    public float distance = 2f;
    GameObject currentWeapon;
    bool canPickUp = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
    }
    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "stone")
            {
                if (canPickUp) Drop();
                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.GetComponent<Collider>().isTrigger = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = new Vector3(-97.26f, -73.16f, 71.71f);
                currentWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                canPickUp = true;
            }
            if (hit.transform.tag == "key")
            {
                if (canPickUp) Drop();
                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.GetComponent<Collider>().isTrigger = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = new Vector3(-107.1f, 63.9f, 2.3f);
                currentWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
                canPickUp = true;
            }

        }

        if (currentWeapon = null);
        {
            canPickUp = false;
        }
    }
    void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon.GetComponent<Collider>().isTrigger = false;
        canPickUp = false;
        currentWeapon = null;
    }
}