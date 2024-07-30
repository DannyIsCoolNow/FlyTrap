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
    public KeyCode Dodgeroll;
    public float dodgespeed;
    public float dodgelength;
    private SpriteRenderer render;
    private bool rolling = false;
    private float rollfor;
    private float originalSpeed;
    private float justRolled=0;
    public float rollSlowTime;
    public float rollSlow;
    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = movSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        render = GetComponent<SpriteRenderer>();
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (transform.position.x != mousePos.x) {
            render.flipX = transform.position.x > mousePos.x;
        }

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

        if (Input.GetKeyDown(Dodgeroll) && rolling!=true && justRolled==0){
            rollfor = dodgelength;
            rolling = true;
        }
        if (rolling==true && rollfor>=0){
            movSpeed = dodgespeed;
            rollfor-=1;
            if (rollfor==0){
                justRolled = rollSlowTime;
            }
        }
        if (rollfor<=0 && justRolled==0){
            movSpeed = originalSpeed;
            rolling=false;
        }

    if (justRolled>0){
        movSpeed = rollSlow;
        justRolled-=1;
        
    }



    }



}
