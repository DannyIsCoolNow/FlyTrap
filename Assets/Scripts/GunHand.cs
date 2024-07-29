using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHand : MonoBehaviour


{
    private Transform target;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Hand").GetComponent<Transform>();
        
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = target.transform.position;
        transform.rotation =  target.transform.rotation;
        /**if (transform.position.x != mousePos.x) {
            render.flipX = transform.position.x > mousePos.x;
        }
        */
    }
}
