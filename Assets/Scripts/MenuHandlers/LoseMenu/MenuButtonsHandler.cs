using CameraScripts;
using LevelScripts;
using PlayerScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuHandlers.LoseMenu
{
    public class MenuButtonsHandler : MonoBehaviour
    {
        private LoseAndWinHandler _loseAndWinHandler;
        [SerializeField] private GameObject loseMenu;
        [SerializeField] private GameObject winMenu;
        [SerializeField] private CheckpointsHandler checkpointsHandler;
        [SerializeField] private HeartsPicker heartsPicker;

        [Space(20)] [SerializeField] private CameraMover cameraMover;

        private void Start()
        {
            _loseAndWinHandler =
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<LoseAndWinHandler>();
        }

        public void OnRestartButtonClick()
        {
            checkpointsHandler.ResetAllCheckpoints();
            _loseAndWinHandler.Restart();
            cameraMover.ResetCameraPosition();
            heartsPicker.ResetHearts();
            loseMenu.SetActive(false);
            winMenu.SetActive(false);
        }

        public void OnExitButtonClick()
        {
            Debug.Log("Exit button clicked!");
            SceneManager.LoadScene("MainMenu");
        }

        public void OnNextLevelButtonClick()
        {
            /*TODO*/
            Debug.Log("Next level button clicked!");
        }
    }
}