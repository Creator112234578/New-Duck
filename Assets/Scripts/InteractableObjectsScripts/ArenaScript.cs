using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScript : MonoBehaviour
{
    public List<Transform> Enemies;
    public List<Transform> EnemiesInWave;
    public List<Transform> EnemiesInWaveSetter;

    public List<int> WavesEnemieAmount;
    public int Waves;
    public int counter;
    public bool counterNew;
    public int CountdownEnemy;
    public List<Transform> EnemiesToSpawn;
    public List<Vector3> ObjectPosition;
    public List<Vector3> ObjectToSpawnPosition;
    public Transform SpawnerWaveReseter;
    void Start()
    {
        List<Transform> EnemiesToSpawn = new List<Transform>();
        List<Transform> EnemiesInWave = new List<Transform>();
        List<int> WavesEnemieAmount = new List<int>();
        List<Transform> EnemiesInWaveSetter = new List<Transform>();
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
        foreach (Transform Enemie2 in EnemiesToSpawn)
        {
            if (Enemie2 == null)
            {
                EnemiesToSpawn.Remove(Enemie2);
            }
        }
        foreach (Vector3 Object in ObjectPosition)
        {
            if (Object == null)
            {
                ObjectPosition.Remove(Object);
            }
        }
        foreach (Vector3 Object in ObjectToSpawnPosition)
        {
            if (Object == null)
            {
                ObjectToSpawnPosition.Remove(Object);
            }
        }
        if (counterNew == true)
        {
            if (counter < WavesEnemieAmount[Waves])
            {
                ObjectToSpawnPosition.Add(ObjectPosition[counter]);
                EnemiesToSpawn.Add(Enemies[counter]);
                counter += 1;
            }
            else
            {
                foreach (Transform Enemie1 in EnemiesToSpawn)
                {
                    foreach (Vector3 Object in ObjectToSpawnPosition)
                    {
                        Enemie1.localPosition = Object;
                        CountdownEnemy += 1;
                    }
                }
                if (EnemiesToSpawn.Count == 0)
                {
                    ObjectToSpawnPosition.Clear();
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
