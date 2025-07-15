using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    Button button;
    public StatType sType;
    public WeaponType wType;

    void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        button.onClick.AddListener(MinFunktion);
    }

    void MinFunktion()
    {
        GameManagerScript.Instance.UpgradeWeapon(wType, sType);
    }
}
