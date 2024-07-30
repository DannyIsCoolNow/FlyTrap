using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrupted : MonoBehaviour
{ 
    private Transform target;
    public float speed;
    private float distance;
    private float personalSpeed;
    private Vector3 lastPos;
    private float timer;
    public Sprite[] runFrames;
     private SpriteRenderer render;
     private float a = 0;
     private float b = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        personalSpeed = (float) speed;
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != target.position.x) {
            render.flipX = transform.position.x > target.position.x;
        }
        lastPos = transform.position;
        var distance = (transform.position - lastPos) / Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position,personalSpeed*Time.deltaTime);
        a = a+1;
        if (distance.magnitude >= 0.0f) {
            b = a/12;
           var frame = (int) b;
        render.sprite = runFrames[frame];

        if (a==90){
            a=0;
        }
        }
    
    }



}
