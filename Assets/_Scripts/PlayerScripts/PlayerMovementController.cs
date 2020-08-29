using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

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

    public RuntimeAnimatorController WhirlwindAnimation;

    private float angle = 0;


    public float jumpHeight = 1f;

    private float gravity = -9.81f * 2.5f;
    public bool isGrounded = false;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    public float speed = 20f;
    public float targetAngle = 0f;
    public float angleCounter = 0f;
    Vector2 mPos;
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
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        } 


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        /*if (Input.GetMouseButton(1))
            z = 0.8f;*/
        if (GameGlobals.CurrentSpell == GameGlobals.Spells.Whirlwind)
            bodyAnimator.runtimeAnimatorController = WhirlwindAnimation;
        else if (!isGrounded)
            bodyAnimator.runtimeAnimatorController = bodyJump;
        else if (x > 0 || z > 0)
            bodyAnimator.runtimeAnimatorController = bodyWalk;
        else if(z<0)
            bodyAnimator.runtimeAnimatorController = bodyWalkBackwards;
        else
            bodyAnimator.runtimeAnimatorController = bodyIdle;

        Vector3 move = body.transform.right * x + body.transform.forward * z;
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(body.position);

        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        turnCharacter(angle);
    }


    private void turnCharacter(float angle)
    {

        if (targetAngle != angleCounter)
        {
            angleCounter += (targetAngle - angleCounter) / 2f;
            transform.rotation = Quaternion.AngleAxis(angleCounter, -Vector3.up);
            body.localRotation = Quaternion.AngleAxis(angle + 270f, -Vector3.up);

        }

        if (Input.GetMouseButton(2))
        {

            targetAngle += Input.GetAxis("Mouse X") * Time.deltaTime * 600f;
            Utils.SetCursorPos((int)mPos.x, (int)mPos.y);
        }
        else
        {
            mPos.x = (float)Utils.GetCursorPosition()[0];
            mPos.y = (float)Utils.GetCursorPosition()[1];
            body.localRotation = Quaternion.AngleAxis(angle + 270f, -Vector3.up);
        }
    }
}