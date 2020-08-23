using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereOfStaff : MonoBehaviour
{
    private float time;
    public float destroyTimeInSec = 0.1f;
    private int MODE = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        this.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.MODE) {
            case 1:
                transform.position = transform.position + transform.up * 5f * Time.deltaTime;
                break;
            case 2:
                if(transform.position.y > 0)
                    transform.position = transform.position + transform.up * -1 * 5f * Time.deltaTime;
                //transform.position = transform.position + transform.up * 5f * Time.deltaTime;
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

    //Detect collisions between the GameObjects with Colliders attached
    
}
