using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;

    [SerializeField] private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        money.text = "Money: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualizationOfUi()
    {
        money.text = "Money: " + player.amountOfMoney;
    }
}
