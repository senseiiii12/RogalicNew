using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Item item;
    

    public void RemoveItem()
    {
        InventoryController.Instance.Remove(item);
        Destroy(gameObject);
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
    }
    public void UseItem()
    {
        switch (item.type)
        {
            case Item.ItemType.PotionHeal:
                PlayerStats.plStats.getHeal(item.value);
                RemoveItem();
                break;
            case Item.ItemType.PotionMana:
                PlayerStats.plStats.getMana(item.value);
                RemoveItem();
                break;
            case Item.ItemType.Weapon:
                PlayerStats.plStats.maxDamage += item.value;
                RemoveItem();
                break;
            case Item.ItemType.OverSpeed:
                PlayerStats.plStats.speed += item.value;
                RemoveItem();
                break;
        }
    }

    public void ByItemShop()
    {
        if (PlayerStats.plStats.bitCoins >= item.price)
        {
            PlayerStats.plStats.bitCoins -= item.price;
            InventoryController.Instance.Add(item);
        }   
    }


    public void DropItem()
    {
            Vector3 point = (UnityEngine.Random.insideUnitSphere * 5) + PlayerStats.plStats.player.transform.position;
            Instantiate(item.prefab, point, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
            InventoryController.Instance.Remove(item);
            Destroy(gameObject);
    }


   
}
