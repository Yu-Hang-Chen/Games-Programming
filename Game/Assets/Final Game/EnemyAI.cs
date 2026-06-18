using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Chasing Target")]
    public Transform player;           

    [Header("Chasing Range")]
    public float chaseRange = 10f;     // Chasing Range
    public float loseRange = 15f;      // Stop Chasing Range

    [Header("Chasing Settings")]
    public float chaseSpeed = 3f;      // Chasing Speed
    public float wanderSpeed = 2f;     // Wander Speed

    [Header("Wandering Settings")]
    public float wanderRadius = 8f;    // WanderRadius
    public float wanderTimer = 3f;     // Timer for Wandering 

    [Header("Animator")]
    public Animator animator;

    [Header("MonsterStop")]
    public float viewAngle = 60f;   
    public float viewDistance = 10f;

    private NavMeshAgent agent;
    private float timer;
    private Vector3 randomDirection;

    public AudioSource sound2;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }

        // Iniitalize Wander Direction
        randomDirection = Random.insideUnitSphere;
        timer = wanderTimer;
        sound2.Pause();
    }

    void Update()
    {
        if (player == null) return;

        if (isLookByPlayer())
        {
            Debug.Log("Looking By Player");
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= 10f)
        {
            if (!sound2.isPlaying)
            {
                sound2.Play();
            }
            else {
                sound2.UnPause();
            }
           
           
        }
        else {

            sound2.Pause();
        }
        // If Player is within the chasing range we triger chase 
        if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer();


        }
        // If Player is not within the chasing range we stop chasing but wandering
        else if (distanceToPlayer >= loseRange)
        {
            Wander();
           
        }
        
        else
        {
            agent.isStopped = true;
            sound2.Pause();
        }
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);
    }

    void Wander()
    {
        agent.isStopped = false;
        agent.speed = wanderSpeed;

        timer -= Time.deltaTime;
           
        // Get Random Direction 
        if (timer <= 0)
        {
            randomDirection = Random.insideUnitSphere;
            randomDirection.y = 0; 
            timer = wanderTimer;
        }

        // Calculate Random Move
        Vector3 targetPos = transform.position + randomDirection * wanderRadius;

        // Limit the random move is on a nav mesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPos, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
        else
        {
            agent.SetDestination(targetPos);
        }
    }

    bool isLookByPlayer() {
        Vector3 dirToMonster = (transform.position - player.position).normalized;
        Vector3 playerForward = player.forward;

        float angle = Vector3.Angle(playerForward, dirToMonster);

        float dist = Vector3.Distance(player.position, transform.position);

        return angle < viewAngle && dist < viewDistance;
    }

    void OnDrawGizmosSelected()
    {
        // Draw Chasing Range for Management
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, loseRange);
    }
}
