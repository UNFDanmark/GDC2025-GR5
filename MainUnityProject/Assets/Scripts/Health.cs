using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPoints;
    public float despawnTimer;



    public void TakeDamage(int damageToTake)
    {
        healthPoints = healthPoints - damageToTake;
        if (healthPoints <= 0)
        {
            StartCoroutine(StartDeathProcess());
        }
    }

    IEnumerator StartDeathProcess()
    {
        //particle stuff here
        
        yield return new WaitForSeconds(despawnTimer); // maybe switch despawn timer for when particles are done playing
        Destroy(this.gameObject);
    }
    
    
    





}
