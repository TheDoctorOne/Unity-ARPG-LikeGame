using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereOfStaff : MonoBehaviour
{
    private float time;
    public float destroyTimeInSec = 0.1f;
    private int MODE = 0;
    private bool once = false;
    private float secondSpellSpeed = 5f;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        //float y = transform.position.y;
        if (!once)
        {
            once = true;
            transform.position = transform.parent.position;
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
            case 2:
                transform.position = transform.position + transform.up * -1 * secondSpellSpeed * Time.deltaTime;
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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            secondSpellSpeed = 0f;
        }
    }
}
