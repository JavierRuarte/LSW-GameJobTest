using UnityEngine;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance;
        [SerializeField] private UIController uiController;
        public int amountOfMoney;
        [SerializeField] private PlayerController player;

        [SerializeField] private bool gameOver;
        void Start()
        {
            instance = this;
            uiController = FindObjectOfType<UIController>();
            player = FindObjectOfType<PlayerController>();
            player.canMove = false;
        }

        public void TutorialClosed()
        {
            player.canMove = true;
        }

        //Call actualization for the UI
        private void CallUIActualization()
        {
            uiController.ActualizationOfUi();
        }

        //Change the amount of money of the player
        public void GiveMoneyToPlayer(int money)
        {
            amountOfMoney = amountOfMoney + money;
            CallUIActualization();
        }

        public void UseCoins(int amount)
        {
            amountOfMoney -= amount;
        }

        public bool HasEnoughCoins(int amount)
        {
            return (amountOfMoney >= amount);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
