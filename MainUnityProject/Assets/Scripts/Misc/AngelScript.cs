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

    

    void Start()
    {
        
        FetchInfo();
        Agent.SetDestination(Target.transform.position);
    }
    

    private void FetchInfo()
    {
        Agent = GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Tower");
    }
    

    public void TakeDamage(int damageToTake)
    {
        healthPoints = healthPoints - damageToTake;
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
        
        
        //check if this is tower or angels
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
        if (other.gameObject.CompareTag("Projectile"))
        {
            ProjectileScript projectileScript = other.gameObject.GetComponent<ProjectileScript>();
            TakeDamage(projectileScript.attackDamage);
            projectileScript.KillSelf();
        }
    }
}
