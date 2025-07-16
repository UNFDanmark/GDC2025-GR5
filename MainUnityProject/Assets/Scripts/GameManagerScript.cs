using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public enum GameState {Menu, Tutorial, SpawningWave, Wave, TabletShop, GameOver}
public class GameManagerScript : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject middlePoint;
    public GameObject rightPoint;
    
    public TabletCardScript[] tabletSettings;
    private Queue<GameObject> tabletCards;
    public GameObject tabletPrefab;
    public static GameManagerScript Instance;
    public GameState gameState;
    public int money; //can make float later, make upgrades for collecting money "money 25% increase" type 
    
    
    
    
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
        SetGameState(GameState.SpawningWave); // for testing
    }

    void Start()
    {
        tabletCards = new Queue<GameObject>();
        foreach (var tabletSetting in tabletSettings)
        {
            tabletCards.Enqueue(tabletPrefab);
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


    public void UpgradeWeapon(WeaponType wType, StatType sType)
    {
        switch (wType)
        {
            case WeaponType.Ballista:
                WeaponManagerScript.Instance.UpgradeBallista(sType, money);
                break;
            case WeaponType.Canon:
                WeaponManagerScript.Instance.UpgradeCanon(sType, money);
                break;
            case WeaponType.Catapult:
                WeaponManagerScript.Instance.UpgradeCatapult(sType, money);
                break;
        }
    }

    public void SpawnTablets()
    {
        GameObject TempCard = Instantiate(tabletCards.Dequeue(), leftPoint.transform);
        TempCard.GetComponentInChildren<ButtonScript>().sType = PickRandomStatType(); // change this

    }

    public StatType PickRandomStatType()
    {
        int randomInt = Random.Range(0, tabletCards.Count/3); // change this

        switch (randomInt)
        {
            case 1:
                return StatType.atkDmgMult;
            case 2:
                return StatType.atkSpeedMult;
            case 3:
                return StatType.projectileSpeedMult;
                
        }
    }


}
