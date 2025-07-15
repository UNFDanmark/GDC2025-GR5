using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AngelScript : MonoBehaviour
{
    public NavMeshAgent Agent;
    public GameObject Target;
    public bool isDead;
    
    public int healthPoints;
    public int maxHealth;
    public float despawnTimer;
    public int damage;
    public int moneyDrop;

    

    void Start()
    {
        healthPoints = maxHealth;
        FetchInfo();
        
    }
    

    private void FetchInfo()
    {
        
        Target = GameObject.FindGameObjectWithTag("Tower");
    }
    

    public void TakeDamage(int damageToTake)
    {
        healthPoints -= damageToTake;
        print($"damage is {damageToTake}");
        if (healthPoints <= 0)
        {
            isDead = true;
            StartCoroutine(StartDeathProcess());
        }
    }

    public  void Heal(int amountToHeal)
    {
        if (healthPoints <= 0)
        {
            return;
        } else if (amountToHeal + healthPoints > maxHealth)
        {
            healthPoints = maxHealth;
        }
        else
        {
            healthPoints += amountToHeal;
        }
    }

    IEnumerator StartDeathProcess()
    {
        
        FindSelfInArray();
        
        //particle stuff here
        
        
       GameManagerScript.Instance.IncreaseMoneyAmount(moneyDrop);
        yield return new WaitForSeconds(despawnTimer); // maybe switch despawn timer for when particles are done playing
        Destroy(this.gameObject);
    }

    public void FindSelfInArray()
    {
        foreach (var angel in WaveManagerScript.Instance.enemyList)
        {
            
            if (gameObject.GetInstanceID() == angel.GetInstanceID())
            {
                print($"instance id of self is {gameObject.GetInstanceID()} comparison to {angel.GetInstanceID()}");
                WaveManagerScript.Instance.RemoveEnemyFromList(angel);
                break;
            }

        }
        
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            ProjectileScript projectileScript = other.gameObject.GetComponent<ProjectileScript>();
            TakeDamage(projectileScript.attackDamage);
            projectileScript.KillSelf();
        } else if (other.gameObject.CompareTag("CanonBall"))
        {
            ProjectileScript projectileScript = other.gameObject.GetComponent<ProjectileScript>();
            TakeDamage(projectileScript.attackDamage);
            projectileScript.AddKill(); //also kills canonball if above threshold of kills
           
        } else if (other.gameObject.CompareTag("Rock"))
        {
            ProjectileScript projectileScript = other.gameObject.GetComponent<ProjectileScript>();
            TakeDamage(projectileScript.attackDamage);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            print("killed by tower");
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            StartCoroutine(StartDeathProcess());
        }
    }
}
