using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreUIController : MonoBehaviour
{
    [SerializeField] private GameObject shopUi;

    [SerializeField] private bool canOpenShop;
    // Start is called before the first frame update
    void Start()
    {
        shopUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OpenAndCloseShop();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("player is in the zone");
            canOpenShop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        shopUi.SetActive(false);
        canOpenShop = false;
    }

    private void OpenAndCloseShop()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpenShop)
        {
            shopUi.SetActive(true);
        }
        else if(shopUi.activeSelf && Input.GetKeyDown(KeyCode.P))
        {
            shopUi.SetActive(false);
        }
    }
}
