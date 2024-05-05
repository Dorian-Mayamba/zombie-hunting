using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;

    public float gravity = -9.8f;
    private bool isGrounded;
    private float jumpHeight = 1.2f;

    private bool sprinting = false;

    private bool crouching = false;

    private bool lerpCrouch = false;

    private float crouchTimer = 0f;

    private Camera camera;  

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform bulletSpawn;
    private Rigidbody bulletRb;

    private void Start() {
        controller = GetComponent<CharacterController>();
        camera = GetComponent<PlayerLook>().cam;
        bulletRb = bullet.GetComponent<Rigidbody>();
    }

    public void Update() {
        isGrounded =  controller.isGrounded;
        if(lerpCrouch)
        {
            crouchTimer+=Time.deltaTime;
            float p = crouchTimer / 1;
            p*=p;
            if(crouching)
                controller.height = Mathf.Lerp(controller.height,1,p);
            else
                controller.height = Mathf.Lerp(controller.height,2,p);

            if(p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
    }

    public void Jump(){
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if(sprinting)
        {
            speed = 8f;
        }else
        {
            speed = 5f;
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Shoot()
    {
        GameObject bulletGO = Instantiate(bullet, bulletSpawn.position, transform.rotation);
        bulletRb.AddForce(transform.forward * 800);
        Destroy(bulletGO, 1);
        Debug.Log("Shoot clicked");
    }
}