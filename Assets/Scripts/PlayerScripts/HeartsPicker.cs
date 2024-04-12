using System;
using MenuHandlers.LoseMenu;
using UnityEngine;

namespace PlayerScripts
{
    public class HeartsPicker : MonoBehaviour
    {
        public delegate void HandlePickedHeart();
        public event HandlePickedHeart OnPickHeart;

        [SerializeField] private Transform heartsObjectsParent;
        
        private MenuButtonsHandler _buttonsHandler;

        private void Start()
        {
            _buttonsHandler = GameObject.Find("ButtonsHandler").GetComponent<MenuButtonsHandler>();
            _buttonsHandler.OnRestartLevel += ResetHearts;
        }

        private void OnDestroy()
        {
            _buttonsHandler.OnRestartLevel -= ResetHearts;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Heart"))
            {
                other.gameObject.SetActive(false);
                OnPickHeart?.Invoke();
            }
        }

        private void ResetHearts()
        {
            for(var i = 0; i < heartsObjectsParent.childCount; i++)
                heartsObjectsParent.GetChild(i).gameObject.SetActive(true);
        }
    }
}
