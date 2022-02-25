using UnityEngine;

namespace Commands
{
    public class IInput : ICommand
    {
        private readonly UIController inventory;
        public IInput(UIController playerInventory)
        {
            inventory = playerInventory;
        }

        public KeyCode KeyCode => KeyCode.I;
    
        public void Execute()
        {
            inventory.ShowOrHidePlayerInventory();
        }
    }
}
