using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [Header("Movement")]
    private float speed;
    public float walkSpeed;
    public float runSpeed;
    public float airSpeed;
    public float Drag;
    public float speedHere;
    [Header("Jump")]
    public bool readyToJump;
    public float jumpForce;
    [Header("Dash")]
    public bool dashInTheAir;
    public float dashes;
    public float dashSpeed;
    public float DashForce;
    public float DashUpwardForce;
    public bool dashing;
    public CameraRotation cameraRotation;
    public Transform PlayerCam;
    public float DashDuration;
    public float dashCd;
    public float dashCdGlobal;
    public float dashCdTimerGlobal;
    private float dashCdTimer;
    [Header("KeyBinds")]
    public KeyCode jumpButton;
    public KeyCode runButton;
    public KeyCode dashButton;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask GroundUNow;
    bool grounded;
    [Header("CameraInteraction")]
    public Transform orientation;

    float HInput;
    float VInput;
    Vector3 Direction;
 
    Rigidbody rb;
    [Header("State")]
    public MovementState state;
    public enum MovementState
    {
	walking,
	running,
        dashing,
	air
    
    }  
    



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
	speed = walkSpeed;
	readyToJump = true;
        dashCdTimerGlobal = dashCdGlobal;
    }

    // Update is called once per frame
    private void Update()
    {
	Debug.DrawRay(transform.position, Vector3.up, Color.green, playerHeight * 0.5f + 1.2f);
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 1.2f, GroundUNow);
        MyInput();
        SpeedControl();
	StateHandler();
	speedHere = speed;



        

        
        if (dashCdTimer > 0)
        {
            dashCdTimer -= Time.deltaTime;
        }
        
        if (dashes > 0)
        {
            dashInTheAir = true;
            if (Input.GetKeyDown(dashButton))
            {
                Dash();
            }
        }

        if (dashes == 0)
        {
            dashInTheAir = false;
            dashing = false;
            dashCdTimerGlobal -= Time.deltaTime;
        }
        if (dashCdTimerGlobal <= 0)
        {
            dashes = 3;
            dashCdTimerGlobal = dashCdGlobal;
        }

    }
    private void StateHandler()
    {
        if (Input.GetKeyDown(jumpButton) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ReadyToJump), 0.02f);
        }

        if (dashing && dashInTheAir)
        {
            rb.drag = 5f;
            state = MovementState.dashing;
            rb.mass = 5f;
            speed = dashSpeed;

            
        }
	else if (grounded && Input.GetKey(runButton))
	{
	   state = MovementState.running;
	   speed = runSpeed;
	   rb.drag = 2.5f;
           rb.mass = 5f;
	}
	else if (grounded)
	{
	   state = MovementState.walking;
	   speed = walkSpeed;
	   rb.drag = Drag;
           rb.mass = 5f;
	}
	else
	{
	   state = MovementState.air;
	   rb.drag = 5f;
           speed = airSpeed;
           rb.mass += Time.deltaTime * 5;
	}
        
	
	
    }
    private void Jump()
    {
	rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);	   
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ReadyToJump()
    {
	readyToJump = true;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void MyInput()
    {
        HInput = Input.GetAxisRaw("Horizontal");
        VInput = Input.GetAxisRaw("Vertical");
    }

    private void Movement()
    {
        Direction = orientation.forward * VInput + orientation.right * HInput;
        if (grounded)
        {
            rb.AddForce(Direction.normalized * speed * 15f, ForceMode.Force);
        }
	else if (!grounded)
	{
	    rb.AddForce(Direction.normalized * speed * 15f * 1, ForceMode.Force);
	}
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
    }



    private void Dash()
    {
         
         if (dashCdTimer > 0) return;
         else dashCdTimer = dashCd;

         dashing = true;
         dashes -= 1;
         Vector3 dashDirectionInTheAir = PlayerCam.forward * VInput + PlayerCam.right * HInput;
         Vector3 dashDirectionOnTheGround = orientation.forward * VInput + orientation.right * HInput;
         Vector3 forceToApply = dashDirectionInTheAir.normalized * DashForce + orientation.up * DashUpwardForce;
         Vector3 forceToApplyOnTheGround = dashDirectionOnTheGround.normalized * DashForce + orientation.up * DashUpwardForce;
         Vector3 forceToApplyDirection = PlayerCam.forward * DashForce + orientation.up * DashUpwardForce;
         if (HInput == 0 && VInput == 0)
         {
             delayedForceToApply = forceToApplyDirection;
         }
         else if (grounded && cameraRotation.XRotation >= -50)
         {
             delayedForceToApply = forceToApplyOnTheGround;
         }
         else
         {
             delayedForceToApply = forceToApply;
         }
        

         
         delayedForceToApplyDirection = dashDirectionInTheAir;

         Invoke(nameof(DelayedDashInPlaceForce), 0.2f);
         Invoke(nameof(ResetDash), DashDuration);
    }

    private Vector3 delayedForceToApply;
    private Vector3 delayedForceToApplyDirection;	

    private void DelayedDashInPlaceForce()
    {
         rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }
    private void DelayedDashForce()
    {
         rb.AddForce(delayedForceToApplyDirection, ForceMode.Impulse);
    }



    private void ResetDash()
    {
         dashing = false;
    }

}
