using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public List<GameObject> Enemies;
    public List<GameObject> EnemiesInWave;
    public List<GameObject> EnemiesInWaveSetter;
    public List<List<GameObject>> EnemiesKinda;

    public List<int> WavesEnemieAmount;
    public int Waves;
    public int counter;
    public bool counterNew;
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
        foreach (GameObject Enemie in Enemies)
        {
            if (Enemie == null)
            {
                Enemies.Remove(Enemie);
            }
        }
        foreach (GameObject Enemie2 in EnemiesToSpawn)
        {
            if (Enemie2 == null)
            {
                EnemiesToSpawn.Remove(Enemie2);
            }
        }
        if (counterNew == true)
        {
            if (counter < WavesEnemieAmount[Waves])
            {
                EnemiesToSpawn.Add(Enemies[counter]);
                counter += 1;
            }
            else
            {
                foreach (GameObject Enemie1 in EnemiesToSpawn)
                {
                    Enemie1.active = true;
                    CountdownEnemy += 1;
                }
                if (EnemiesToSpawn.Count == 0)
                {
                    EnemiesToSpawn.Clear();
                    CountdownEnemy = 0;
                    Waves += 1;
                    counter = 0;
                }
            }
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
