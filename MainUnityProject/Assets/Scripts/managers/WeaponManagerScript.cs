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
    public List<Vector3> TargetPos = new List<Vector3>();

    void Start()
    {
        TargetPositions.Clear();
        TargetPos.Clear();
        fireAction.Enable();
       
    }

    void Update()
    {
        if (fireAction.IsPressed())
        {
            Ballista.GetComponent<BallistaScript>().ShootProjectile(FindTargetBetterBetter());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TargetPositions.Enqueue(other.gameObject.GetComponent<Transform>().position);
            
            print($"enqueued an object, queue has {TargetPositions.Count} length");
        }
    }
    public Vector3 FindTargetBetterBetter()
    {
        //get first enemy in list, its probably the closest to the tower
        if (TargetPositions.Count != 0)
        {

            Vector3 TargetDirection = TargetPositions.Dequeue() - transform.position;
            return TargetDirection;    
        }
        return Vector3.up; //idk man i would rather return nothing here ??
    }
    
    
}
