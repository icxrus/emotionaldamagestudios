using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFInventory;
using UnityEngine.UI;
using TMPro;

namespace SFInventory.Demo
{
    public class TestItemsAdder : MonoBehaviour
    {
        //THIS SCRIPT MUST REMAIN INSIDE INVENTORY PREFAB
        // TestItems[x] x=>0
        public SFInventoryItem[] testItems;
        public int addCount;
        public int shopItemTag;
        private SFInventoryManager inventoryManager;

        //Price handeling
        // Text displaying player´s money
        public TMP_Text _playerMoney;
        // Boolena fro testing if player has enough money to do a purchase
        [SerializeField] private bool _CanBuy;
        // Int saving the ammount player has.
        public int _playerOwnedMoney;
        public int _itemPrice;

        void Start()
        {
            inventoryManager = GetComponent<SFInventoryManager>();
        }
        void CheckMoney()
        {
            if(_playerOwnedMoney >= _itemPrice)
            {
                _CanBuy = true;
            }
            else { _CanBuy = false; }
        }

        public void AddItemToInventory()
        {
            CheckMoney();
            if (_CanBuy == true) 
            {
                // Coonects to inventory manager to add the item.
                inventoryManager.AddItemsCount(testItems[shopItemTag], addCount, out int left);
                //if there is not enough space in your inventory, you will get the remaining number of items back
                if (left > 0) { Debug.Log("Inventory overflow: " + left + " " + testItems[shopItemTag].Name); }

                // Remove money here
                _playerOwnedMoney -= _itemPrice;
                // Update Sprites
                _playerMoney.text = "Shards: " + _playerOwnedMoney.ToString();
            }
            else { Debug.Log("Not Enough Money"); }

        }
    }
}