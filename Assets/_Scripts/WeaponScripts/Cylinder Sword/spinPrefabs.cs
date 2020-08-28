using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinPrefabs : MonoBehaviour
{
    public GameObject origin;
    public float angle = 2.0f;
    public float radius = 50f;
    public float height = 15f;
    // Start is called before the first frame update
    void Start()
    {
        origin = GameObject.FindGameObjectWithTag(origin.tag);
    }

    // Update is called once per frame
    void Update()
    {

        transform.RotateAround(origin.transform.position, origin.transform.up ,90f*Time.deltaTime*angle);

        Vector3 desiredPosition = (transform.position - origin.transform.position).normalized * radius + origin.transform.position;
        
        
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * angle);
        
        
    }
}
