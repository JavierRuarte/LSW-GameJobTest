using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float speedOfMovement;
    [SerializeField]private bool canMove;
    private readonly List<ICommand> commands = new List<ICommand>();

    [Header("Player Stats")]
    [SerializeField] private PlayerAnimations pAnim;
    // Start is called before the first frame update
    void Start()
    {
        commands.Add(new AInput(transform, ()=> speedOfMovement, ()=> canMove));
        commands.Add(new DInput(transform, ()=> speedOfMovement, ()=> canMove));
        commands.Add(new SInput(transform, ()=> speedOfMovement, ()=> canMove));
        commands.Add(new WInput(transform, ()=> speedOfMovement, ()=> canMove));
        pAnim = FindObjectOfType<PlayerAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Movements();
        }
    }

    //All the movements and actions of the player are here
    void Movements()
    {
        foreach (var command in commands)
        {
            if (Input.GetKey(command.KeyCode))
            {
                command.Execute();
                pAnim.CheckForActionsAnimations(command.KeyCode);
            }
        }
    }
}
