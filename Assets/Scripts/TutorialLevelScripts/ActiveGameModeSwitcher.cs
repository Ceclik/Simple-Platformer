using System;
using MenuHandlers.LoseMenu;
using UnityEngine;

namespace TutorialLevelScripts
{
    public class ActiveGameModeSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject heartsPanel;
        [SerializeField] private GameObject coinsText;

        [Space(10)] [SerializeField] private GameObject cameraLoseBorder;
        [SerializeField] private GameObject airParticles;
        [SerializeField] private GameObject windParticles;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
                ActivateGameMode();
        }

        private void ActivateGameMode()
        {
            heartsPanel.SetActive(true);
            coinsText.SetActive(true);
            cameraLoseBorder.SetActive(true);
            
            /*windParticles.SetActive(true);
            airParticles.SetActive(false);*/
        }

        private void DeactivateGameMode()
        {
            heartsPanel.SetActive(false);
            coinsText.SetActive(false);
            cameraLoseBorder.SetActive(false);
            
            windParticles.SetActive(false);
            airParticles.SetActive(true);
        }
    }
}
