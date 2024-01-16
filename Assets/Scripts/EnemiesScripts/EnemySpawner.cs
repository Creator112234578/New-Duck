using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] Enemies;
    public Transform[] EnemiesPositions;
    public int Waves;
    public int CurrentWaves;
    public int EnemiesToSpawn;
    public int[] WavesEnemieAmount;
    public int counter;
    void Update()
    {
        while (CurrentWaves < Waves)
        {
        	foreach (GameObject Enemie in Enemies)
        	{
            		Instantiate(Enemie, EnemiesPositions[counter].position, EnemiesPositions[counter].rotation);
            		counter += 1;
        	}
                if (Enemies.Length < 0)
                {
                	CurrentWaves += 1;
                }
        }
    }
}
