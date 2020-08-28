using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMagicDamage : SkillBase
{

    public override void skillCreate()
    {
        Instantiate(spellPrefab, transform.position, transform.rotation);
    }

    protected override void OnCreate()
    {
        cooldown = 2.4f;
        hotkey = KeyCode.Alpha1;
        skillName = "Area Damage";
    }

}
