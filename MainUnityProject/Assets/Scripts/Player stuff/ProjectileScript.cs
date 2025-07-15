using System;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public WeaponType weaponType;
    public float projectileSpeed;
    public int attackDamage;
    public float attackSpeed;
    public float critDamageMult;
    public float critChance;
    public bool isCanonBall;
    public bool hasDeathTouch;
    public int killCounter;
    int maxKillsAllowed = 5; //is only set in code

    float deathTimer = 3f;

    public void GetStatsFromWeapon(Weapon weapon)
    {
        weaponType = weapon.weaponType;
        attackDamage = weapon.attackDamage;
        critDamageMult = weapon.critDamageMult;
        critChance = weapon.critChance;
        projectileSpeed = weapon.projectileSpeed;
    }

    public void KillSelf()
    {
        
        Destroy(this.gameObject);
    }


    void Update()
    {
        deathTimer -= Time.deltaTime;
        
        if (deathTimer <= 0)
        {
            KillSelf();
        }
    }

    public void AddKill()
    {
        
        killCounter++;

        if (killCounter >= maxKillsAllowed)
        {
            KillSelf();
        }
    }
}
