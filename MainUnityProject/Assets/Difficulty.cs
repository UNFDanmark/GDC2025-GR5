using UnityEngine;

public class Difficulty : MonoBehaviour{

[System.Serializable]
    enum difficulty {Tutorial = 1, Easy, Medium, Hard, Impossible, ImminentDeath}
    public Difficulty _difficulty;
    [SerializeField] int amountOfEnemiesToSpawn;
    [SerializeField] float waveTimeLength;
    [SerializeField] float spawnerCooldown;
    
    [SerializeField] GameObject enemyPrefab;
    
    
}
