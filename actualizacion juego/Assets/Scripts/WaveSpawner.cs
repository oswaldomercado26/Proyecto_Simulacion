using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public float timeBetweenWaves = 10f;
    public float timeBeteenEnemies = 1f;
    public float countdownWaves = 2f;

    public CastelManager castleManager;

    private int waveIndex = 0;
    public GameObject spawners;
    private GameObject[] enemies;


    public Text waveCountdownText;    
    public GameObject waveContCountainer;
    public Text totalEnemies;    
    public Text enemiesLeft; 
    public GameObject enemiesContainer;   
    public GameObject gameOverScreen;   
    public GameObject healthBar;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft.text = enemies.Length.ToString();
    }

    void Update()
    {
        if (castleManager.vida > 0)
        {
            gameOverScreen.SetActive(false);
            if (countdownWaves <= 0)
            {
                countdownWaves = timeBetweenWaves;
                StartCoroutine(spawnWave());
            }
            if (enemies.Length > 0)
            {
                waveContCountainer.SetActive(false);
                enemiesContainer.SetActive(true);
                countdownWaves = timeBetweenWaves;
            } else {
                waveContCountainer.SetActive(true);
                enemiesContainer.SetActive(false);
                countdownWaves -= Time.deltaTime;

            }
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            enemiesLeft.text = enemies.Length.ToString();
            waveCountdownText.text = Mathf.FloorToInt(countdownWaves + 1).ToString();
        } else {
            gameOverScreen.SetActive(true);
            waveContCountainer.SetActive(false);
            enemiesContainer.SetActive(false);
            healthBar.SetActive(false);
        }
    }

    IEnumerator spawnWave(){
        waveIndex ++;
        int enemyCount = waveIndex * waveIndex + 1;
        totalEnemies.text = enemyCount.ToString();
        print(enemyCount);
        for (int i = 0; i < enemyCount; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(timeBeteenEnemies);
        }
    }
    void spawnEnemy(){
        spawners.GetComponent<SpawnManager>().spawnNewEnemy();
    }
}
