using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float speedOfMovement;
    [SerializeField]private bool canMove;
    private readonly List<Command> commands = new List<Command>();
    // Start is called before the first frame update
    void Start()
    {
        commands.Add(new AInput(transform, ()=> speedOfMovement, ()=> canMove));
        commands.Add(new DInput(transform, ()=> speedOfMovement, ()=> canMove));
        commands.Add(new SInput(transform, ()=> speedOfMovement, ()=> canMove));
        commands.Add(new WInput(transform, ()=> speedOfMovement, ()=> canMove));
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Movements();
        }
    }

    void Movements()
    {
        foreach (var command in commands)
        {
            if (Input.GetKey(command.KeyCode))
            {
                command.Execute();
            }
        }
    }
}
