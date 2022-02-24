using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class ShopController : MonoBehaviour
{
    [System.Serializable]
    class ShopItem
    {
        public Sprite image;
        public int price;
        public bool isPurchased = false;
    }

    [SerializeField] private List<ShopItem> shopItemsList;
    private GameObject itenmTemplate;
    private GameObject gObject;
    [SerializeField] private Transform shopScrollView;
    private Button buyButton;

    private void Start()
    {
        itenmTemplate = shopScrollView.GetChild(0).gameObject;

        int len = shopItemsList.Count;
        for (int i = 0; i < len; i++)
        {
            gObject = Instantiate(itenmTemplate, shopScrollView);
            gObject.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsList[i].image;
            gObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = shopItemsList[i].price.ToString();
            buyButton = gObject.transform.GetChild(2).GetComponent<Button>();
            buyButton.interactable = !shopItemsList[i].isPurchased;
            buyButton.AddEventListener(i,OnShopButtonClicked);
        }
        Destroy(itenmTemplate);

        if (buyButton.interactable == false)
        {
            buyButton.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
        }
    }

    private void OnShopButtonClicked(int itemIndex)
    {
        if (GameController.instance.HasEnoughCoins(shopItemsList[itemIndex].price))
        {
            GameController.instance.UseCoins(shopItemsList[itemIndex].price);
            //purchase an item
            shopItemsList[itemIndex].isPurchased = true;
        
            //disable the button
            buyButton = shopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            buyButton.interactable = false;
            buyButton.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
        }
        
    }
}
