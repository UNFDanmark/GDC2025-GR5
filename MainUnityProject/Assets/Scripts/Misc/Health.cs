using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPoints;
    public int maxHealth;
    public float despawnTimer;


    
    

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
        //particle stuff here
        
        
        //check if this is tower or angels
        yield return new WaitForSeconds(despawnTimer); // maybe switch despawn timer for when particles are done playing
        Destroy(this.gameObject);
    }
    
    
    





}
