using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Skeleton : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    public float EnemyDistanceRun = 4.0f;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    public float projectileSpeed = 35f;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public bool miniboss = false;
    public bool manki = false;

    public GameObject HoldsEnemyDashScript;
    public EnemyDash EnemyDashScript;

    public GameObject[] lightningPrefabs;
    private float spawnRangeX = 6;
    private float spawnPosZ = -4;

    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 6;
    private float spawnPosZ = -4;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        

        float distance = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log("Distance: " + distance);
        

        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        // Run away from player
        if (distance < EnemyDistanceRun)
        {
            // Vector player to me
            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            agent.SetDestination(newPos);
        }
        else if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        if (!manki)
        {
            //Make sure enemy doesn't move
            agent.SetDestination(transform.position);
        }
        

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            if (miniboss)
            {
                StartCoroutine(MinibossAtack());
            }
            else
            {
                Rigidbody rb = Instantiate(projectile, transform.position + (transform.forward * 1), Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 35f, ForceMode.Impulse);
            }
            
            
            //rb.AddForce(transform.up * 4f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private IEnumerator MinibossAtack()
    {
        for (int i = 0; i < 3; i++)
        {
            Rigidbody rb = Instantiate(projectile, transform.position + (transform.forward * 1), Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(0.1f);
        }
    }


    private void BossFinalPhase2()
    {
        attackRange = 1.33f;
        EnemyDashScript.enabled = true;
    }

    private IEnumerator BossFinalPhase2_Lightnings()
    {
        Vector3 spawnPos2 = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(lightningPrefabs[0], spawnPos2, lightningPrefabs[0].transform.rotation);
        yield return new WaitForSeconds(60f);
    }

    private IEnumerator BossFinalPhase1_Enemies()
    {
        Vector3 spawnPos1 = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(enemyPrefabs[0], spawnPos1, enemyPrefabs[0].transform.rotation);
        yield return new WaitForSeconds(60f);
    }
}
