using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    public KeyCode reloadKey;
    private int timeBeforeReload = 0;
    public int timeBetweenReload;
    private int timeBeforeShoot = 0;
    public int timeBetweenShot;

    public int maxBullets;

    public int numBullets;

    public float bulletForce;
    private Rigidbody2D rb;
    [SerializeField] Transform firePoint;
[SerializeField] GameObject bulletPrefab;



    // Start is called before the first frame update
    void Start()
    {
        numBullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBeforeShoot > 0){

            timeBeforeShoot = timeBeforeShoot - 1;
        }

        if (timeBeforeReload > 0){

            timeBeforeReload = timeBeforeReload - 1;
        }


        if (Input.GetMouseButton(0))
        {
            shootInput();
        }

        if (Input.GetKeyDown(reloadKey))
        {
            reloadInput();
        }
    }

void reloadInput(){

if (timeBeforeReload==0){
    reload();
}


}

void reload(){

numBullets = maxBullets;
timeBeforeReload = timeBetweenReload;

}

void shootInput(){

if (timeBeforeShoot==0 && numBullets>0){
    shoot();

    }

}

void shoot(){

GameObject bullet = Instantiate(bulletPrefab, transform.position, new());
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

timeBeforeShoot = timeBetweenShot;
numBullets = numBullets -1;
}




}
