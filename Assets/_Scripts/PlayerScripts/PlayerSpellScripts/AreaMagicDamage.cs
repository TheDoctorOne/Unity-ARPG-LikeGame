using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMagicDamage : SpellBase
{
    public override void FrameUpdate()
    {

    }

    public override void KeyDown()
    {
        Instantiate(spellPrefab, transform.position + new Vector3(0f,0.5f,0f), transform.rotation);
    }

    protected override void OnCreate()
    {
        cooldown = 2.4f;
        hotkey = KeyCode.Alpha1;
        skillName = "Area Damage";
    }

}
