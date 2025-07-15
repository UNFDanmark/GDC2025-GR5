using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManagerScript : MonoBehaviour
{
    
    
    //weapon objects
    public GameObject Ballista;
    public GameObject Canon;
    public GameObject Catapult;
    //target related variables
    public Queue<Vector3> TargetPositions = new Queue<Vector3>();
    public List<Vector3> TargetPos = new List<Vector3>(); // make this into a queue
    public float TargetUpdateTimer = 0.5f;
    float TargetTimerLeft;
    //Weapon scripts
    BallistaScript ballistaScript;
    CanonScript canonScript;
    CatapultScript catapultScript;


    public static WeaponManagerScript Instance;

    void Awake()
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
    
    
    void Start()
    {
        FetchInfo();
        TargetPositions.Clear();
        TargetPos.Clear();
    }

    void Update()
    {
        TargetTimerLeft -= Time.deltaTime;
        if (TargetTimerLeft <= 0)
        {
           FillTargetPosList();
           
           TargetTimerLeft = TargetUpdateTimer;
        }
        FireWeapons();
    }

    public void FireWeapons()
    {
        Vector3 Target = FindTargetBallista();
        //vector3.up is the value returned if there is no targets
        if (ballistaScript.canFire() && Target != Vector3.up)
        {
            ballistaScript.ShootProjectile(Target);    
        }

        Target = FindTargetCanon();
        if (canonScript.canFire() && Target != Vector3.up)
        {
            canonScript.ShootProjectile(Target);
        }
    }

    public void FetchInfo()
    {
       ballistaScript = Ballista.GetComponent<BallistaScript>();
       catapultScript = Catapult.GetComponent<CatapultScript>();
       canonScript = Canon.GetComponent<CanonScript>();
    }

    public Vector3 FindTargetBallista()
    {
        //get first enemy in list, its probably the closest to the tower
        if (WaveManagerScript.Instance.enemyList.Count != 0)
        {
            if (TargetPositions.TryDequeue(out Vector3 targetPos))
            {
                Vector3 TargetDirection = targetPos  - Ballista.transform.position;
                //for debuggin --- Debug.DrawRay(Ballista.transform.position, TargetDirection, Color.blue);
                return TargetDirection;    
                
            }
        }
        return Vector3.up; //idk man i would rather return nothing here ??
    }

    public Vector3 FindTargetCanon()
    {
        if (TargetPositions.TryDequeue(out Vector3 targetPos))
        {
            Vector3 TargetDirection = targetPos  - Canon.transform.position;
            //for debuggin --- Debug.DrawRay(Ballista.transform.position, TargetDirection, Color.blue);
            return TargetDirection;
        }
        
        return Vector3.up;
       
    }
    public void FillTargetPosList()
    {
        TargetPositions.Clear();
        TargetPos.Clear();
        foreach (var angel in WaveManagerScript.Instance.enemyList)
        {
            if (angel != null) TargetPos.Add(angel.transform.position);
        }
        
        TargetPos.Sort(new MagnitudeComparison());
        foreach (var pos in TargetPos)
        {
            TargetPositions.Enqueue(pos);
        }
    }
    
    
    // upgrade weapons

    public void UpgradeBallista(StatType stat, int _currentMoney)
    {
        
        ballistaScript.UpgradeStat(stat, _currentMoney);
    }
    public void UpgradeCanon(StatType stat, int _currentMoney)
    {
        canonScript.UpgradeStat(stat, _currentMoney);
    }
    public void UpgradeCatapult(StatType stat, int _currentMoney)
    {
        catapultScript.UpgradeStat(stat, _currentMoney);
    }

    
    
}

public class MagnitudeComparison : IComparer<Vector3>
{
    public int Compare(Vector3 x, Vector3 y)
    {
        return x.magnitude.CompareTo(y.magnitude);
    }
}