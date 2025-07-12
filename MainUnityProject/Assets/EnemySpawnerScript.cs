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

        //generates polar coordinate from range
        float vectorLength = Random.Range(innerRange, outerRange);
        float vectorAngle = Random.Range(0f, 360f);
        
        //convert polar to kartesisk

        float x = vectorLength * Mathf.Cos(vectorAngle);
        float z = vectorLength * Mathf.Sin(vectorAngle);

        return new Vector3(x, height, z);





    } 









}
