using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strange : MonoBehaviour
{
    public Transform Projectile;
    public GameObject[] Player;
    public float Speed;
    public Transform PlayerPosition;
    void Start()
    {
         Player = GameObject.FindGameObjectsWithTag("Player");
         PlayerPosition = Player[0].GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
         Projectile.Translate(Vector3.forward * Speed * Time.deltaTime);
         Speed += 0.1f;
         if (Speed < 50)
         {
            Projectile.LookAt(PlayerPosition.position);
         }
    }
}
