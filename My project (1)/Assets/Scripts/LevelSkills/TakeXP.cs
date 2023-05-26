using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeXP : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int randomXP = Random.Range(80, 90);
        if(collision.name == "Player")
        {
            if(randomXP >= (PlayerController.instance.sliderXP.maxValue - PlayerController.instance.sliderXP.value))
            {
                PlayerController.instance.plF.xp = 0;
                PlayerController.instance.sliderXP.maxValue += 50;
                PlayerController.instance.plF.levelHero += 1;
                PlayerController.instance.plF.skillPoint += 1;
                
            }
            else
            {
                PlayerController.instance.plF.xp += randomXP;      
            }
            Destroy(gameObject);
        }
    }
}
