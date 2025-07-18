using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public enum GameState {Menu, Tutorial, SpawningWave, Wave, TabletShop, GameOver}
public class GameManagerScript : MonoBehaviour
{
    public Health healthScript;
    public Button pauseButton;
    public GameObject block;
    public GameObject GameOverScreen;
    
    
    public GameObject leftPoint;
    public GameObject middlePoint;
    public GameObject rightPoint;

    public GameObject leftCard;
    public GameObject middleCard;
    public GameObject rightCard;

    bool tabletSpawned;
    
    
    int randomInt;
    
    public TabletCardScript[] tabletSettings;
    private Queue<GameObject> tabletCards;
    public GameObject tabletPrefab;
    public static GameManagerScript Instance;
    public GameState gameState;
    public int money; //can make float later, make upgrades for collecting money "money 25% increase" type 



    public GameObject MoneyUI;
    public GameObject AngelsLeftUI;
    public GameObject HP;

    TextMeshProUGUI moneyText, hpText, angelsLeftText;

    public void UpdateTextUI()
    {
        moneyText.text = $"{money}";
        hpText.text = $"{healthScript.healthPoints}";
        angelsLeftText.text = $"{WaveManagerScript.Instance.enemyList.Count}";

    }
    
    
    
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
        SetGameState(GameState.Menu); // for testing
    }

    void Start()
    {
        angelsLeftText = AngelsLeftUI.GetComponentInChildren<TextMeshProUGUI>();
        hpText = HP.GetComponentInChildren<TextMeshProUGUI>();
        moneyText = MoneyUI.GetComponentInChildren<TextMeshProUGUI>();
        tabletCards = new Queue<GameObject>();
       
       
    }

    public bool isPlayingMusic;
    public bool isPlayingThemeMusic;
    void Update()
    {
        
        
        
        UpdateTextUI();    
        switch (gameState)
        {
            case GameState.Menu:
                isPlayingThemeMusic = false;
                if (!isPlayingMusic)
                {
                    AudioManager.Instance.PlayMusic("MainMenu");
                    isPlayingMusic = true;
                }
                
                block.SetActive(true);
                GameOverScreen.SetActive(false);
                Time.timeScale = 0f;
                break;
            case GameState.Tutorial:
                break;
            case GameState.SpawningWave:
                isPlayingMusic = false;
                if (!isPlayingThemeMusic)
                {
                    AudioManager.Instance.PlayMusic("Theme");
                    isPlayingThemeMusic = true;
                }
                Time.timeScale = 1f;
                WaveManagerScript.Instance.SpawnWave();
                tabletSpawned = false;
                break;
            case GameState.Wave:
                break;
            case GameState.TabletShop:
                
              //  Time.timeScale = 0f;
                SpawnTablets();
                tabletSpawned = true;
                break;
            case GameState.GameOver:
                Time.timeScale = 0f;
                GameOverScreen.SetActive(true);
                
                break;
            default: Debug.LogWarning("this is not supposed to happen");
                break;
        }
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
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
        tabletCards.Clear();
        foreach (var tabletSetting in tabletSettings)
        {
            tabletCards.Enqueue(tabletPrefab);
        }
        if (!tabletSpawned)
        {
            leftCard = Instantiate(tabletCards.Dequeue(), leftPoint.transform);
            leftCard.GetComponentInChildren<ButtonScript>().sType = PickRandomStatType(); // change this
            leftCard.GetComponentInChildren<ButtonScript>().wType = PickRandomWeaponType();
        
            middleCard = Instantiate(tabletCards.Dequeue(), middlePoint.transform);
            middleCard.GetComponentInChildren<ButtonScript>().sType = PickRandomStatType(); // change this
            middleCard.GetComponentInChildren<ButtonScript>().wType = PickRandomWeaponType();
        
            rightCard = Instantiate(tabletCards.Dequeue(), rightPoint.transform);
            rightCard.GetComponentInChildren<ButtonScript>().sType = PickRandomStatType(); // change this
            rightCard.GetComponentInChildren<ButtonScript>().wType = PickRandomWeaponType();    
        }
    }
    public void KillAllCards()
    {
        DestroyImmediate(leftCard);
        Destroy(middleCard);
        Destroy(rightCard);
        
        SetGameState(GameState.SpawningWave); //might be wrong state
    }

    public StatType PickRandomStatType()
    {
        randomInt = Random.Range(0, 3); 

        switch (randomInt)
        {
            case 1:
                return StatType.atkDmgMult;
            case 2:
                return StatType.atkSpeedMult;
            case 3:
                return StatType.projectileSpeedMult;
                
        }

        return StatType.atkDmgMult; // temp CHANGE THIS
    }

    public WeaponType PickRandomWeaponType()
    {
        randomInt = Random.Range(0, 3); 

        switch (randomInt)
        {
            case 1:
                return WeaponType.Ballista;
            case 2:
                return WeaponType.Canon;
            case 3:
                return WeaponType.Catapult;
                
        }

        return WeaponType.Ballista;
    }


}
