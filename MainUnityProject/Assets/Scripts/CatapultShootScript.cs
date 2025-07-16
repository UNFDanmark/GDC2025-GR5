using System;
using UnityEngine;

public class CatapultShootScript : MonoBehaviour
{
    public GameObject stillRock;
    MeshRenderer stillRockRenderer;
    Animator animator;
    CatapultScript latestCatapultScript;
    public Transform basketPoint;
    Vector3 latestTargetPoint;
    public Transform catapult;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        stillRockRenderer = stillRock.GetComponent<MeshRenderer>();
    }

    public void PeakOfCanon()
    {
        print("pluh");
        disableRock();
        
         GameObject tempProjectile = Instantiate(latestCatapultScript.projectilePrefab, basketPoint.position, Quaternion.identity);
         //tempProjectile.transform.SetLocalPositionAndRotation(transform.position, Quaternion.LookRotation(targetDirection));
         tempProjectile.GetComponent<ProjectileScript>().GetStatsFromWeapon(latestCatapultScript);

         Vector3 newTargetVector = new Vector3(latestTargetPoint.x, 200, latestTargetPoint.z);
         Debug.DrawRay(basketPoint.position, newTargetVector - basketPoint.position, Color.red, 1); 
         
         tempProjectile.GetComponent<Rigidbody>().AddForce(newTargetVector * latestCatapultScript.projectileSpeed, ForceMode.Impulse );
         tempProjectile.GetComponent<ProjectileScript>().GetStatsFromWeapon(latestCatapultScript);
        
         
    }

    public void ShootCatapult(CatapultScript catapultScript, Vector3 targetPos)
    {
        Vector3 newTarget = new Vector3(targetPos.x, catapult.position.y, targetPos.z);
        
        
        Debug.DrawRay(catapult.position, newTarget - catapult.position, Color.blue, 1);
        catapult.LookAt(newTarget);
        //catapult.rotation = Quaternion.LookRotation(newTarget - catapult.position);
        
        latestCatapultScript = catapultScript;
        latestTargetPoint = targetPos;
        enableRock();
        animator.SetTrigger("FireCatapult");
        print("it works!!");
        latestCatapultScript.cooldownleft = latestCatapultScript.atkCooldown;
    }

    public void disableRock()
    {
        stillRockRenderer.enabled = false;
    }

    public void enableRock()
    {
        stillRockRenderer.enabled = true;
    }
    
}
