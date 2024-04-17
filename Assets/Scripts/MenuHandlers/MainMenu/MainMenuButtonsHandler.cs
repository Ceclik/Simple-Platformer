using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuHandlers.MainMenu
{
    public class MainMenuButtonsHandler : MonoBehaviour
    {
        [SerializeField] private GameObject levelsPanel;
        [SerializeField] private GameObject titleText;
        
        public void OnPlayButtonClick()
        {
            levelsPanel.SetActive(true);
            titleText.SetActive(false);
        }

        public void OnCloseLevelsPanelButtonClick()
        {
            levelsPanel.SetActive(false);
            titleText.SetActive(true);
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
