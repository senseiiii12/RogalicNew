using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    //public static InventoryController Instance;
    public List<Item> items = new List<Item>();
    public Transform ItemContent;
    public GameObject shopItem;
    public ItemController[] inventoryItems;
    public GameObject shopPanel;

    public void ListItems()
    {

        foreach (Item item in items)
        {
            GameObject obj = Instantiate(shopItem, ItemContent);
            var itemName = obj.transform.Find("TextItem").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ImageItem").GetComponent<Image>();
            var itemprice = obj.transform.Find("PriceItem").GetComponent<Text>();
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            itemprice.text = item.value.ToString();
        }
        SetShopItems();
    }

    public void SetShopItems()
    {
        inventoryItems = ItemContent.GetComponentsInChildren<ItemController>();
        for (int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }
    public void clear()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            shopPanel.SetActive(true);
            ListItems();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            shopPanel.SetActive(false);
            
        }
    }
}
