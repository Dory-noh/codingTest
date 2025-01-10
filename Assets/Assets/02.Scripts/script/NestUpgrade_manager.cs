using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NestUpgrade_manager : MonoBehaviour
{
    private nest_hp_manager nest_Hp_Manager;
    private Button nest_upgrade_btn;
    public bool canUpgrade = false;
    private readonly string nestUpgradeBtnTag = "NESTUPGRADEBTN";
    void Start()
    {
        nest_Hp_Manager = GameObject.FindGameObjectWithTag("nest_hp_manager").GetComponent<nest_hp_manager>();
        nest_upgrade_btn = GameObject.FindGameObjectWithTag(nestUpgradeBtnTag).GetComponent<Button>();
    }


    void Update()
    {
        
    }

    public void UpgradeNestHp()
    {
        if (canUpgrade)
        {
            canUpgrade = false;
            nest_Hp_Manager.hp += 1000;
            nest_Hp_Manager.Maxhp += 1000;
        }
    }

}
