using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]

public enum StatType {attackDamage, attackSpeed, critDamageMult, Critchance}
public enum WeaponType {Ballista, Canon, Catapult}

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;
    public GameObject ProjectilePrefab;
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

    public void ShootProjectile()
    {
        GameObject tempProjectile = Instantiate(ProjectilePrefab, transform);
       
        tempProjectile.GetComponent<Rigidbody>().AddForce(FindTarget() * projectileSpeed, ForceMode.Impulse );
    }

    [ContextMenu("findtargetTest")]
    public Vector3 FindTarget()
    {
        //get first enemy in list, its probably the closest to the tower
        Vector3 TargetPosition = WaveManagerScript.Instance.enemyList[0].transform.position;
        //calc direction
        Vector3 TargetDirection = TargetPosition - transform.position;
        return TargetDirection;
    }
    
    
}
