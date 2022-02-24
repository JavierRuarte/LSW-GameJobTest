using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private UIController uiController;
    [SerializeField] private int lives;
    [SerializeField] private PlayerController player;

    [SerializeField] private bool gameOver;
    void Start()
    {
        instance = this;
        uiController = FindObjectOfType<UIController>();
        player = FindObjectOfType<PlayerController>();
    }
    
    
    void Update()
    {
        
    }

    //Call actualization for the UI
    private void CallUIActualization()
    {
        uiController.ActualizationOfUi();
    }

    //Change the amount of money of the player
    public void GiveMoneyToPlayer(int money)
    {
        player.amountOfMoney = player.amountOfMoney + money;
        CallUIActualization();
    }
}
