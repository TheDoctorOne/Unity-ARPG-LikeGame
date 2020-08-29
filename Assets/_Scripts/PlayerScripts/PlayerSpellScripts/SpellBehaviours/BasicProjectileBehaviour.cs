using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectileBehaviour : SpellBehaviourBase
{
    protected override void OnCollision(Collision collision)
    {

    }

    protected override void OnCreate()
    {
        if (transform.parent != null)
        {
            this.transform.SetParent(null);
        }
        LifeSpanInSec = 1.5f;
    }

    protected override void SpellBehaviour()
    {
        transform.position = transform.position + transform.forward * 30f * Time.deltaTime;
    }
}
