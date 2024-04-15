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
        [SerializeField] private ParticleSystem airParticles;
        [SerializeField] private ParticleSystem windParticles;

        private MenuButtonsHandler _buttonsHandler;

        private void Start()
        {
            _buttonsHandler = GameObject.Find("ButtonsHandler").GetComponent<MenuButtonsHandler>();
            _buttonsHandler.OnRestartLevel += DeactivateGameMode;
        }

        private void OnDestroy()
        {
            _buttonsHandler.OnRestartLevel -= DeactivateGameMode;
        }

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
            windParticles.Stop();
            airParticles.Play();
        }

        private void DeactivateGameMode()
        {
            heartsPanel.SetActive(false);
            coinsText.SetActive(false);
            cameraLoseBorder.SetActive(false);
            windParticles.Play();
            airParticles.Stop();
        }
    }
}
