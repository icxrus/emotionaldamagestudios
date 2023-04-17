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
        public void BuyItem1()
        {
            shopItemTag = 0;
            _itemPrice = 10;
            AddItemToInventory();
        }
        public void BuyItem2()
        {
            shopItemTag = 1;
            _itemPrice = 2;
            AddItemToInventory();
        }
        public void BuyItem3()
        {
            shopItemTag = 2;
            _itemPrice = 3;
            AddItemToInventory();
        }
        public void BuyItem4()
        {
            shopItemTag = 3;
            _itemPrice = 25;
            AddItemToInventory();
        }
        public void BuyItem5()
        {
            shopItemTag = 4;
            _itemPrice = 5;
            AddItemToInventory();
        }
        public void BuyItem6()
        {
            shopItemTag = 5;
            _itemPrice = 20;
            AddItemToInventory();
        }
        public void BuyItem7()
        {
            shopItemTag = 6;
            _itemPrice = 35;
            AddItemToInventory();
        }
        public void BuyItem8()
        {
            shopItemTag = 7;
            _itemPrice = 30;
            AddItemToInventory();
        }
    }
}