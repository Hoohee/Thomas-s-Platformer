using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformXMove : MonoBehaviour
{
    public float speed = 1;
    public float distance = 10;
    public float timeMoved = 0;
    Vector3 startLocation;

    private Rigidbody2D platformBody;
    // Start is called before the first frame update
    void Start()
    {
        startLocation = transform.position;
        platformBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        platformBody.velocity = (new Vector2(speed, 0));
        timeMoved+= 1*Time.deltaTime;

        if (timeMoved >= distance)
        {
            speed = -speed;
            timeMoved = 0;
        }
    }
}
