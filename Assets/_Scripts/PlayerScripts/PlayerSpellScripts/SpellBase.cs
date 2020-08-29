using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellBase : MonoBehaviour
{
    protected enum SkillType
    {
        UseKeyDown = 0,
        UseKeyHold = 1,
        UseWhenKeyUp = 2,
        Manual = 3
    }
    protected GameObject CharacterBody;
    protected GameObject WeaponRightHand;
    protected GameObject WeaponLeftHand;
    protected string skillName;
    protected bool isLearned = true;
    protected KeyCode hotkey;
    protected float cooldown; //In Secs
    protected float latestUsage;
    protected float skillLevel;
    protected float skillExp;
    protected SkillType skillType;


    public GameObject spellPrefab;


    // Start is called before the first frame update

    void Start()
    {
        latestUsage = float.NegativeInfinity;
        WeaponRightHand = Utils.FindChildGameObjectByTag(this.gameObject, "WeaponRightHand");
        WeaponLeftHand = Utils.FindChildGameObjectByTag(this.gameObject, "WeaponLeftHand");
        CharacterBody = Utils.FindChildGameObjectByTag(this.gameObject, "characterBody");
        OnCreate();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLearned)
            return;
        if (getKeyEvent(hotkey)) // Spell Key
        {
            if (latestUsage + cooldown < Time.time) // Spell Usable
            {
                latestUsage = Time.time;

                KeyDown();
            }
        }
        else
        {
            KeyIsNotDown();
        }
        FrameUpdate();
    }
    private bool getKeyEvent(KeyCode keyCode)
    {
        switch (skillType)
        {
            case SkillType.UseKeyHold:
                return Input.GetKey(keyCode);
            case SkillType.UseWhenKeyUp:
                return Input.GetKeyUp(keyCode);
            case SkillType.Manual:
                return true;
            default:
                return Input.GetKeyDown(keyCode);
        }
    }
    /*
     * Gets called by update function
     * **/
    public abstract void KeyDown();
    public virtual void KeyIsNotDown() { }

    public abstract void FrameUpdate();

    protected abstract void OnCreate();

    public void changeHotkey(KeyCode keyCode)
    {
        this.hotkey = keyCode;
    }
    
}
