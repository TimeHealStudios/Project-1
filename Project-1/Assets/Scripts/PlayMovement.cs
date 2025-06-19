using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayMovement : MonoBehaviour
{
    [Header("the shmooves")]
    public float speed;
    public float jumpForce;
    public float gDrag;
    public float jumpCooldown;
    public float airSpeed;
    public bool canYouJump = true;
    public Transform orientation;

    float HorInput;
    float VerInput;

    Vector3 moveDirection;

    [Header("keys on a piano")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("collision stuff")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        canYouJump = true;
    }

    // Update is called once per frame
    void Update()
    {

        //check if floor?
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //controls graDg
        if (grounded)
        {
            rb.linearDamping = gDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }


        inputs();
        MoveAndStuff();
        SpeedControl();
    }

    private void MoveAndStuff()
    {
        //find move dir
        moveDirection = orientation.forward * VerInput + orientation.right * HorInput;

        //on the floor writhing in pain
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * speed * airSpeed, ForceMode.Force);
        }

    }


    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void JumpAgain()
    {
        canYouJump = true;
    }

    private void inputs()
    {
        HorInput = Input.GetAxisRaw("Horizontal");
        VerInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && canYouJump && grounded)
        {
            canYouJump = false;
            Invoke(nameof(JumpAgain), jumpCooldown);

            Jump();
            Debug.Log("wahooo");
        }
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > speed && !grounded)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
}
