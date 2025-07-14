using System;
using UnityEngine;


public enum GameState {Menu, Tutorial, Wave, TabletShop, GameOver}
public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;
    public GameState gameState;
    
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
    }


    void Update()
    {
        switch (gameState)
        {
            case GameState.Menu:
                break;
            case GameState.Tutorial:
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
}
