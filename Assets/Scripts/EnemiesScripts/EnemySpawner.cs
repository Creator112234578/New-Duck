using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] Enemies;
    public Transform[] EnemiesPositions;
    public int[] WavesEnemieAmount;
    public int Waves;
    public int CurrentWaves;
    public int EnemiesToSpawn;
    public int counter;
    public int CountdownEnemy;
    void Start()
    {
	Waves = WavesEnemieAmount.Length;
    }
    void Update()
    {
        GameObject[] CurrentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; CurrentWaves < Waves; counter += 1)
        {
            Instantiate(Enemies[counter], EnemiesPositions[counter].position, EnemiesPositions[counter].rotation);
        }
        
        if (CurrentEnemies.Length > 0)
        {
            foreach (GameObject Enemie in CurrentEnemies)
            {
                 if (Enemie.activeSelf == false)
                 {
                    CountdownEnemy += 1;
                 }
            }
        }
    }
}
