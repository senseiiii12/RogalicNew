using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana_bottle : MonoBehaviour
{
    public int mana;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            PlayerController.instance.getMana(mana);
            Destroy(gameObject);
        }
    }
}
