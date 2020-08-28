using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatsBase
{
    public float Health { get; set; }
    public float Mana { get; set; }
    public float HealthRegen { get; set; }
    public float ManaRegen { get; set; }
    public float PhysicalAttack { get; set; }
    public float MagicAttack { get; set; }
    public float MagicDefence { get; set; }
    public float PhysicalDefence { get; set; }
}
