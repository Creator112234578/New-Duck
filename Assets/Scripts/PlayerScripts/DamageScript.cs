using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damageCount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            StartCoroutine(FindObjectOfType<PlayerManager>().Damage(damageCount));
        }
    }
}
