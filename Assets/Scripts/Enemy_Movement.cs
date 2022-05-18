using UnityEngine;
using UnityEngine.UI;

public class Enemy_Movement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    public float startSpeed = 10f;

    private bool enemyDiesOnce;

    [HideInInspector]
    public float speed;

    public float startHealth = 100;

    private float health;

    public int moneyGain = 10;

    [Header("Unity stuff")]
    public Image healthBar;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
        target = Waypoints.points[0];
        enemyDiesOnce = false;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
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
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
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