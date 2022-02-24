using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator[] animsController;

    [SerializeField] private PlayerController pController;
    // Start is called before the first frame update
    void Start()
    {
        animsController = GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
