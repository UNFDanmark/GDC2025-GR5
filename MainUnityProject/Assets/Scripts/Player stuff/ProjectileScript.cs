using System;
using System.Collections;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    Rigidbody rb;
    public WeaponType weaponType;
    public float projectileSpeed;
    public int attackDamage;
    public float attackSpeed;
    public float critDamageMult;
    public float critChance;
    public bool isCanonBall;
    public bool isRock;
    public bool hasDeathTouch;
    public int killCounter;
    int maxKillsAllowed = 5; //is only set in code
    public float dragForce;
    public Vector3 growAmount;
    Vector3 startScale;
    float deathTimer = 3f;
    float rockDeathTimer = 10f;
    Vector3 lerpVector = new Vector3();
    float rockGrowTimer = 1f;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    
    }

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
        if (!isRock)
        {
            deathTimer -= Time.deltaTime;
        
            if (deathTimer <= 0)
            {
                KillSelf();
            }
            
        }

        if (isRock)
        {
            rockGrowTimer -= Time.deltaTime;
            if (rockGrowTimer >= 0)
            {
                GrowRock();    
            }
            
            rockDeathTimer -= Time.deltaTime;
            if (rockDeathTimer <= 0)
            {
                KillSelf();
            }
        }

        DragDown();
    }

    public void AddKill()
    {
        
        killCounter++;

        if (killCounter >= maxKillsAllowed)
        {
            KillSelf();
        }
    }

    bool isGrounded;
    Vector3 direction;
    public void DragDown()
    {
        if (isRock && !isGrounded)
        {
            rb.AddForce(Vector3.down * dragForce);
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            rb.linearDamping = 0;
           // rb.AddForce(vec);
            isGrounded = true;
            print("DONE");
            
        }
    }


    [ContextMenu("test GrowRock")]
    public void GrowRock()
    {
        
        
        transform.localScale += growAmount;


    }
}
