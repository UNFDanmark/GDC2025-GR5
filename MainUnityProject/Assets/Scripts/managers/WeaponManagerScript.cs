using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManagerScript : MonoBehaviour
{
    public InputAction fireAction;
    
    public GameObject Ballista;
    public GameObject Canon;
    public GameObject Catapult;

    public Queue<Vector3> TargetPositions = new Queue<Vector3>();
    public List<Vector3> TargetPos = new List<Vector3>(); // make this into a queue
    public float TargetUpdateTimer = 0.5f;
    float TargetTimerLeft;

    void Start()
    {
        TargetPositions.Clear();
        TargetPos.Clear();
        fireAction.Enable();
       
    }

    void Update()
    {
        TargetTimerLeft -= Time.deltaTime;

        if (TargetTimerLeft <= 0)
        {
            print("timer went off");
           FillTargetPosList();
           Ballista.GetComponent<BallistaScript>().ShootProjectile(FindTargetBetterBetter());
            
            TargetTimerLeft = TargetUpdateTimer;
        }
        
        
        if (fireAction.IsPressed())
        {
            
            
           
        }
        
        
        
        
        
        
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           // TargetPositions.Enqueue(other.gameObject.GetComponent<Transform>().position);
            
         //   print($"enqueued an object, queue has {TargetPositions.Count} length");
        }
    }
    public Vector3 FindTargetBetterBetter()
    {
        //get first enemy in list, its probably the closest to the tower
        if (WaveManagerScript.Instance.enemyList.Count != 0)
        {

            Vector3 TargetDirection = TargetPositions.Dequeue() - Ballista.transform.position;
           print($"target direction length is {TargetDirection.magnitude}");
            return TargetDirection;    
        }
        return Vector3.up; //idk man i would rather return nothing here ??
    }

    public Vector3 FindClosestTarget()
    {
        
        Vector3 closestVector = new Vector3(1000, 1000, 1000);
        foreach (var angel in WaveManagerScript.Instance.enemyList)
        {
            if (angel != null)
            {
                if (angel.transform.position.magnitude < closestVector.magnitude)
                {
                    closestVector = angel.transform.position;
                    Debug.DrawRay(this.transform.position, closestVector, Color.red);
                    print(closestVector);
                }
            }
        }
        
        

        return closestVector;
    }

    public void FillTargetPosList()
    {
        TargetPos.Clear();
        foreach (var angel in WaveManagerScript.Instance.enemyList)
        {
            if (angel != null)
            {
                TargetPos.Add(angel.transform.position);    
            }
            
        }
        
        TargetPos.Sort(new MagnitudeComparison());

        foreach (var pos in TargetPos)
        {
            TargetPositions.Enqueue(pos);
            print(pos.magnitude);
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