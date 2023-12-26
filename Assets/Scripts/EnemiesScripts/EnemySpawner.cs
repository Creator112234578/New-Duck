using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] Enemies;
    public Transform[] EnemiesPositions;
    public int counter;
    void Update()
    {
        foreach (GameObject Enemie in Enemies)
        {
            Instantiate(Enemie, EnemiesPositions[counter].position, EnemiesPositions[counter].rotation);
            counter += 1;
        }
    }
}
