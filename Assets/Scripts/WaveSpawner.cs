using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    private int waveIndex = 0;


    [Header("Next Wave attributes")]
    public GameObject startWaveButton;
    public Text waveText;



    void Start()
    {
        
    }

    void Update()
    {
        if (enemiesAlive == 0)
        {
            startWaveButton.SetActive(true);
        }       
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        waveIndex++;
        PlayerStats.Rounds++;

        waveText.text = string.Format("WAVE:{0}", waveIndex);

        startWaveButton.SetActive(false);


        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }


        if (waveIndex == waves.Length)
        {
            Debug.Log("VICTORY!");
            this.enabled = false;
        }
    }

    public void StartWave()
    {
        StartCoroutine(SpawnWave());       
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
