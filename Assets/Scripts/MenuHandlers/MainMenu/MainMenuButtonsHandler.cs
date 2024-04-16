using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuHandlers.MainMenu
{
    public class MainMenuButtonsHandler : MonoBehaviour
    {
        [SerializeField] private GameObject levelsPanel;
        
        public void OnPlayButtonClick()
        {
            levelsPanel.SetActive(true);
        }

        public void OnCloseLevelsPanelButtonClick()
        {
            levelsPanel.SetActive(false);
        }

        public void OnFirstLevelButtonClick()
        {
            SceneManager.LoadScene("TutorialLevel");
        }

        public void OnSecondLevelButtonClick()
        {
            SceneManager.LoadScene("TestLevel");
        }
    }
}
