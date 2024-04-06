using CameraScripts;
using PlayerScripts;
using UnityEngine;

namespace MenuHandlers.LoseMenu
{
    public class MenuButtonsHandler : MonoBehaviour
    {
        private LoseAndWinHandler _loseAndWinHandler;
        [SerializeField] private GameObject loseMenu;
        [SerializeField] private GameObject winMenu;

        [Space(20)] [SerializeField] private CameraMover cameraMover;

        private void Start()
        {
            _loseAndWinHandler =
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<LoseAndWinHandler>();
        }

        public void OnRestartButtonClick()
        {
            _loseAndWinHandler.Restart();
            loseMenu.SetActive(false);
            winMenu.SetActive(false);
            cameraMover.ResetCameraPosition();
        }

        public void OnExitButtonClick()
        {
            /*TODO*/
            Debug.Log("Exit button clicked!");
        }

        public void OnNextLevelButtonClick()
        {
            /*TODO*/
            Debug.Log("Next level button clicked!");
        }
    }
}
