using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    private GameObject itenmTemplate;
    private GameObject gObject;
    [SerializeField] private Transform shopScrollView;

    private void Start()
    {
        itenmTemplate = shopScrollView.GetChild(0).gameObject;
        for (int i = 0; i < 10; i++)
        {
            gObject = Instantiate(itenmTemplate, shopScrollView);
        }
        Destroy(itenmTemplate);
    }
}
