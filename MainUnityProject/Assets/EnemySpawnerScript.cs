using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] float outerRange;
    [SerializeField] float innerRange;
    [SerializeField] float height;
    public GameObject TestEnemy;


    void Update()
    {
        SpawnEnemy(TestEnemy);  
    }


    public GameObject SpawnEnemy(GameObject enemyPrefab)
    {
        return Instantiate(enemyPrefab, CalculateSpawnPosition(), Quaternion.identity);
    }

    public Vector3 CalculateSpawnPosition()
    {
        float x = Random.Range(innerRange, outerRange);
        float z = Random.Range(innerRange, outerRange);

        return new Vector3(x, height, z);
    } 









}
