using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPoints;



    public void TakeDamage(int damageToTake)
    {
        healthPoints = healthPoints - damageToTake;
        if (healthPoints <= 0)
        {
            // death code?
        }
    }
    
    





}
