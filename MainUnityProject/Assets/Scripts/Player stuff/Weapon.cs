using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]

public enum StatType {attackDamage, attackSpeed, critDamageMult, Critchance}
public enum WeaponType {Ballista, Canon, Catapult}

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;
    public GameObject projectilePrefab;
    public float projectileSpeed;
    public int attackDamage;
    public float attackSpeed;
    public float critDamageMult;
    public float critChance;
    
    //upgrade values
    [Header("Increase amounts for stats")]
    public int atkDamageIncreaseAmount;
    public float atkSpeedIncreaseAmount;
    public float critDamageMultIncreaseAmount;
    public float critChanceIncreaseAmount;
    

    //other variables and references
    float cooldownleft;
    [SerializeField]float atkCooldown;
    
    public void UpgradeStat(StatType statType)
    {
        switch (statType)
        {
            case StatType.attackDamage:
                attackDamage += atkDamageIncreaseAmount;
                break;
            case StatType.attackSpeed:
                attackSpeed += atkSpeedIncreaseAmount;
                break;
            case StatType.critDamageMult:
                critDamageMult += critDamageMultIncreaseAmount;
                break;
            case StatType.Critchance:
                critChance += critChanceIncreaseAmount;
                break;
            default:
                Debug.Log("No stat could be upgraded");
                break;

        }
    }
    [ContextMenu("FireBullet")]
    public void ShootProjectile(Vector3 targetDirection)
    {
        GameObject tempProjectile = Instantiate(projectilePrefab, transform);
       tempProjectile.GetComponent<ProjectileScript>().GetStatsFromWeapon(this);
        tempProjectile.GetComponent<Rigidbody>().AddForce(targetDirection * projectileSpeed, ForceMode.Impulse );
    }

    public bool canFire()
    {
        if (cooldownleft <= 0)
        {
            cooldownleft = atkCooldown;
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        cooldownleft -= Time.deltaTime;
    }
}
