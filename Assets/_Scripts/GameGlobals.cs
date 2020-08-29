using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGlobals
{
    public enum Layers:int
    {
        Default = 0 ,
        Water = 4,
        UI = 5,
        Env = 8,
        Player = 9,
        FriendlyProjectiles = 10,
        BackgroundUI = 11
    }

    public enum Spells
    {
        None = 0,
        BasicProjectile = 1,
        AreaMagicDamage = 2,
        Whirlwind = 3
    }

    public static Spells CurrentSpell = Spells.None;

}
