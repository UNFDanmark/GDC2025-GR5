using UnityEngine;
[System.Serializable]
public class Difficulty{


    public enum difficulty
    {
        Tutorial = 1, Easy, Medium, Hard, Impossible, ImminentDeath
    }
    [SerializeField]  difficulty _difficulty;
    [SerializeField] int amountOfEnemiesToSpawn;
    [SerializeField] float waveTimeLength;
    [SerializeField] float spawnerCooldown;
    
    [SerializeField] GameObject enemyPrefab;
    
    
}
