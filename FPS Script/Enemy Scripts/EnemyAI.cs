using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform PlayerTransform;    
    NavMeshAgent agent;

    public LayerMask whatIsGround, whatIsPlayer;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;


    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public Transform firePoint;


    // Health System
    float currentHealth;
    public float maxHealth;
    public EnemyHealthBar healthBar;
    void Start()
    {
        PlayerTransform = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    void Patroling()
    {
        if (!walkPointSet)
            SearchWalkPoints();

        if (walkPointSet == true)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 10f)
        {
            walkPointSet = false;
        }
    }
    void SearchWalkPoints()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {            
            walkPointSet = true;
        }
    }


    void ChasePlayer()
    {
        agent.SetDestination(PlayerTransform.position);
        transform.LookAt(PlayerTransform.position);
    }

    void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(PlayerTransform.position);
        transform.LookAt(PlayerTransform.position);

        if (alreadyAttacked == false)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 20f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }


    public void EnemyDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject,0.2f);
        }

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }


}
