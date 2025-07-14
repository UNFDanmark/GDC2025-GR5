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

    

    void Start()
    {
        fireAction.Enable();
       
    }

    void Update()
    {
        if (fireAction.IsPressed())
        {
            Ballista.GetComponent<BallistaScript>().ShootProjectile();
        }
    }
    
    
    
    
    
    
}
