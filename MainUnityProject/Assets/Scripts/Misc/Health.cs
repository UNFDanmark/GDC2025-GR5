using System;
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
       print("GAME OVER");
        
        
        GameManagerScript.Instance.SetGameState(GameState.GameOver);
        yield return new WaitForSeconds(despawnTimer); // maybe switch despawn timer for when particles are done playing
        
    }

    
}
