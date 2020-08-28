using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellBehaviourBase : MonoBehaviour
{
    protected float LifeSpanInSec = -1f;
    protected float CreationTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        CreationTime = Time.time;
        OnCreate();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyIfLifeSpan();
        SpellBehaviour();
    }
    private void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }
    protected abstract void OnCreate();
    protected abstract void SpellBehaviour();
    protected abstract void OnCollision(Collision collision);
    private void DestroyIfLifeSpan()
    {
        if(CreationTime + LifeSpanInSec < Time.time)
        {
            if (this.transform.parent != null)
                Destroy(this.gameObject.transform.parent.gameObject);
            else
                Destroy(this.gameObject);
        }
    }
}
