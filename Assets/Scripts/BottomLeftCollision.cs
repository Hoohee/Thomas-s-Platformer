using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLeftCollision : MonoBehaviour
{
    public bool leftCollision;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInParent<PhysicsPlayer>().leftRampDetected = leftCollision;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            leftCollision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            leftCollision = false;
        }
    }
}
