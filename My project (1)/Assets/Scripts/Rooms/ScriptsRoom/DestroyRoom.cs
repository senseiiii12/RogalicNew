using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SpawnPoint")
        {
            Destroy(collision.gameObject);
        }
        
    }
}
