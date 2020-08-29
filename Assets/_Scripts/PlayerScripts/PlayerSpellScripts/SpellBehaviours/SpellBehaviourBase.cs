using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellBehaviourBase : MonoBehaviour
{
    protected GameObject Character;
    protected GameObject WeaponRightHand;
    protected GameObject WeaponLeftHand;
    protected GameObject CharacterBody;
    protected PlayerStats stats;
    protected float LifeSpanInSec = -1f;
    protected float CreationTime = 0f;
    // Start is called before the first frame update
    private void Start()
    {
        Character = GameObject.FindGameObjectWithTag("Character");
        WeaponRightHand = Utils.FindChildGameObjectByTag(Character, "WeaponRightHand");
        WeaponLeftHand = Utils.FindChildGameObjectByTag(Character, "WeaponLeftHand");
        CharacterBody = Utils.FindChildGameObjectByTag(Character, "characterBody");
        // Get Stats
        stats = Character.GetComponent<CharacterHandler>().Stats;
        CreationTime = Time.time;
        OnCreate();
    }

    // Update is called once per frame
    private void Update()
    {
        DestroyIfLifeSpan();
        SpellBehaviour();
    }
    private void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }
    private void OnDestroy()
    {
        BeforeDestroy();
    }
    private void DestroyIfLifeSpan()
    {
        if (LifeSpanInSec == -1)
            return;

        if (CreationTime + LifeSpanInSec < Time.time)
        {
            if (this.transform.parent != null)
                Destroy(this.gameObject.transform.parent.gameObject);
            else
                Destroy(this.gameObject);
        }
    }

    protected abstract void OnCreate();
    protected abstract void SpellBehaviour();
    protected abstract void OnCollision(Collision collision);
    
    protected virtual void BeforeDestroy()
    {

    }


}
