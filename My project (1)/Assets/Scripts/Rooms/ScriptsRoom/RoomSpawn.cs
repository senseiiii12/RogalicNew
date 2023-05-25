using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public int Direction;
    private Rooms templates;
    private int rand;
    public bool spawned = false;
    float waitTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Rooms>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        if (spawned == false)
        {
            if(Direction == 1)
            {
                rand = Random.Range(0, templates.topRooms.Length );
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (Direction == 2)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (Direction == 3)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (Direction == 4)
            {
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            if (!spawned)
            {
                //Instantiate(templates.closedRoom,transform.position, Quaternion.identity);
                Destroy(gameObject); 
            }
            spawned = true;
        }
    }

    
}
