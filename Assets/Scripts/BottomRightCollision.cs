using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomRightCollision : MonoBehaviour
{
    public bool rightCollision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInParent<PhysicsPlayer>().rightRampDetected = rightCollision;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            rightCollision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            rightCollision = false;
        }
    }
}
