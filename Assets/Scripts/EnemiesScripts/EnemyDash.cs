using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDash : MonoBehaviour
{
    public float dashSpeed = 10f;
    public float dashDistance = 5f;
    public float cooldownTime = 2f;
    public Transform player;
    private bool isDashing = false;
    private float cooldownTimer = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isDashing && cooldownTimer <= 0f && Vector3.Distance(transform.position, player.position) < dashDistance)
        {
            DashTowardsPlayer();
        }

        cooldownTimer -= Time.deltaTime;
    }

    void DashTowardsPlayer()
    {
        isDashing = true;
        float dashDuration = dashDistance / dashSpeed;
        StartCoroutine(DashCoroutine(dashDuration));
        cooldownTimer = cooldownTime;
    }

    IEnumerator DashCoroutine(float duration)
    {
        float timer = 0;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = player.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)); // Add some randomness to the dash direction

        while (timer < duration)
        {
            float t = timer / duration;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            timer += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
    }
}