using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_SpellUse : MonoBehaviour
{
    public D_Spell_Ability_enum skill;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseSkill();
        }
    }


    public void UseSkill()
    {
        GameObject spell = Instantiate(D_SpellController.d_instance.skillItems[0].prefabSkill, player.transform.position, Quaternion.identity);
        Vector2 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPosition = player.transform.position;
        Vector2 direction = mPosition - myPosition;
        spell.GetComponent<Rigidbody2D>().velocity = direction * D_SpellController.d_instance.skillItems[0].forceSkill;
        Destroy(spell, 2);
        
    }
}
