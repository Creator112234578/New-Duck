using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamaging : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
        {
            StartCoroutine(collision.gameObject.GetComponent<EnemyHealth>().EnemyDamaged(damageAmount));
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
        {
            StartCoroutine(collision.gameObject.GetComponent<EnemyHealth>().EnemyDamaged(damageAmount));
        }
    }
}
