using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] _shopItems = new int[6, 2];
    public float _crystaShards;
    public Text MoneyText;
    // Start is called before the first frame update
    void Start()
    {
        MoneyText.text = "Shards: " + _crystaShards.ToString();

        // ItemID
        _shopItems[1, 1] = 1;
        _shopItems[1, 2] = 2;

        // Price
        _shopItems[2, 1] = 3;
        _shopItems[2, 2] = 4;

        // Ammount Bought
        _shopItems[3, 1] = 5;
        _shopItems[3, 2] = 6;
    }

    // Update is called once per frame
    public void Purchase()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        //if (_crystaShards >= _shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            //_crystaShards -= _shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            //_shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;

            // Update text on UI
            //MoneyText.text = "Shards: " + _crystaShards.ToString();
            //ButtonRef.GetComponent<ButtonInfo>().QuantityText.text = _shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }
}
