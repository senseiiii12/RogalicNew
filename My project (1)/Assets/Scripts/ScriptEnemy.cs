using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
//using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptEnemy : MonoBehaviour
{
    public static ScriptEnemy enemyInstance;
    public int health = 100;
    public GameObject pref;
    GameObject player;
    public float force;
    public float cooldown;
    public GameObject prefCoin;
    public GameObject prefGraveStone;
    public GameObject prefBottle_heal;
    public GameObject prefBottle_mana;
    public GameObject key;
    public GameObject XP;


    public int minDamage;
    public int maxDamage;
    PlayerStats stats;

    public GameObject hBarEnemy;
    public Slider hBarEnemySlider;


    // Start is called before the first frame update
    void Start()
    {
        enemyInstance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("enemyShooting", cooldown, cooldown);
    }

    // Update is called once per frame
    void Update()
    {
        hBarEnemySlider.value = health;
    }
    public void TakeDamage(int damage)
    {
        hBarEnemy.SetActive(true);
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerController.instance.plF.killCount += 1;
        Instantiate(prefGraveStone, gameObject.transform.position, Quaternion.identity);
        int random = UnityEngine.Random.Range(0,100);
        if(random <= 5)
        {
            Instantiate(key, transform.position + new Vector3(-1f,1f,0), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
        }
        CreateXP();
        Destroy(gameObject);
    }

    void enemyShooting()
    {
        GameObject spell = Instantiate(pref, transform.position, Quaternion.identity);
        Vector2 mPosition = player.GetComponent<Transform>().position;
        Vector2 myPosition = transform.position;
        Vector2 direction = mPosition - myPosition;
        spell.GetComponent<Rigidbody2D>().velocity = direction * force;
        Destroy(spell, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        PlayerMove player = collision.GetComponent<PlayerMove>();
        if (player != null)
        {
            PlayerController.instance.getDamage(damage); 
        }
    }


    public void CreateXP()
    {
        int random = UnityEngine.Random.Range(1, 5);
        for (int i = 0; i < random; i++)
        {           
            Vector3 point = (UnityEngine.Random.insideUnitSphere * 2) + transform.position;
            Instantiate(XP, point, Quaternion.Euler(new Vector3(0f, 0f, 0f)));                   
        }
    }


}
