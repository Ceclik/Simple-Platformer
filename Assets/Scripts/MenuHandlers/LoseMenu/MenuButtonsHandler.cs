using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuHandlers.LoseMenu
{
    public class MenuButtonsHandler : MonoBehaviour
    {
        [SerializeField] private GameObject loseMenu;
        [SerializeField] private GameObject winMenu;
        

        public void OnRestartButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            SceneManager.LoadScene("TestLevel");
        }
    }
}