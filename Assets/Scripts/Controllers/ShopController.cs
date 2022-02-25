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
    public class ShopItem
    {
        public Sprite image;
        public int price;
        public bool isPurchased = false;
        public string typeOfSkin;
    }

    public List<ShopItem> shopItemsList;
    [SerializeField] private Animator noCoinAnim;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject itemTemplate;
    private GameObject gObject;
    [SerializeField] private Transform shopScrollView;
    private Button buyButton;
    private Button closeButton;
    [SerializeField] private Inventory playerInventory;

    private void Start()
    {
        int len = shopItemsList.Count;
        for (int i = 0; i < len; i++)
        {
            gObject = Instantiate(itemTemplate, shopScrollView);
            gObject.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsList[i].image;
            gObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = shopItemsList[i].price.ToString();
            buyButton = gObject.transform.GetChild(2).GetComponent<Button>();
            buyButton.interactable = !shopItemsList[i].isPurchased;
            if (shopItemsList[i].isPurchased)
            {
                DisableBuyButton();
            }
            buyButton.AddEventListener(i,OnShopButtonClicked);
           
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
            DisableBuyButton();
            SetCoinsInUI();
            
            //Add avatar to inventory
            playerInventory.AddAvatar( shopItemsList[itemIndex].image, shopItemsList[itemIndex].typeOfSkin);
        }
        else
        {
            Debug.Log("You dont have enough gold!!!");
            noCoinAnim.SetTrigger("noGold");
        }
    }

    void DisableBuyButton()
    {
        buyButton.interactable = false;
        buyButton.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
    }

    public void SetCoinsInUI()
    {
        coinText.text = GameController.instance.amountOfMoney.ToString();
    }

    public void IsSellingItems()
    {
        
    }
}
