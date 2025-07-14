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
    Queue<Vector3> TargetQueue = new Queue<Vector3>();
    
    
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
    public void ShootProjectile()
    {
        GameObject tempProjectile = Instantiate(projectilePrefab, transform);
       
        tempProjectile.GetComponent<Rigidbody>().AddForce(FindTargetBetter() * projectileSpeed, ForceMode.Impulse );
    }

    //this is the old targeting system, keep for early game use
    public Vector3 FindTarget()
    {
        //get first enemy in list, its probably the closest to the tower
        if ( WaveManagerScript.Instance.enemyList.Count != 0)
        {
            Vector3 TargetPosition = WaveManagerScript.Instance.enemyList[0].transform.position;
            //calc direction
            Vector3 TargetDirection = TargetPosition - transform.position;
            return TargetDirection;    
        }
        return Vector3.up; //idk man i would rather return nothing here ??
    }

    public Vector3 FindTargetBetter()
    {
        //get first enemy in list, its probably the closest to the tower
        if (TargetQueue.Count != 0)
        {

            Vector3 TargetDirection = TargetQueue.Dequeue() - transform.position;
            return TargetDirection;    
        }
        return Vector3.up; //idk man i would rather return nothing here ??
    }
    

    IEnumerator UpdateTargetQueue()
    {
        //having this in each weapon instance is redundant ? could have it at one shared spot    
        //cache a copy of enemylist, then work on it
        List<GameObject> copyOfEnemyList = new List<GameObject>(WaveManagerScript.Instance.enemyList);
        
        foreach (var angel in copyOfEnemyList)
        {
            if (angel != null)
            {
                TargetQueue.Enqueue(angel.transform.position);
                print($"added {angel.transform.position}");
            }
            
            yield return null;
            
        }
        //calls itself when its done, should probably change this
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(UpdateTargetQueue());
        
    }
    
    IEnumerator _UpdateTargetQueue()
    {
        //having this in each weapon instance is redundant ? could have it at one shared spot    
        //cache a copy of enemylist, then work on it
        List<GameObject> copyOfEnemyList = new List<GameObject>(WaveManagerScript.Instance.enemyList);
        
        foreach (var angel in copyOfEnemyList)
        {
            TargetQueue.Enqueue(angel.transform.position);
            yield return null;
            print($"added {angel.transform.position}");
        }
        //calls itself when its done, should probably change this
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(UpdateTargetQueue());
        
    }
    
    

    void Start()
    {
        StartCoroutine(UpdateTargetQueue());
    }
}
