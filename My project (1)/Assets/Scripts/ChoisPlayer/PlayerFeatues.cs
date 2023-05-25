using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player/Create new Player")]
public class PlayerFeatues : ScriptableObject
{
    public int hp;
    public int maxHp;
    public int mana;
    public int maxMana;
    public int maxDamage;
    public int moveSpeed;
    public int attackSpeed;
    public int manaRegen;
    public int manaCoast;

    public Sprite skin;
    public GameObject prefPlayer;
    public Animator playerAnimator;
}
