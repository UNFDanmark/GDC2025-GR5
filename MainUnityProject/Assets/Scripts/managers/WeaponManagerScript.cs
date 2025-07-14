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

    public Queue<Vector3> TargetPositions = new Queue<Vector3>();
    public List<Vector3> TargetPos = new List<Vector3>(); // make this into a queue
    public float TargetUpdateTimer = 0.5f;
    float TargetTimerLeft;

    BallistaScript ballistaScript;
    //make the other scripts here

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
        if (ballistaScript.canFire())
        {
            print("hiii");
            ballistaScript.ShootProjectile(FindTargetBetterBetter());    
        }
        
        
    }

    public void FetchInfo()
    {
       ballistaScript = Ballista.GetComponent<BallistaScript>();
    }

    public Vector3 FindTargetBetterBetter()
    {
        //get first enemy in list, its probably the closest to the tower
        if (WaveManagerScript.Instance.enemyList.Count != 0)
        {
            Vector3 TargetDirection = TargetPositions.Dequeue() - Ballista.transform.position;
           print($"target direction length is {TargetDirection.magnitude}");
           Debug.DrawRay(Ballista.transform.position, TargetDirection, Color.blue);
            return TargetDirection;    
        }
        return Vector3.up; //idk man i would rather return nothing here ??
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
            print($"target position is {pos}");
        }
    }
    
    
}

public class MagnitudeComparison : IComparer<Vector3>
{
    public int Compare(Vector3 x, Vector3 y)
    {
        return x.magnitude.CompareTo(y.magnitude);
    }
}