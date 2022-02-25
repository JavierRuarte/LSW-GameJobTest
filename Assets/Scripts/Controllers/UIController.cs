using TMPro;
using UnityEngine;

namespace Controllers
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private PlayerController player;

        [SerializeField] private GameObject inventory;
        [SerializeField] private GameObject tutorialPannel;
        [SerializeField] private TextMeshProUGUI goldText;

        [SerializeField] private bool inventoryIsOpen;
        // Start is called before the first frame update
        void Start()
        {
            player = FindObjectOfType<PlayerController>();
            goldText.text = "Money: 0";
            inventory.SetActive(false);
        }

        public void ActualizationOfUi()
        {
            goldText.text = "Money: " + GameController.instance.amountOfMoney;
        }

        public void CloseTutorial()
        {
            tutorialPannel.SetActive(false);
            GameController.instance.TutorialClosed();
        }

        public void ShowOrHidePlayerInventory()
        {
            if (!inventoryIsOpen)
            {
                inventory.SetActive(true);
                inventoryIsOpen = true;
            }
            else
            {
                inventory.SetActive(false);
                inventoryIsOpen = false;
            }
        }
    }
}
