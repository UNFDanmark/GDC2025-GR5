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

    float deathTimer = 5f;

    public void GetStatsFromWeapon(Weapon weapon)
    {
        weaponType = weapon.weaponType;
        attackDamage = weapon.attackDamage;
        critDamageMult = weapon.critDamageMult;
        critChance = weapon.critChance;
    }

    public void KillSelf()
    {
        Destroy(this.gameObject);
    }


    void Update()
    {
        // deathTimer -= Time.deltaTime;
        //
        // if (deathTimer <= 0)
        // {
        //     KillSelf();
        // }
    }
}
