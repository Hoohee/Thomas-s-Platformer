using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlayer : MonoBehaviour {
    public float trackInput;
    public float jumpForce;
    [SerializeField]
    //Following is the variable that controls how fast the player moves forward.
    public float horizontalForce;
    private float horizontalSpeed;
    public bool running;
    public float runMultiplier;

    //Set maxJumpTime in the Inspector, but leave the other two alone as they'll be set by code.
    public bool stillJumping;
    public float timeJumped;
    public float maxJumpTime;
    public float customGravity;
    
    
    //The following will be remotely set by the detector object, based on the overlapping platform's movement.
    public float horizontalPlatformMovement;

    //This will be set remotely from the BottomCollider child:
    public bool grounded;
    public bool canJump = true;

    //The following two test for ramps and walls, in order to add a boost up ramps.
    public bool leftRampDetected;
    public bool leftWallDetected;
    public bool rightRampDetected;
    public bool rightWallDetected;

    //The following is the force of that boost up ramps.

    public float rampBoost;
    

    private Rigidbody2D playerrigidbody;
	// Use this for initialization
	void Start () {
        //This game will run at 30 FPS.
        Application.targetFrameRate = 30;
        playerrigidbody = GetComponent<Rigidbody2D>();
        stillJumping = false;
	}
	
    void Update ()
    {
        
        if (Input.GetButtonDown("Jump") && grounded && canJump){
            playerrigidbody.AddForce(new Vector2(0, jumpForce));
            canJump = false;
            stillJumping = true;
        }
        if ((Input.GetAxis("Jump") == 0) && (grounded == true))
            canJump = true;

        //This is new code for differing jump strength.
        if ((stillJumping == true) &&  (timeJumped < maxJumpTime))
        {
            timeJumped += 1;
            if (timeJumped < maxJumpTime)
            {
                playerrigidbody.AddForce(new Vector2(0, jumpForce));
                playerrigidbody.gravityScale = 0;
            }
            else
            {
                stillJumping = false;
            }
        }
        if ((stillJumping == true) && (timeJumped >= maxJumpTime)){
            stillJumping = false;

        }
        if ((stillJumping == true) && (Input.GetButtonUp("Jump"))){
            stillJumping = false;
        }
        //if (stillJumping == true)
        //{
         //   playerrigidbody.AddForce(new Vector2(0, jumpForce));
            //playerrigidbody.gravityScale = 0;
        //}
        if (stillJumping == false)
        {
            playerrigidbody.gravityScale = customGravity;
        }


            if (leftRampDetected && !leftWallDetected && grounded && (trackInput < 0))
        {
            playerrigidbody.AddForce(new Vector2(0, rampBoost));
        }
        if (rightRampDetected && !rightWallDetected && grounded && (trackInput > 0))
        {
            playerrigidbody.AddForce(new Vector2(0, rampBoost));
        }

        if (Input.GetButton("Fire1"))
        {
            running = true;
            horizontalSpeed = horizontalForce * runMultiplier;
        }
        else
        {
            running = false;
            horizontalSpeed = horizontalForce;
        }
            

    }

    // Update is called once per frame
    void FixedUpdate () {
        float horizontalInput = Input.GetAxis("Horizontal");
        trackInput = Input.GetAxis("Horizontal");
        //The player's total horizontal movement is the sum of self-powered movement and that of the platform it rides.
        playerrigidbody.velocity = (new Vector2((horizontalInput * horizontalSpeed)+horizontalPlatformMovement, 0));
	}

    
}
