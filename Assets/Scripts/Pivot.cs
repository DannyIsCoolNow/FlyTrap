using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    difference.Normalize();

    float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

    transform.rotation=Quaternion.Euler(0f, 0f, rotationZ);

    if (rotationZ<-90 || rotationZ >90){


        if (Player.transform.eulerAngles.y == 0) {

            transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);

        } else if (Player.transform.eulerAngles.y == 180) {

            transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);

        }

    }

    }
}
