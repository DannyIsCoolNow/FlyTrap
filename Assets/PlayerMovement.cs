using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movSpeed = 3.5f;
    private float acceleration = 50.0f;
    private float friction = 50.0f;
    Vector3 currspeed;
    float speedX, speedY;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float speedX = Input.GetAxisRaw("Horizontal");
        float speedY = Input.GetAxisRaw("Vertical");
        Vector3 playerinput = new Vector3(speedX, speedY, 0);
        currspeed += playerinput.normalized * Time.deltaTime * (acceleration + friction);
        if (currspeed.magnitude < friction * Time.deltaTime)
        {
            currspeed = new(0, 0, 0);
        }
        else
        {
            currspeed -= currspeed.normalized * friction * Time.deltaTime;
        }
        if (currspeed.magnitude > movSpeed)
        {
            currspeed = currspeed.normalized * movSpeed;
        }
        transform.position += (currspeed * Time.deltaTime);

    }
}
