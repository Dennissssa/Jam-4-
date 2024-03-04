using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float moveSpeed = 5f;
    public string enemyTag = "Enemy";
    public float enemyDistanceThreshold = 1.2f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        float moveInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.forward, -rotationInput * rotationSpeed);

        float currentMoveSpeed = moveSpeed;

        GameObject closestEnemy = FindClosestEnemy();
        if (closestEnemy != null && Vector2.Distance(transform.position, closestEnemy.transform.position) < enemyDistanceThreshold)
        {
            currentMoveSpeed = 2f;
        }

        Vector2 movement = transform.up * moveInput * currentMoveSpeed;
        rb.velocity = movement;
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Fai");
        }
    }
}