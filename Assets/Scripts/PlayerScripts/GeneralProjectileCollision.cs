using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralProjectileCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.unityLogger.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "env")
        {
            Destroy(gameObject);
        }
    }
}
