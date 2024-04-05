using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaging : MonoBehaviour
{
    public int damageCount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
        {
            StartCoroutine(FindObjectOfType<EnemyHealth>().EnemyDamaged(damageCount));
        }
    }
}
