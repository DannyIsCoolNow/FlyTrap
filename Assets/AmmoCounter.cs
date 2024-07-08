using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    public TMP_Text ammoText;
  

    private GameObject weapon;
    
    // Start is called before the first frame update
    void Start()
    {
       weapon = GameObject.FindGameObjectWithTag("Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        
        ammoText.SetText( weapon.GetComponent<Revolver>().numBullets + "/" + weapon.GetComponent<Revolver>().maxBullets );
    }
}
