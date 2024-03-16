using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosing : MonoBehaviour
{
    public GameObject[] DoorsToClose;
    public int Count;
    public bool DoorsClose;
    void Start()
    {
        DoorsToClose = GameObject.FindGameObjectsWithTag("Doors");
    }

    // Update is called once per frame
    void Update()
    {
       if (DoorsClose == true)
       {
            foreach (GameObject n in DoorsToClose)
            {
                DoorsToClose[Count].GetComponent<Door>().Opened = false;
                DoorsToClose[Count].SetActive(false);
                Count += 1;
            }
            Count = 0;
       }
       if (DoorsClose == false)
       {
            foreach (GameObject n in DoorsToClose)
            {
                DoorsToClose[Count].SetActive(true);
                Count += 1;
            }
            Count = 0;
       }

    }
    public void OnTriggerEnter()
    {
       DoorsClose = true;
    }
    public void OnTriggerExit()
    {
       DoorsClose = false;
    }
}
