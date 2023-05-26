using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public GameObject enemy;
    public GameObject chest;

    
    void Start()
    {
        //StartCoroutine(getMMana(20));
        StartCoroutine(RandomChest());
        StartCoroutine(RandomEmemy());
        
    }

    
    IEnumerator getMMana(int manaIteration)
    {
        int difference;
        while (true)
        {
            difference = PlayerController.instance.plF.maxMana - PlayerController.instance.plF.mana;
            if (manaIteration > difference)
            {
                PlayerController.instance.plF.mana += difference;
                yield return null;
            }
            else
                CreateRandomEnemy();
                PlayerController.instance.plF.mana += manaIteration;
                yield return new WaitForSeconds(3);
        }
    }

    public void CreateRandomEnemy()
    {
            Vector3 point = new Vector3(Random.Range(-17, 17), Random.Range(-8, 8), 0) + transform.position;
            Instantiate(enemy, point, Quaternion.Euler(new Vector3(0f, 0f, 0f)));     
    }

    public void CreateRandomChest()
    {  
            Vector3 point = new Vector3(Random.Range(-17, 17), Random.Range(-8, 8), 0) + transform.position;
            Instantiate(chest, point, Quaternion.Euler(new Vector3(0f, 0f, 0f)));  
    }

    IEnumerator RandomChest()
    {
        while (true)
        {
            CreateRandomChest();
            yield return new WaitForSeconds(4);
        }
    }

    IEnumerator RandomEmemy()
    {
        while (true)
        {
            CreateRandomEnemy();
            yield return new WaitForSeconds(4);
        }
    }






}
