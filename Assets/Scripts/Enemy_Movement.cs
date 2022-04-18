using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    public float startSpeed = 10f;

    private bool enemyDiesOnce;

    [HideInInspector]
    public float speed;

    public float health = 100;

    public int moneyGain = 10;

    void Start()
    {
        speed = startSpeed;
        target = Waypoints.points[0];
        enemyDiesOnce = false;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0 && !enemyDiesOnce)
        {
            Die();
        }
    }

    void Die()
    {
        enemyDiesOnce = true;

        PlayerStats.Money += moneyGain;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);

    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        speed = startSpeed;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

}