using System;
using System.Collections;
using UnityEngine;

public class WaveManagerScript : MonoBehaviour
{
    void Start()
    {
        //get the spawner script
        SpawnerScript = enemySpawner.GetComponent<EnemySpawnerScript>();
    }

    EnemySpawnerScript SpawnerScript;
    GameObject defaultEnemyPrefab;
    int currentDifficulty = 1;

    public DifficultySettings[] difficulties;
    //for internal use?
    [SerializeField] int currentWave;

    [SerializeField] GameObject enemySpawner;

    [ContextMenu("SpawnWave testing")]
    public void SpawnWave()
    {
        DifficultySettings difficulty = DifficultySelector();
        StartCoroutine(SpawningProcess(difficulty));
    }

    IEnumerator SpawningProcess(DifficultySettings difficulty)
    {
        int enemiesSpawned = 0;
        while (enemiesSpawned <= difficulty.amountOfEnemiesToSpawn )
        {
            if (difficulty.enemyPrefab != null)
            {
                SpawnerScript.SpawnEnemy(difficulty.enemyPrefab);    
            }
            else
            {
                SpawnerScript.SpawnEnemy(defaultEnemyPrefab);
            }

            enemiesSpawned++;
            print($"enemies spawned {enemiesSpawned}");
            print($"enemies to spawn {difficulty.amountOfEnemiesToSpawn}");
            yield return new WaitForSeconds(difficulty.spawnerCooldown);
            
        }
        print($"Spawning process done, spawned {enemiesSpawned} out of {difficulty.amountOfEnemiesToSpawn}");
    }
    

    public DifficultySettings DifficultySelector()
    {
        switch (currentDifficulty)
        {
            case 1 :
                return difficulties[0];
            case 2 :
                return difficulties[1];
            case 3 :
                return difficulties[2];
            case 4 :
                return difficulties[3];
            case 5 :
                return difficulties[4];
            default:
                return difficulties[0]; // should be changed to post-curated  endless run mode logic
        }
    }

    public void ChangeDifficulty()
    {
        currentDifficulty++;
    }
    public void ChangeDifficulty(int newValue)
    {
        currentDifficulty = newValue;
    }




}
