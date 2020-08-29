using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WhirlwindSpellBehaviour : SpellBehaviourBase
{
    private GameObject characterPrefab;
    //private Quaternion characterRotation;
    public float angle { get; } = 8.0f;
    public float radius { get; } = 0f;
    public float height { get; } = 15f;
    protected override void OnCollision(Collision collision)
    {
        Debug.unityLogger.Log("WW Collision! " + collision.gameObject.name);
    }

    protected override void OnCreate()
    {
        characterPrefab = Utils.FindChildGameObjectByTag(CharacterBody, "CharacterPrefab");
        //transform.parent = null;
    }

    protected override void SpellBehaviour()
    {
        characterPrefab.transform.Rotate(characterPrefab.transform.up, 90f * Time.deltaTime * angle);
        transform.RotateAround(characterPrefab.transform.position, characterPrefab.transform.up, 90f * Time.deltaTime * angle);
        //Vector3 desiredPosition = (transform.position - characterPrefab.transform.position).normalized * radius + characterPrefab.transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * angle);
        //transform.position = transform.position + new Vector3(Mathf.Cos(90f),0f,0f) * Time.deltaTime;
    }

    protected override void BeforeDestroy()
    {
        characterPrefab.transform.localRotation = new Quaternion(0,0,0,0);
    }
}
