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
    public Transform firePoint;
    private bool isReloading = false;
    public GameObject flashPrefab;

    [SerializeField] private AudioClip[] RevolverShot;
    [SerializeField] private AudioClip RevolverReload;
    [SerializeField] private AudioClip ChamberEmpty;
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
        if (isReloading==true && timeBeforeReload == 0){
            reload();
        }
    }

void reloadInput(){

if (isReloading==false){
    isReloading=true;
}
else{ 
    isReloading=false;

}

}

void reload(){
    if (numBullets<maxBullets){
        SoundFXManager.instance.PlaySoundFXClip(RevolverReload, transform, 1f);
numBullets = numBullets+1;
    } else {
        isReloading=false;
    }
timeBeforeReload = timeBetweenReload;

}

void shootInput(){

if (timeBeforeShoot==0 && numBullets>0 && isReloading==false){
    shoot();

    }
    if (numBullets==0 && timeBeforeShoot==0){
        SoundFXManager.instance.PlaySoundFXClip(ChamberEmpty, transform, 1f);
        timeBeforeShoot=timeBetweenShot;
    }
}

void shoot(){

GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        
        Instantiate(flashPrefab, transform.position, transform.rotation);

        SoundFXManager.instance.PlayRandomSoundFXClip(RevolverShot, transform, 1f);

timeBeforeShoot = timeBetweenShot;
numBullets = numBullets -1;
}




}
