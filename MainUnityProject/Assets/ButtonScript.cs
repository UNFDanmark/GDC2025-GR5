using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    Button button;
    public TextMeshProUGUI childText;
    public TextMeshProUGUI buttonText;
    public StatType sType;
    public WeaponType wType;

    void Start()
    {
        ChangeText();
        button = GetComponent<Button>();
        button.onClick.AddListener(MinFunktion);
    }

    void Update()
    {
        
    }

    void MinFunktion()
    {
        GameManagerScript.Instance.UpgradeWeapon(wType, sType);
        ChangeText();
    }


    public void ChangeText()
    {
        switch (wType)
        {
            case WeaponType.Ballista:
            {
                if (sType == StatType.attackDamage)
                {
                    childText.text =  "Damage: " +  WeaponManagerScript.Instance.Ballista.GetComponent<BallistaScript>().attackDamage.ToString();          
                }

                if (sType == StatType.attackSpeed)
                {
                    childText.text = "FireRate: " + WeaponManagerScript.Instance.Ballista.GetComponent<BallistaScript>().attackSpeed.ToString();
                }

                if (sType == StatType.projectileSpeed)
                {
                    childText.text =  "Arrow Speed: " + WeaponManagerScript.Instance.Ballista.GetComponent<BallistaScript>().projectileSpeed.ToString();
                }

                break;
            }
            case WeaponType.Canon:
            {
                if (sType == StatType.attackDamage)
                {
                    childText.text = "Damage: " + WeaponManagerScript.Instance.Canon.GetComponent<CanonScript>().attackDamage;          
                }

                if (sType == StatType.attackSpeed)
                {
                    childText.text = "FireRate: " + WeaponManagerScript.Instance.Canon.GetComponent<CanonScript>().attackSpeed;
                }

                if (sType == StatType.projectileSpeed)
                {
                    childText.text =  "Power: " + WeaponManagerScript.Instance.Canon.GetComponent<CanonScript>().projectileSpeed;
                }

                break;
            }
            
            case WeaponType.Catapult:
            {
                if (sType == StatType.attackDamage)
                {
                    childText.text = "Damage: " + WeaponManagerScript.Instance.Catapult.GetComponent<CatapultScript>().attackDamage.ToString();          
                }

                if (sType == StatType.attackSpeed)
                {
                    childText.text = "FireRate: " + WeaponManagerScript.Instance.Catapult.GetComponent<CatapultScript>().attackSpeed.ToString();
                }

                if (sType == StatType.projectileSpeed)
                {
                    childText.text =  "Power: " + WeaponManagerScript.Instance.Catapult.GetComponent<CatapultScript>().projectileSpeed.ToString();
                }

                break;
            }
        }
    }
}
