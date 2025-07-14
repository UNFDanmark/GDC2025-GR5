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
    

    void Start()
    {
        TargetPositions.Clear();
        fireAction.Enable();
       
    }

    void Update()
    {
        if (fireAction.IsPressed())
        {
            Ballista.GetComponent<BallistaScript>().ShootProjectile();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TargetPositions.Enqueue(other.gameObject.GetComponent<Transform>().position);
            
           // print($"enqueued an object, queue has {TargetPositions.Count} length");
        }
    }
}
