using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
   public void SetHealthBar(float health){
    slider.value = health;
   }

public void SetMaxHealthBar(float maxHealth){
    slider.maxValue = maxHealth;
   }

}
