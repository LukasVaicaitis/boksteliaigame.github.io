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


    [Header("Next Wave attributes")]
    public GameObject startWaveButton;
    public Text waveText;



    void Start()
    {
        enemiesSpawned = false;
    }

    void Update()
    {
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

        if (waveIndex == waves.Length && !WaveActive())
        {
            Debug.Log("VICTORY!");
            this.enabled = false;
        }
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
