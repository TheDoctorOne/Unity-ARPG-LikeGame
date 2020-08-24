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
    public Animator bodyAnimator;

    public RuntimeAnimatorController bodyIdle;
    public RuntimeAnimatorController bodyWalk;
    public RuntimeAnimatorController bodyWalkBackwards;
    public RuntimeAnimatorController bodyJump;

    public float jumpHeight = 8f;

    private float gravity = -9.81f * 2.5f;
    public bool isGrounded = false;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        //float dist = y - (0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        else
            velocity.y += gravity * Time.deltaTime;
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
            Debug.unityLogger.Log(velocity.y);
        } 


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        /*if (Input.GetMouseButton(1))
            z = 0.8f;*/
        if(velocity.y > 0f)
            bodyAnimator.runtimeAnimatorController = bodyJump;
        else if (x > 0 || z > 0)
            bodyAnimator.runtimeAnimatorController = bodyWalk;
        else if(z<0)
            bodyAnimator.runtimeAnimatorController = bodyWalkBackwards;
        else
            bodyAnimator.runtimeAnimatorController = bodyIdle;
        Vector3 move = body.transform.right * x + body.transform.forward * z;

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(body.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;


        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
        body.rotation = Quaternion.AngleAxis(angle + 270f, -Vector3.up);

        /*float y = this.gameObject.transform.position.y;
        this.gameObject.transform.position = gameObject.transform.position - new Vector3(0, y-0.05f, 0);*/
    }
}