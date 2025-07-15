using System;
using UnityEngine;


public enum GameState {Menu, Tutorial, SpawningWave, Wave, TabletShop, GameOver}
public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;
    public GameState gameState;
    public int money; //can make float later, make upgrades for collecting money "money 25% increase" type shit
    
    void Awake()
    {
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        SetGameState(GameState.SpawningWave);
    }


    void Update()
    {
        switch (gameState)
        {
            case GameState.Menu:
                break;
            case GameState.Tutorial:
                break;
            case GameState.SpawningWave:
                WaveManagerScript.Instance.SpawnWave();
                break;
            case GameState.Wave:
                break;
            case GameState.TabletShop:
                break;
            case GameState.GameOver: 
                break;
            default: Debug.LogWarning("this is not supposed to happen");
                break;
        }
    }

    public void SetGameState(GameState state)
    {
        gameState = state;
    }

    public void IncreaseMoneyAmount(int amount)
    {
        money += amount;
    }

    public void DecreaseMoneyAmount(int amount)
    {
        if (money - amount < 0)
        {
            print($"cannot decrease {amount} from {money}");
        }
        else
        {
            money -= amount;
        }
    }
    
    // buttons and UI ----------------------------------------------------------------------------





}
