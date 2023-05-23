using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_SpellUse : MonoBehaviour
{
    D_Spell_Ability_enum skill;
    GameObject player;
    private bool IsCoolDownSkill;
    Image img;

    private void Start()
    {
        img = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseSkill(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseSkill(1);
        }
    }


    public void UseSkill(int i)
    {
        if(PlayerStats.plStats.mana > 0)
        {
            PlayerStats.plStats.mana -= D_SpellController.d_instance.skillItems[i].ManaCoastSkill;
            GameObject spell = Instantiate(D_SpellController.d_instance.skillItems[i].prefabSkill, player.transform.position, Quaternion.identity);
            Vector2 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPosition = player.transform.position;
            Vector2 direction = mPosition - myPosition;
            spell.GetComponent<Rigidbody2D>().velocity = direction * D_SpellController.d_instance.skillItems[i].forceSkill;
            Destroy(spell, 2);
            D_SpellController.d_instance.skillItems[i].IsCoolDown = true;
            CoolDown(i);
        }   
    }

    public void CoolDown(int i)
    {
        
        img.sprite = D_SpellController.d_instance.skillItems[i].iconSkill;
        if (D_SpellController.d_instance.skillItems[i].IsCoolDown == true)
        {
            img.fillAmount += 1 / D_SpellController.d_instance.skillItems[i].kd * Time.deltaTime;
            if (img.fillAmount == 1)
            {
                D_SpellController.d_instance.skillItems[i].IsCoolDown = false;
            }
        }
    }
}
