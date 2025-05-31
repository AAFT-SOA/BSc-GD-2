using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform PlayerTransform;
    NavMeshAgent agent;
    Animator animator;

    public LayerMask whatIsGround, whatIsPlayer;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
            animator.SetBool("IsWalking", true);
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
            animator.SetBool("IsWalking", true);
        }
        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
            animator.SetBool("IsAttacking", true);
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

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}