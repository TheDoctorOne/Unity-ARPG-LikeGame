using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlwindSpell : SpellBase
{

    public GameObject spellPrefab2;
    private GameObject generated = null;
    private GameObject generated2 = null;
    public override void FrameUpdate()
    {

    }

    public override void KeyDown() //Update
    {
        if (generated == null)
        {
            generated = Instantiate(spellPrefab, CharacterBody.transform);
            GameGlobals.CurrentSpell = GameGlobals.Spells.Whirlwind;
        }
        if (generated2 == null)
        {
            generated2 = Instantiate(spellPrefab2, CharacterBody.transform);
            GameGlobals.CurrentSpell = GameGlobals.Spells.Whirlwind;
        }

    }

    public override void KeyIsNotDown()
    {
        base.KeyIsNotDown();

        if (generated != null)
        {
            Destroy(generated);
            generated = null;
            GameGlobals.CurrentSpell = GameGlobals.Spells.None;
        }
        if (generated2 != null)
        {
            Destroy(generated2);
            generated2 = null;
            GameGlobals.CurrentSpell = GameGlobals.Spells.None;
        }
    }

    protected override void OnCreate()
    {
        hotkey = KeyCode.Mouse1;
        skillType = SkillType.UseKeyHold;
        skillName = "Whirly Wind";
    }
}
