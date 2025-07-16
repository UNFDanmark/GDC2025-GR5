using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Mover : MonoBehaviour
{
   
   public Vector3 target = new Vector3(0, 0, 0);
   public Rigidbody rb;
   public EnemyStats enemyStats;
   public float speed;

   void Start()
   {
      
      rb = GetComponent<Rigidbody>();
   }

   void FixedUpdate()
   {
      MoveTowards();
   }

   

   public void MoveTowards()
   {
      //calculate direction to target
      Vector3 direction = (target - transform.position);
      
      //move object towards target
      Vector3 newVelocity = rb.linearVelocity;
      newVelocity = (target - transform.position) * speed;
      rb.linearVelocity = newVelocity;
      transform.LookAt(newVelocity);
   }

   
}
