using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScript : MonoBehaviour
{
    public List<Transform> Enemies;
    public bool counterNew;
    public int Count;
    public List<Vector3> WhereToGo;
    void Start()
    {

    }
    void Update()
    {
        foreach (Transform Enemie in Enemies)
        {
            if (Enemie == null)
            {
                Enemies.Remove(Enemie);
            }
        }
        foreach (Vector3 whereToGo in WhereToGo)
        {
            if (whereToGo == null)
            {
                WhereToGo.Remove(whereToGo);
            }
        }
        if (counterNew == true)
        {
            Enemies[Count].position = WhereToGo[Count];
            Count += 1;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            counterNew = true;
        }
    }

}

