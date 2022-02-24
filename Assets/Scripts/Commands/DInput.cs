using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DInput : Command
{
    private readonly Transform playerTransform;

    private readonly Func<float> speedOfPlayer;
    private readonly Func<bool> playerCanMove;
    public DInput(Transform transform, Func<float> speed, Func<bool> canMove)
    {
        playerTransform = transform;
        speedOfPlayer = speed;
        playerCanMove = canMove;
    }

    public KeyCode KeyCode => KeyCode.D;

    // Update is called once per frame
    public void Execute()
    {
        if (playerCanMove.Invoke())
        {
            playerTransform.position += new Vector3(speedOfPlayer.Invoke() * 1,0) * Time.deltaTime;
            playerTransform.transform.localScale = new Vector3(3, 3, 3);
        }
    }
}
