using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaging : MonoBehaviour
{
    public int damageCount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Skeleton ems = collision.gameObject.GetComponent<Skeleton>();
            ems.TakeDamage(damageCount);
        }
        if (collision.gameObject.layer == 18)
        {
            Boss ems1 = collision.gameObject.GetComponent<Boss>();
            ems1.TakeDamage(damageCount);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Skeleton ems = collision.gameObject.GetComponent<Skeleton>();
            ems.TakeDamage(damageCount);
        }
        if (collision.gameObject.layer == 18)
        {
            Boss ems1 = collision.gameObject.GetComponent<Boss>();
            ems1.TakeDamage(damageCount);
        }
    }
}
