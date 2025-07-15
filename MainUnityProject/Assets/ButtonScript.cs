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
                    childText.text =  WeaponManagerScript.Instance.Ballista.GetComponent<BallistaScript>().attackDamage.ToString();          
                }

                if (sType == StatType.attackSpeed)
                {
                    childText.text =  WeaponManagerScript.Instance.Ballista.GetComponent<BallistaScript>().attackSpeed.ToString();
                }

                if (sType == StatType.projectileSpeed)
                {
                    childText.text =  WeaponManagerScript.Instance.Ballista.GetComponent<BallistaScript>().projectileSpeed.ToString();
                }

                break;
            }
            case WeaponType.Canon:
            {
                if (sType == StatType.attackDamage)
                {
                    childText.text =  WeaponManagerScript.Instance.Canon.GetComponent<CanonScript>().attackDamage.ToString();          
                }

                if (sType == StatType.attackSpeed)
                {
                    childText.text =  WeaponManagerScript.Instance.Canon.GetComponent<CanonScript>().attackSpeed.ToString();
                }

                if (sType == StatType.projectileSpeed)
                {
                    childText.text =  WeaponManagerScript.Instance.Canon.GetComponent<CanonScript>().projectileSpeed.ToString();
                }

                break;
            }
            
            case WeaponType.Catapult:
            {
                if (sType == StatType.attackDamage)
                {
                    childText.text =  WeaponManagerScript.Instance.Catapult.GetComponent<CatapultScript>().attackDamage.ToString();          
                }

                if (sType == StatType.attackSpeed)
                {
                    childText.text =  WeaponManagerScript.Instance.Catapult.GetComponent<CatapultScript>().attackSpeed.ToString();
                }

                if (sType == StatType.projectileSpeed)
                {
                    childText.text =  WeaponManagerScript.Instance.Catapult.GetComponent<CatapultScript>().projectileSpeed.ToString();
                }

                break;
            }
        }
    }
}
