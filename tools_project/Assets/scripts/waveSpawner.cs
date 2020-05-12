using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	

public class waveSpawner : MonoBehaviour
{
    public static int Enemiesalive = 0;
    public float eny;
    // public Transform enemyPrefab;
    public Wave[] waves;
    public float timeBetweenWave = 5f;
    public float countdown = 5f;
    private int waveIndex = 0;
    public Transform EnemySpawnPoint;
  
    public float WaitTime = 0.5f;
    public Text CountDownTimer;
    public GameManager gameManager;

    public void Update()
    {
        eny = Enemiesalive;
        if(Enemiesalive > 0)
        {
            return;
        }
        if(countdown < 0)
        {
           StartCoroutine(SpawnWave());
            countdown = timeBetweenWave;
            return;
        }

        if (waveIndex == waves.Length && Enemiesalive <= 0)
        {
            gameManager.WinLevel();
        }

        countdown -= Time.deltaTime;
    }

  IEnumerator SpawnWave()
    {
        
        GameManager.Rounds++;

        Wave wave = waves[waveIndex];

        Enemiesalive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            EnemySpawn(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
            
        }
        waveIndex++;
       
        
    }

    private void EnemySpawn(GameObject enemy)
    {
        Instantiate(enemy, EnemySpawnPoint.position, EnemySpawnPoint.rotation);

    }


}
