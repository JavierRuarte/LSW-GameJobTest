using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator[] animsController;

    [SerializeField] private PlayerController pController;
    void Start()
    {
        animsController = GetComponentsInChildren<Animator>();
        pController = FindObjectOfType<PlayerController>();
    }
    
    void Update()
    {
        
    }

    //Play animations depending of witch direction is the player going
    public void CheckForActionsAnimations(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.A:
                foreach (var parameter in animsController)
                {
                    parameter.SetFloat("sideSpeed", 0.2f);
                    parameter.SetFloat("frontSpeed", 0);
                    parameter.SetFloat("backSpeed", 0);
                }
                break;
            case KeyCode.D:
                foreach (var parameter in animsController)
                {
                    parameter.SetFloat("sideSpeed", 0.2f);
                    parameter.SetFloat("frontSpeed", 0);
                    parameter.SetFloat("backSpeed", 0);
                }
                break;
            case KeyCode.W:
                foreach (var parameter in animsController)
                {
                    parameter.SetFloat("sideSpeed", 0);
                    parameter.SetFloat("frontSpeed", 0);
                    parameter.SetFloat("backSpeed", 0.2f);
                }
                break;
            
            case KeyCode.S:
                foreach (var parameter in animsController)
                {
                    parameter.SetFloat("sideSpeed", 0);
                    parameter.SetFloat("frontSpeed", 0.2f);
                    parameter.SetFloat("backSpeed", 0);
                }
                break;
        }
    }
}
