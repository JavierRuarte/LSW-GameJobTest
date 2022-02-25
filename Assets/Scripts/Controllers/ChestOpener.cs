using UnityEngine;

namespace Controllers
{
    public class ChestOpener : MonoBehaviour
    {
        [SerializeField] private bool chestOpen;
        [SerializeField]private bool blockChest;
        [SerializeField]private Animator chestAnimation;
        [SerializeField]private int moneyOfChest;

        private void Start()
        {
            chestAnimation = GetComponent<Animator>();
        }

        //Detect when the player is close, check if the chest can be opened and give the player money
        private void OnTriggerStay2D(Collider2D other)
        {
            if (!blockChest && other.gameObject.GetComponent<PlayerController>() && !chestOpen)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    chestOpen = true;
                    chestAnimation.SetBool("isOpening", true);
                    GameController.instance.GiveMoneyToPlayer(moneyOfChest);
                }
            }
        }
    }
}
