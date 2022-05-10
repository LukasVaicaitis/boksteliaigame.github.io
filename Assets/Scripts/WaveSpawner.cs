using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    private int waveIndex = 0;

    private bool enemiesSpawned;

    public Manager manager;


    [Header("Next Wave attributes")]
    public GameObject startWaveButton;
    public Text waveText;



    void Start()
    {
        enemiesSpawned = false;
    }

    void Update()
    {
        if (enemiesAlive > 0)
            return;

        if (waveIndex == waves.Length && !WaveActive())
        {
            manager.WinLevel();
            this.enabled = false;
        }

        if (!WaveActive() && enemiesSpawned == true)
        {
            startWaveButton.SetActive(true);
            enemiesSpawned = false;
        }       
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        waveIndex++;
        PlayerStats.Rounds++;

        waveText.text = string.Format("WAVE:{0}", waveIndex);


        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);           
            yield return new WaitForSeconds(1f / wave.rate);
        }

        enemiesSpawned = true;
    }

    public void StartWave()
    {
        StartCoroutine(SpawnWave());
        startWaveButton.SetActive(false);
    }

    void SpawnEnemy(GameObject enemy)
    {
        enemiesAlive++;
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    public bool WaveActive()
    {
        return enemiesAlive != 0;
    }
}
