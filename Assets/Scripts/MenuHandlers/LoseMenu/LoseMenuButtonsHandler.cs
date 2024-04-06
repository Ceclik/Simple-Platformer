using PlayerScripts;
using UnityEngine;

namespace MenuHandlers.LoseMenu
{
    public class LoseMenuButtonsHandler : MonoBehaviour
    {
        private LoseAndWinHandler _loseAndWinHandler;
        [SerializeField] private GameObject loseMenu;

        private void Start()
        {
            _loseAndWinHandler =
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<LoseAndWinHandler>();
        }

        public void OnRestartButtonClick()
        {
            _loseAndWinHandler.Restart();
            loseMenu.SetActive(false);
        }

        public void OnExitButtonClick()
        {
            /*TODO*/
            Debug.Log("Exit button clicked!");
        }
    }
}
