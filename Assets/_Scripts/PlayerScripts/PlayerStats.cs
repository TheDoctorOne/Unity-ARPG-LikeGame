using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : StatsBase
{
    public float PhysicalEnduranceLevel { get; set; } = 1;
    public float MagicalEnduranceLevel { get; set; } = 1;
    public float MagicPowerLevel { get; set; } = 1;
    public float PhysicalPowerLevel { get; set; } = 1;



    public float getMagicalAttack()
    {
        return getFormula(this.MagicPowerLevel,this.MagicAttack,this.MagicalAttackMultiplier,this.MagicalAttackAddition);
    }

    public float getPhysicalAttack()
    {
        return getFormula(this.PhysicalPowerLevel, this.PhysicalAttack, this.PhysicalAttackMultiplier, this.PhysicalAttackAddition);
    }

    public float getMagicalDefence()
    {
        return getFormula(this.MagicDefence, this.MagicalEnduranceLevel, this.MagicalDefenceMultiplier, this.MagicalDefenceAddition);
    }
    public float getPhysicalDefence()
    {
        return getFormula(this.PhysicalDefence, this.PhysicalEnduranceLevel, this.PhysicalDefenceMultiplier, this.PhysicalDefenceAddition);
    }

    private float getFormula(float PowerLevel, float RawPower, float Multiplier, float Addition)
    {
        return PowerLevel * (RawPower + Addition) * Multiplier;
    }
}
