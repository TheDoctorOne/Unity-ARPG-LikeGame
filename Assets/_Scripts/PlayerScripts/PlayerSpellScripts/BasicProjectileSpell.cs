using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectileSpell : SkillBase
{
    public Transform projectileLoc;

    public override void skillCreate()
    {
        GameObject projectileObj = null;
        if (projectileLoc == null)
        {
            if (WeaponLeftHand == null && WeaponRightHand == null)
            {
                Instantiate(this.spellPrefab, transform.position, transform.rotation);
            }
            projectileObj = Utils.FindChildGameObjectByTag(WeaponRightHand, "ProjectileLocation");
        }
        else
        {
            Instantiate(this.spellPrefab, projectileLoc.position, transform.parent.rotation);
        }

        if (projectileObj != null)
        {
            Instantiate(this.spellPrefab, projectileObj.transform.position, transform.parent.localRotation);
        }
        else
        {
            projectileObj = Utils.FindChildGameObjectByTag(WeaponLeftHand, "ProjectileLocation");
            if (projectileObj != null)
            {
                Instantiate(this.spellPrefab, projectileObj.transform.position, transform.parent.localRotation);
            }
            else
            {
                Instantiate(this.spellPrefab, WeaponRightHand.transform.position, CharacterBody.transform.rotation);
            }
        }
    }

    protected override void OnCreate()
    {
        cooldown = 0.3f;
        hotkey = KeyCode.Mouse0;
        skillType = SkillType.UseKeyHold;
        skillName = "Basic Projectile";
    }
}
