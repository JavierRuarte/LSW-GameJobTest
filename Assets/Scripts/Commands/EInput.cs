using System;
using UnityEngine;

public class EInput : Command
{
    private readonly Transform playerTransform;

    private readonly Func<float> speedOfPlayer;
    private readonly Func<bool> playerCanMove;
    public EInput(Transform transform, Func<float> speed, Func<bool> canMove)
    {
        playerTransform = transform;
        speedOfPlayer = speed;
        playerCanMove = canMove;
    }

    public KeyCode KeyCode => KeyCode.E;
    
    public void Execute()
    {
        if (playerCanMove.Invoke())
        {
            playerTransform.position += new Vector3(0,speedOfPlayer.Invoke()* 1) * Time.deltaTime;
        }
    }
}
