using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatsBase
{
    public float Health { get; set; } = 1;
    public float Mana { get; set; } = 1;
    public float HealthRegen { get; set; } = 1;
    public float ManaRegen { get; set; } = 1;
    public float PhysicalAttack { get; set; } = 1;
    public float MagicAttack { get; set; } = 1;
    public float MagicDefence { get; set; } = 1;
    public float PhysicalDefence { get; set; } = 1;
    public float PhysicalDefenceMultiplier { get; set; } = 1;
    public float PhysicalDefenceAddition { get; set; } = 0;
    public float MagicalDefenceMultiplier { get; set; } = 1;
    public float MagicalDefenceAddition { get; set; } = 0;
    public float PhysicalAttackMultiplier { get; set; } = 1;
    public float PhysicalAttackAddition { get; set; } = 0;
    public float MagicalAttackMultiplier { get; set; } = 1;
    public float MagicalAttackAddition { get; set; } = 0;
}
