using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : StatsBase
{
    public float PhysicalEnduranceLevel { get; set; }
    public float MagicalEnduranceLevel { get; set; }
    public float MagicPowerLevel { get; set; }
    public float PhysicalPowerLevel { get; set; }


    public float getMagicalAttack()
    {
        return this.MagicPowerLevel * this.MagicAttack;
    }

    public float getPhysicalAttack()
    {
        return this.PhysicalPowerLevel * this.PhysicalAttack;
    }

    public float getMagicalDefence()
    {
        return this.MagicDefence * this.MagicalEnduranceLevel;
    }
    public float getPhysicalDefence()
    {
        return this.PhysicalDefence * this.PhysicalEnduranceLevel;
    }
}
