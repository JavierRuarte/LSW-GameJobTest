using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float speedOfMovement;
    [SerializeField]private bool canMove;
    private readonly List<ICommand> commands = new List<ICommand>();
    private readonly List<ICommand> oneUsecommands = new List<ICommand>();

    [Header("Player References")]
    [SerializeField] private PlayerAnimations pAnim;
    [SerializeField] private UIController uiController;
    // Start is called before the first frame update
    void Start()
    {
        uiController = FindObjectOfType<UIController>();
        commands.Add(new AInput(transform, ()=> speedOfMovement, ()=> canMove));
        commands.Add(new DInput(transform, ()=> speedOfMovement, ()=> canMove));
        commands.Add(new SInput(transform, ()=> speedOfMovement, ()=> canMove));
        commands.Add(new WInput(transform, ()=> speedOfMovement, ()=> canMove));
        oneUsecommands.Add(new IInput(uiController));
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

        foreach (var command in oneUsecommands)
        {
            if (Input.GetKeyDown(command.KeyCode))
            {
                command.Execute();
            }
        }
    }
}
