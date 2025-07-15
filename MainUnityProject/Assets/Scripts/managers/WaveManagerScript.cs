using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerScript : MonoBehaviour
{
    public static WaveManagerScript Instance;
    public bool isSpawningWave = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public List<GameObject> enemyList;
    void Start()
    {
        //get the spawner script
        SpawnerScript = enemySpawner.GetComponent<EnemySpawnerScript>();
    }

    EnemySpawnerScript SpawnerScript;
    GameObject defaultEnemyPrefab;
    int currentDifficulty = 0;

    public DifficultySettings[] difficulties;
    //for internal use?
    [SerializeField] int currentWave;

    [SerializeField] GameObject enemySpawner;
    
    public void SpawnWave()
    {
        if (!isSpawningWave)
        {
            DifficultySettings difficulty = DifficultySelector();
            StartCoroutine(SpawningProcess(difficulty));
            isSpawningWave = true;    
        }
    }

    IEnumerator SpawningProcess(DifficultySettings difficulty)
    {
        int enemiesSpawned = 0;

        if (difficulty.useWaveTimer)
        {
            //calculate how many enemies to spawn pr second to be done when wavetimelength is done
            float localSpawnerCooldown = difficulty.waveTimeLength / difficulty.amountOfEnemiesToSpawn;
            
            while (enemiesSpawned <= difficulty.amountOfEnemiesToSpawn -1 )
            {
                if (difficulty.enemyPrefab != null)
                {
                    enemyList.Add(SpawnerScript.SpawnEnemy(difficulty.enemyPrefab));  
                }
                else
                {
                    enemyList.Add(SpawnerScript.SpawnEnemy(defaultEnemyPrefab));
                }

                enemiesSpawned++;
                // print($"enemies spawned {enemiesSpawned}");
                // print($"enemies to spawn {difficulty.amountOfEnemiesToSpawn}");
                yield return new WaitForSeconds(localSpawnerCooldown);
            }    
            
        }
        else
        {
            while (enemiesSpawned <= difficulty.amountOfEnemiesToSpawn -1 )
            {
                if (difficulty.enemyPrefab != null)
                {
                    enemyList.Add(SpawnerScript.SpawnEnemy(difficulty.enemyPrefab));  
                }
                else
                {
                    enemyList.Add(SpawnerScript.SpawnEnemy(defaultEnemyPrefab));
                }

                enemiesSpawned++;
                // print($"enemies spawned {enemiesSpawned}");
                // print($"enemies to spawn {difficulty.amountOfEnemiesToSpawn}");
                yield return new WaitForSeconds(difficulty.spawnerCooldown);
            
            }    
        }
        print($"Spawning process done, spawned {enemiesSpawned} out of {difficulty.amountOfEnemiesToSpawn} enemies");
        ChangeDifficulty();
        GameManagerScript.Instance.SetGameState(GameState.Wave);
        isSpawningWave = false;
        
    }
    

    public DifficultySettings DifficultySelector()
    {
        if (currentDifficulty >= difficulties.Length)
        {
            return difficulties[0];
        }
        else
        {
            return difficulties[currentDifficulty];
        }
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        enemyList.Remove(enemy);
    }

    public void ChangeDifficulty()
    {
        print($"Increasing difficulty from {currentDifficulty} to {currentDifficulty +1}");
        currentDifficulty++;
    }
    public void ChangeDifficulty(int newValue)
    {
        print($"Increasing difficulty from {currentDifficulty} to {newValue} ");        
        currentDifficulty = newValue;
    }

    void Update()
    {
        WaveEndCheck();
    }

    public void WaveEndCheck()
    {
        if (GameManagerScript.Instance.gameState == GameState.Wave && enemyList.Count == 0)
        {
            GameManagerScript.Instance.SetGameState(GameState.TabletShop);
        }
    }




}
