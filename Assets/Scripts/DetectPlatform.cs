using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlatform : MonoBehaviour
{
    public float currentPlatformX;
    public bool onStillPlatform;
    public bool onMovingPlatform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //The next will move the player along with the platform it is on, if it moves at all.
        GetComponentInParent<PhysicsPlayer>().horizontalPlatformMovement = currentPlatformX;

        //This event constantly gets info about platform collisions; for both still and moving platforms it will set the player to grounded.
        if (onStillPlatform == true){
            GetComponentInParent<PhysicsPlayer>().grounded = true;
            GetComponentInParent<PhysicsPlayer>().timeJumped = 0;
        }
        else if (onMovingPlatform == true)
        {
            
            GetComponentInParent<PhysicsPlayer>().grounded = true;
            GetComponentInParent<PhysicsPlayer>().timeJumped = 0;


        }
        else
        {
            GetComponentInParent<PhysicsPlayer>().grounded = false;
            
        }
    }
    //The following two events cause a glitch when going from one to the other.  Suggest different ideas, like "or" equivalent.
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Platform"){
            onStillPlatform = true;
            //Move the following to update:
            //
        }
        if (other.tag == "MovingPlatform")
        {
            onMovingPlatform = true;
            
            currentPlatformX = other.GetComponent<Rigidbody2D>().velocity.x;
        }
        

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            onStillPlatform = false;
            //Move the following to update:
            //GetComponentInParent<PhysicsPlayer>().grounded = false;
        }
        if (other.tag == "MovingPlatform")
        {
            onMovingPlatform = false;
            //You might want to add a more complex formula for a gradual fall-off of momentum here, in case your plaforms move quickly.
            currentPlatformX = 0;
        }
    }
}
