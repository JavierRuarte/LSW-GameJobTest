using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   #region Singleton:Inventory

   public static Inventory instance;

   private void Awake()
   {
      if (instance ==null)
      {
          instance = this;
      }
      else
      {
          Destroy(gameObject);
      }
   }

   #endregion

   public class Avatar
   {
       public Sprite image;
   }

   public List<Avatar> avatarList;

   [SerializeField] private GameObject avatarUITemplate;
   [SerializeField] private Transform avatarsScrollView;
   [SerializeField] private ShopController shopController;
   [SerializeField] private GameObject g;

   private int newSelectedIndex, previousSelectedIndex;
   [SerializeField] private Color activeAvatarColor;
   [SerializeField] private Color defaultAvatarColor;
   [SerializeField] private Image currentAvatar;
   [SerializeField] private PlayerController player;

   private void Start()
   {
       GetAvailableAvatars();
   }

   void GetAvailableAvatars()
   {
       for (int i = 0; i < shopController.shopItemsList.Count; i++) //get the avatars from the shop
       {
           if (shopController.shopItemsList[i].isPurchased)
           {
               //this add all purchased avatars to avatarList
               AddAvatar(shopController.shopItemsList[i].image, shopController.shopItemsList[i].typeOfSkin);

           }
       }
       SelectedAvatar("normalSkin", newSelectedIndex);
   }

   public void AddAvatar(Sprite img, string typeOfSkin)
   {
       
       if (avatarList == null)
       {
           avatarList = new List<Avatar>();
       }
       Debug.Log("Se llamo a crear avatar en el inventario");
       Avatar av = new Avatar(){image = img};
           
       //Add avatar to avatarList
       avatarList.Add(av);
           
       //Add avatar in the UI Scroll View
       g = Instantiate(avatarUITemplate, avatarsScrollView);
       g.transform.GetChild(0).GetComponent<Image>().sprite = av.image;

       g.transform.GetComponent<Button>()
           .onClick.AddListener(() => OnAvatarClick(typeOfSkin, avatarList.Count - 1));
   }

   void OnAvatarClick(string typeOfSkin, int avatarIndex)
   {
       SelectedAvatar(typeOfSkin, avatarIndex);
   }

   void SelectedAvatar(string typeOfSkin, int avatarIndex)
   {
       previousSelectedIndex = newSelectedIndex;
       newSelectedIndex = avatarIndex;
       avatarsScrollView.GetChild(previousSelectedIndex).GetComponent<Image>().color = defaultAvatarColor;
       avatarsScrollView.GetChild(newSelectedIndex).GetComponent<Image>().color = activeAvatarColor;

       currentAvatar.sprite = avatarList[newSelectedIndex].image;
       player.GetComponent<PlayerAnimations>().CheckForSkin(typeOfSkin);
   }

   void SellItem()
   {
       if (player.canSellItem)
       {
           Debug.Log("Player can sell the item");
       }
       else
       {
           Debug.Log("Player can't sell the item");
       }
   }
}
