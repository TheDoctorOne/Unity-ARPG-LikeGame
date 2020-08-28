using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class AreaMagicDamageBehaviour : SpellBehaviourBase
{
    public ProBuilderMesh mesh;
    protected override void SpellBehaviour()
    {
        transform.position = transform.position + transform.up * -1f * 7f * Time.deltaTime;
    }

    protected override void OnCollision(Collision collision)
    {
        Debug.unityLogger.Log("Do Stuff");
    }

    protected override void OnCreate()
    {
        transform.position = GameObject.FindGameObjectWithTag("characterBody").transform.position
            + new Vector3(mesh.gameObject.GetComponent<Renderer>().bounds.size.x/2,1f,0);
        LifeSpanInSec = 1.3f;
    }
}
