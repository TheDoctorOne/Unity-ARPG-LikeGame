using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementController : MonoBehaviour
{
    public CharacterController controller;
    public Transform body;
    public Transform charCamera;

    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        //float dist = y - (0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(body.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;


        controller.Move(move * speed * Time.deltaTime);
        body.rotation = Quaternion.AngleAxis(angle + 270f, -Vector3.up);

        float y = this.gameObject.transform.position.y;
        this.gameObject.transform.position = gameObject.transform.position - new Vector3(0, y-0.05f, 0);
    }
}