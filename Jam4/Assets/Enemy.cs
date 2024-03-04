using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float detectionRange = 5f;

    [SerializeField] private Vector2[] patrolPoints;

    private Transform player;
    private Rigidbody2D rb;
    private int currentPatrolIndex = 0;
    private bool isChasing = false;

    public Vector2[] PatrolPoints => patrolPoints;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }

        if (rb.velocity.magnitude > 0)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void Patrol()
    {
        Vector2 targetPoint = patrolPoints[currentPatrolIndex];
        Vector2 movement = (targetPoint - (Vector2)transform.position).normalized;
        rb.velocity = movement * patrolSpeed;

        if (Vector2.Distance(transform.position, targetPoint) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }

        if (Vector2.Distance(transform.position, player.position) < detectionRange)
        {
            isChasing = true;
        }
    }

    private void ChasePlayer()
    {
        Vector2 movement = (player.position - transform.position).normalized;
        rb.velocity = movement * chaseSpeed;

        if (Vector2.Distance(transform.position, player.position) > detectionRange)
        {
            isChasing = false;
        }
    }
}