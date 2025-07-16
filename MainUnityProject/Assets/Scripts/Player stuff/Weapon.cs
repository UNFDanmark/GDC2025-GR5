using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]

public enum StatType {attackDamage, attackSpeed, projectileSpeed, atkDmgMult, atkSpeedMult, projectileSpeedMult}
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

    [Range(1, float.MaxValue)] public float atkDamageMult;
     public float atkSpeedMult;
     public float projectileSpeedMult;
    
    //upgrade values
    [Header("Increase amounts for stats")]
    public int atkDamageIncreaseAmount;
    public float atkSpeedIncreaseAmount;
    public float projectileSpeedIncreaseAmount;
    [Header("increase Amount for mult stats")]
    public float atkDamageMultIncrease; 
    public float atkSpeedMultIncrease;
    public float projectileMultIncrease;
    [Header("Upgrade cost")]
    public int atkDamageCost;
    public int atkSpeedCost;
    public int projectileSpeedCost;
    [Header("Upgrade Cost Increase")]
    public int atkDamageCostIncrease;
    public int atkSpeedCostIncrease;
    public int projectileSpeedCostIncrease;
    [Header("Multiplier cost")]
    public int atkDamageMultCost;
    public int atkSpeedMultCost;
    public int projectileMultCost;
    [Header("Multiplier cost increase")]
    
    [Header("other stuff")]
    //other variables and references
    public float cooldownleft;
    public float atkCooldown;
    
    public void UpgradeStat(StatType statType, int currentMoney)
    {
        switch (statType)
        {
            case StatType.attackDamage:
                if (CheckMoney(currentMoney, atkDamageCost))
                {
                    attackDamage += atkDamageIncreaseAmount;
                    IncreaseCostForUpgrade(statType);
                    GameManagerScript.Instance.DecreaseMoneyAmount(atkDamageCost);
                }
                break;
            case StatType.attackSpeed:
                if (CheckMoney(currentMoney, atkSpeedCost))
                {
                    attackSpeed += atkSpeedIncreaseAmount;
                    atkCooldown = atkCooldown / attackSpeed;
                    GameManagerScript.Instance.DecreaseMoneyAmount(atkSpeedCost);
                    IncreaseCostForUpgrade(statType);
                }
                break;
            case StatType.projectileSpeed:
                if (CheckMoney(currentMoney, projectileSpeedCost))
                {
                    projectileSpeed += projectileSpeedIncreaseAmount;
                    GameManagerScript.Instance.DecreaseMoneyAmount(projectileSpeedCost);
                    IncreaseCostForUpgrade(statType);
                }
                break;
            case StatType.atkDmgMult:
                if (CheckMoney(currentMoney, atkDamageMultCost))
                {
                    atkDamageMult += atkDamageMultIncrease;
                    GameManagerScript.Instance.DecreaseMoneyAmount(atkDamageMultCost);
                  //  IncreaseCostForUpgrade(statType);
                }
                break;
            case StatType.atkSpeedMult:
                if (CheckMoney(currentMoney, atkSpeedMultCost))
                {
                    atkSpeedMult += atkSpeedMultIncrease;
                    GameManagerScript.Instance.DecreaseMoneyAmount(atkDamageMultCost);
                    //  IncreaseCostForUpgrade(statType);
                }
                break;
            case StatType.projectileSpeedMult:
                if (CheckMoney(currentMoney, projectileMultCost))
                {
                    projectileSpeedMult += projectileMultIncrease;
                    GameManagerScript.Instance.DecreaseMoneyAmount(projectileMultCost);
                    //  IncreaseCostForUpgrade(statType);
                }
                break;
            default:
                Debug.Log("No stat could be upgraded");
                break;
        
        }
        
    }
    [ContextMenu("FireBullet")]
    public void ShootProjectile(Vector3 targetDirection)
    {
        
        
        AudioManager.Instance.PlaySFX("");
        
        GameObject tempProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.LookRotation(targetDirection));
        //tempProjectile.transform.SetLocalPositionAndRotation(transform.position, Quaternion.LookRotation(targetDirection));
       tempProjectile.GetComponent<ProjectileScript>().GetStatsFromWeapon(this);
        tempProjectile.GetComponent<Rigidbody>().AddForce(targetDirection * projectileSpeed, ForceMode.Impulse );
        cooldownleft = atkCooldown;
    }

    public bool canFire()
    {
        if (cooldownleft <= 0)
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }

    public void IncreaseCostForUpgrade(StatType sType)
    {
        switch (sType)
        {
            case StatType.attackDamage:
                atkDamageCost += atkDamageCostIncrease;
                break;
            case StatType.attackSpeed:
                atkSpeedCost += atkSpeedCostIncrease;
                break;
            case StatType.projectileSpeed:
                projectileSpeedCost += projectileSpeedCostIncrease;
                break;
            default:
                Debug.Log("No stat upgrade cost could be increased");
                break;
        }
    }

    public bool CheckMoney(int currentMoney, int upgradeCost)
    {
        if (currentMoney >= upgradeCost)
        {
            return true;
        }

        return false;
    }
    void Update()
    {
        cooldownleft -= Time.deltaTime;
    }

}
