using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform DoorOpening;
    public float Height;
    public float Speed;
    public float Holder;
    public bool Opened;
    void Start()
    {
        Holder = DoorOpening.position.y;
    }

    void Update()
    {
        if (Opened == true)
        {
           Open();
        }
        if (Opened == false)
        {
           Close();
        }
    }
    void Open()
    {
        if (DoorOpening.position.y >= Holder + Height)
        {
           DoorOpening.position = new Vector3(DoorOpening.position.x, Holder + Height, DoorOpening.position.z);
        }
        else
        {
           DoorOpening.Translate(Vector3.up * Speed * Time.deltaTime);
        }
    }
    void Close()
    {
        if (DoorOpening.position.y <= Holder)
        {
           DoorOpening.position = new Vector3(DoorOpening.position.x, Holder, DoorOpening.position.z);
        }
        else
        {
           DoorOpening.Translate(Vector3.down * Speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           Opened = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
           Opened = false;
        }
    }
}
