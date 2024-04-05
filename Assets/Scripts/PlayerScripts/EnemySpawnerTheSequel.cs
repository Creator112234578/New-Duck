using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTheSequel : MonoBehaviour
{

    public List<GameObject> Enemies;
    public List<GameObject> EnemiesInWave;
    public List<GameObject> EnemiesInWaveSetter;
    public List<List<GameObject>> EnemiesKinda;

    public List<int> WavesEnemieAmount;
    public int Waves;
    public int counter;
    public int CountdownEnemy;
    public List<GameObject> EnemiesToSpawn;
    public Transform SpawnerWaveReseter;
    void Start()
    {
        List<GameObject> EnemiesToSpawn = new List<GameObject>();
        List<GameObject> EnemiesInWave = new List<GameObject>();
        List<List<GameObject>> EnemiesKinda = new List<List<GameObject>>();
        List<int> WavesEnemieAmount = new List<int>();
        List<GameObject> EnemiesInWaveSetter = new List<GameObject>();
    }
    void Update()
    {

    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i == 0; i++)
            {
                Waves = i;
                if (CountdownEnemy < i)
                {
                    EnemiesToSpawn.Add(Enemies[counter]);
                    CountdownEnemy += 1;
                    counter += 1;
                }
                else
                {
                    foreach (GameObject Enemie1 in EnemiesToSpawn)
                    {
                        Enemie1.active = true;
                        CountdownEnemy += 1;
                    }
                    if (SpawnerWaveReseter.childCount == SpawnerWaveReseter.childCount - i)
                    {
                        CountdownEnemy = 0;
                    }
                }

            }
        }
    }
}
