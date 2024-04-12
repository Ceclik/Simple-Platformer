using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuHandlers.LoseMenu
{
    public class MenuButtonsHandler : MonoBehaviour
    {
        [SerializeField] private GameObject loseMenu;
        [SerializeField] private GameObject winMenu;
        public delegate void RestartLevel();
        public event RestartLevel OnRestartLevel;

        public void OnRestartButtonClick()
        {
            OnRestartLevel?.Invoke();
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