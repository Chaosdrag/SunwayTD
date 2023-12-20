using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject bossPrefab;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    [Header("Attributes")]
    [SerializeField] private int numberOfBossesInLastWave = 2;
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;
    [SerializeField] private float enemiesPerSecondCap = 15;

    [Header("Win Condition")]
    [SerializeField] private int totalWavesToWin = 5;
    private int wavesCompleted = 0;

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private float eps;//enemies per second
    private bool isSpawning = false;
    private bool hasBossSpawned = false;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {

    }
    private void Update()

    {

        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / eps) && enemiesLeftToSpawn > 0)
        {
            if (!hasBossSpawned)
            {
                SpawnEnemy();
                enemiesLeftToSpawn--;
                enemiesAlive++;
                timeSinceLastSpawn = 0f;
            }
            else 
            {
                spawnBoss();
                enemiesLeftToSpawn--;
                enemiesAlive++;
                timeSinceLastSpawn = 0f;
            }
            
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            // ensure that the sprite animation is removed before i pause the game
            /*print("enemies alive = 0 and enemies left to spawn = 0");
            new WaitForSeconds(timeBetweenWaves);*/
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
            Debug.Log("Enemy destroyed");
            enemiesAlive--;
    }

    public IEnumerator StartWave()
    {
        Debug.Log("Wave Started!");
        yield return new WaitForSeconds(timeBetweenWaves);

        if (wavesCompleted >= totalWavesToWin)
        {
            WinGame(); //call win condition
            yield break; // exit method
        }
        else if (wavesCompleted == (totalWavesToWin - 1))
        {
            hasBossSpawned = true;
            isSpawning = true;
            enemiesLeftToSpawn = numberOfBossesInLastWave;
        }
        else 
        {
            isSpawning = true;
            enemiesLeftToSpawn = EnemiesPerWave();
            eps = EnemiesPerSecond();
        }

        
        
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        wavesCompleted++; // increase completed waves
        
    }
   

    public int GetCurrentWave()
    {
        return currentWave;
    }

    public void SetTotalWavesToWin(int level)
    {
        switch (level)
        {
            case 1:
                totalWavesToWin = 3;
                break;

            case 2:
                totalWavesToWin = 4;
                break;

            case 3:
                totalWavesToWin = 5;
                break;
            case 4:
                totalWavesToWin = 6;
                break;
            case 5:
                totalWavesToWin = 7;
                break;
            default:
                break;
        }

    }

    public int GetTotalWavesToWin()
    { 
        return totalWavesToWin; 
    }

    private void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[index];

        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    private void spawnBoss()
    {
        Instantiate(bossPrefab, LevelManager.main.startPoint.position, Quaternion.identity);
   
    }
    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies* Mathf.Pow(currentWave,difficultyScalingFactor));
    }

    private float EnemiesPerSecond()
    {
        return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(currentWave, difficultyScalingFactor),0f,enemiesPerSecondCap);
    }

    private void WinGame()
    {
        // display victory screen 
        VictoryMenu.isGameCompleted = true;
        Debug.Log("Congratulations! You've won the game!");
       
    }
}
