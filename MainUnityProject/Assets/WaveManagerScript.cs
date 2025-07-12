using UnityEngine;

public class WaveManagerScript : MonoBehaviour
{
    enum Difficulty {Tutorial = 1, Easy, Medium, Hard, Impossible, ImminentDeath}
    
    [SerializeField] int currentWave;

    [SerializeField] GameObject angelPrefab;
    [SerializeField] GameObject enemySpawner;
    
    [SerializeField] int amountOfEnemiesToSpawn;
    [SerializeField] float waveTimeLength;
    [SerializeField] float spawnerCooldown;
    [SerializeField] Difficulty difficulty;
    
    
        
    
    
    
    
    public GameObject EnemySpawnerObj;


    public void SpawnWave()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                enemySpawner.GetComponent<EnemySpawnerScript>().SpawnEnemy(angelPrefab);
                break;
                
        }
    }


    public void SpawnerLogic(int amountOfEnemiesToSpawn, float spawnerCooldown)
    {
        
    }




}
