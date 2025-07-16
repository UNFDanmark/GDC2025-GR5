using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    Button button;
    public GameObject parentObject;
    public TextMeshProUGUI childText;
    public TextMeshProUGUI buttonText;
    public StatType sType;
    public WeaponType wType;
    public bool tabletButton;
    float deleteTimer = 1f;
    bool buttonPressed;

    void Start()
    {
        ChangeText();
        button = GetComponent<Button>();
        button.onClick.AddListener(MinFunktion);
    }


    void MinFunktion()
    {
        AudioManager.Instance.PlaySFX("Coin");
            GameManagerScript.Instance.UpgradeWeapon(wType, sType);
            ChangeText();
            if (tabletButton)
            {
                GameManagerScript.Instance.KillAllCards();    
            }
            
            

    }

    
    
    


    public void ChangeText()
    {
        switch (wType)
        {
            case WeaponType.Ballista:
            {
                if (sType == StatType.attackDamage)
                {
                    childText.text =  "Damage: " +  WeaponManagerScript.Instance.Ballista.GetComponent<Weapon>().attackDamage;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Ballista.GetComponent<Weapon>().atkDamageCost;
                }

                if (sType == StatType.attackSpeed)
                {
                    childText.text = "FireRate: " + WeaponManagerScript.Instance.Ballista.GetComponent<Weapon>().attackSpeed;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Ballista.GetComponent<Weapon>().atkSpeedCost;
                }

                if (sType == StatType.projectileSpeed)
                {
                    childText.text =  "Arrow Speed: " + WeaponManagerScript.Instance.Ballista.GetComponent<Weapon>().projectileSpeed;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Ballista.GetComponent<Weapon>().projectileSpeedCost;
                }

                if (sType == StatType.atkDmgMult)
                {
                    childText.text =  "Current Ballista DMG mult: " +  WeaponManagerScript.Instance.Ballista.GetComponent<Weapon>().atkDamageMult;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Ballista.GetComponent<Weapon>().atkDamageMultCost;
                }
                if (sType == StatType.atkSpeedMult)
                {
                    childText.text =  "Current Ballista FireRate mult: " +  WeaponManagerScript.Instance.Ballista.GetComponent<Weapon>().atkSpeedMult;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Ballista.GetComponent<Weapon>().atkSpeedMultCost;
                }
                if (sType == StatType.projectileSpeedMult)
                {
                    childText.text =  "Current Ballista projectile speed mult: " +  WeaponManagerScript.Instance.Ballista.GetComponent<Weapon>().projectileSpeedMult;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Ballista.GetComponent<Weapon>().projectileMultCost;
                }

                break;
            }
            case WeaponType.Canon:
            {
                if (sType == StatType.attackDamage)
                {
                    childText.text = "Damage: " + WeaponManagerScript.Instance.Canon.GetComponent<Weapon>().attackDamage;          
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Canon.GetComponent<Weapon>().atkDamageCost;
                }

                if (sType == StatType.attackSpeed)
                {
                    childText.text = "FireRate: " + WeaponManagerScript.Instance.Canon.GetComponent<Weapon>().attackSpeed;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Canon.GetComponent<Weapon>().atkSpeedCost;
                }

                if (sType == StatType.projectileSpeed)
                {
                    childText.text =  "Power: " + WeaponManagerScript.Instance.Canon.GetComponent<Weapon>().projectileSpeed;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Canon.GetComponent<Weapon>().projectileSpeedCost;
                }
                if (sType == StatType.atkDmgMult)
                {
                    childText.text =  "Current Cannon DMG mult: " +  WeaponManagerScript.Instance.Canon.GetComponent<Weapon>().atkDamageMult;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Canon.GetComponent<Weapon>().atkDamageMultCost;
                }
                if (sType == StatType.atkSpeedMult)
                {
                    childText.text =  "Current Cannon FireRate mult: " +  WeaponManagerScript.Instance.Canon.GetComponent<Weapon>().atkSpeedMult;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Canon.GetComponent<Weapon>().atkSpeedMultCost;
                }
                if (sType == StatType.projectileSpeedMult)
                {
                    childText.text =  "Current Cannon projectile speed mult: " +  WeaponManagerScript.Instance.Canon.GetComponent<Weapon>().projectileSpeedMult;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Canon.GetComponent<Weapon>().projectileMultCost;
                }

                break;
            }
            
            case WeaponType.Catapult:
            {
                if (sType == StatType.attackDamage)
                {
                    childText.text = "Damage: " + WeaponManagerScript.Instance.Catapult.GetComponent<Weapon>().attackDamage;         
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Catapult.GetComponent<Weapon>().atkDamageCost;
                }

                if (sType == StatType.attackSpeed)
                {
                    childText.text = "FireRate: " + WeaponManagerScript.Instance.Catapult.GetComponent<Weapon>().attackSpeed;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Catapult.GetComponent<Weapon>().atkSpeedCost;
                }

                if (sType == StatType.projectileSpeed)
                {
                    childText.text =  "Power: " + WeaponManagerScript.Instance.Catapult.GetComponent<Weapon>().projectileSpeed;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Catapult.GetComponent<Weapon>().projectileSpeedCost;
                }
                if (sType == StatType.atkDmgMult)
                {
                    childText.text =  "Current Catapult DMG mult: " +  WeaponManagerScript.Instance.Catapult.GetComponent<Weapon>().atkDamageMult;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Catapult.GetComponent<Weapon>().atkDamageMultCost;
                }
                if (sType == StatType.atkSpeedMult)
                {
                    childText.text =  "Current Catapult FireRate mult: " +  WeaponManagerScript.Instance.Catapult.GetComponent<Weapon>().atkSpeedMult;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Catapult.GetComponent<Weapon>().atkSpeedMultCost;
                }
                if (sType == StatType.projectileSpeedMult)
                {
                    childText.text =  "Current Catapult projectile speed mult: " +  WeaponManagerScript.Instance.Catapult.GetComponent<Weapon>().projectileSpeedMult;
                    buttonText.text = "Upgrade for: " + WeaponManagerScript.Instance.Catapult.GetComponent<Weapon>().projectileMultCost;
                }

                break;
            }
        }
    }
}
