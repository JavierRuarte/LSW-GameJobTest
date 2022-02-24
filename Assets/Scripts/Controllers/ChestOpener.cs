using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    [SerializeField] private bool chestOpen;
    [SerializeField]private bool blockChest;
    [SerializeField]private Animator chestAnimation;
    [SerializeField]private int moneyOfChest;

    private void Start()
    {
        chestAnimation = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!blockChest && other.gameObject.GetComponent<PlayerController>() && !chestOpen)
        {
            if (Input.GetKey(KeyCode.E))
            {
                chestOpen = true;
                chestAnimation.SetBool("isOpening", true);
                GameController.instance.GiveMoneyToPlayer(moneyOfChest);
            }
        }
    }

    /*private void OnCollisionStay2D(Collision2D other)
    {
        if (!blockChest && other.gameObject.GetComponent<PlayerController>())
        {
            if (Input.GetKey(KeyCode.E))
            {
                chestAnimation.SetBool("isOpening", true);
            }
        }
    }*/
}
