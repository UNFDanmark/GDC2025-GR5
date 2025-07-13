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
        isDead = true;
        FindSelfInArray();
        
        //particle stuff here
        
        
        //check if this is tower or angels
        yield return new WaitForSeconds(despawnTimer); // maybe switch despawn timer for when particles are done playing
        Destroy(this.gameObject);
    }

    public void FindSelfInArray()
    {
        int index = 0;
        foreach (var angel in WaveManagerScript.Instance.enemyList)
        {
            if (this.gameObject == angel)
            {
                
                break;
            }

            index++;
        }
        WaveManagerScript.Instance.RemoveEnemyFromList(index);
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
