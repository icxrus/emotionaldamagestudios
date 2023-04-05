using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFInventory;

public class NewShopManager : MonoBehaviour
{
    // Text displaying player´s money
    public Text _playerMoney;
    // Boolena fro testing if player has enough money to do a purchase
    [SerializeField] private bool _hasMoney;
    // Int saving the ammount player has.
    public int _playerOwnedMoney;

    // Method used to by item
    public void PurcahaseItem()
    {
        if (_hasMoney == true)
        {

        }
        //Move to inventory
        //Reduce money
        //Save inventory automatically
        
        //Update sprites
        _playerMoney.text = "Shards: " + _playerOwnedMoney.ToString();
    }

    // Method used to chek if player has enough money
    public void CheckMoney()
    {
        //Get the money from save
        //Get cost of item from store
        //Compare ammount
        //Returnn boolean
    }
    public SFInventoryItem[] testItems;
    public int addCount = 1;
    private SFInventoryManager inventoryManager;
    public int _itemPointer;
    void Start()
    {
        inventoryManager = GetComponent<SFInventoryManager>();
    }

    //here all the numbers of the button that are pressed will be converted to an integer and with this number you will add the item to your inventory
    void AddItemToInventory()
    {
        //[UNCOMMENT]inventoryManager.AddItemsCount(_itemPointer, addCount, out int left);
        //if there is not enough space in your inventory, you will get the remaining number of items back
        //if (left > 0)
            Debug.Log("Not Enough Inventory Space");
    }
}
