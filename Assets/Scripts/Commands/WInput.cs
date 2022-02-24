using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WInput : ICommand
{
    private readonly Transform playerTransform;

    private readonly Func<float> speedOfPlayer;
    private readonly Func<bool> playerCanMove;
    public WInput(Transform transform, Func<float> speed, Func<bool> canMove)
    {
        playerTransform = transform;
        speedOfPlayer = speed;
        playerCanMove = canMove;
    }

    public KeyCode KeyCode => KeyCode.W;
    
    public void Execute()
    {
        if (playerCanMove.Invoke())
        {
            playerTransform.position += new Vector3(0,speedOfPlayer.Invoke()* 1) * Time.deltaTime;
        }
    }
}