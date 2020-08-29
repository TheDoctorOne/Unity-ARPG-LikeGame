using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereOfStaff : MonoBehaviour
{
    private float time;
    public float destroyTimeInSec = 0.1f;
    private int MODE = 0;
    private bool once = false;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        //float y = transform.position.y;
        if (!once)
        {
            once = true;
            try
            {
                transform.position = transform.parent.position;
            }
            catch (NullReferenceException) { };
        }
        
        //this.transform.localPosition += new Vector3(0,y,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(once && transform.parent != null)
        {
            this.transform.SetParent(null);
        }
        switch (this.MODE) {
            case 1:
                transform.position = transform.position + transform.up * 5f * Time.deltaTime;
                break;
            default:
                transform.position = transform.position + transform.forward * 30f * Time.deltaTime;
                break;
        }
        if (Time.time - time > destroyTimeInSec)
            Destroy(this.gameObject);
    }

    void setMODE(int newMode)
    {
        this.MODE = newMode;
    }

}
