using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class AreaMagicDamageBehaviour : SpellBehaviourBase
{
    public bool groundCollision = false;
    public ProBuilderMesh mesh;
    protected override void SpellBehaviour()
    {
        if(!groundCollision)
            transform.position = transform.position + transform.up * -1f * 7f * Time.deltaTime;
    }

    protected override void OnCollision(Collision collision)
    {
        Debug.unityLogger.Log("Do Stuff");
        if(collision.collider.gameObject.layer == (int) GameGlobals.Layers.Env)
        {
            groundCollision = true;
        }
    }

    protected override void OnCreate()
    {
        transform.position = GameObject.FindGameObjectWithTag("characterBody").transform.position + new Vector3(Utils.getObjectBounds(mesh).x/2,1f,0);
        LifeSpanInSec = 1.3f;
    }
}
