using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private int lives;

    [SerializeField] private bool gameOver;
    void Start()
    {
        instance = this;
    }
    
    
    void Update()
    {
        
    }
}
