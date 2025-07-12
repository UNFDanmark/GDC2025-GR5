using UnityEngine;
[System.Serializable]
public class DifficultySettings
{

    [SerializeField] public string difficultyName;
    // public enum difficulty
    // {
    //     Tutorial = 1, Easy, Medium, Hard, Impossible, ImminentDeath
    // }

    
    //[SerializeField]  difficulty _difficulty;
    [SerializeField] public int amountOfEnemiesToSpawn;
    [SerializeField] public float waveTimeLength;
    [SerializeField] public float spawnerCooldown;
    
    [SerializeField] public GameObject enemyPrefab;
    
    
}
