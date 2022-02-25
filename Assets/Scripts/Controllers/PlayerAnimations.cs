using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator[] animsController;
    [SerializeField] private Animator feetAnimsController;

    [SerializeField] private PlayerController pController;
    private string lastSkin;

    void Start()
    {
        animsController = GetComponentsInChildren<Animator>();
        pController = FindObjectOfType<PlayerController>();
        lastSkin = "normalSkin";
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
                    //parameter.SetTrigger(lastSkin);
                }
                feetAnimsController.SetTrigger(lastSkin);
                break;
            case KeyCode.D:
                foreach (var parameter in animsController)
                {
                    parameter.SetFloat("sideSpeed", 0.2f);
                    parameter.SetFloat("frontSpeed", 0);
                    parameter.SetFloat("backSpeed", 0);
                    //parameter.SetTrigger(lastSkin);
                }
                feetAnimsController.SetTrigger(lastSkin);
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

    public void CheckForSkin(string skin)
    {
        foreach (var skinName in animsController)
        {
            skinName.SetTrigger(lastSkin);
        }

        lastSkin = skin;
        foreach (var skinName in animsController)
        {
            skinName.SetTrigger(skin);
        }
    }
}
