using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFInventory.Demo
{
    public class SetPriceAndBuy : MonoBehaviour
    {
        [SerializeField] private GameObject ShopManager;
        [SerializeField] private int _itemTag = 2;
        public int _newItemPrice = 20;

        public void BuyAnItem()
        {
            int _newItemPrice =  ShopManager.GetComponent<TestItemsAdder>()._itemPrice;
        }
    }
}