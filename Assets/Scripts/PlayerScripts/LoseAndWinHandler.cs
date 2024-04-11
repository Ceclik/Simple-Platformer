using System;
using System.Linq;
using LevelScripts;
using MenuHandlers.LoseMenu;
using PlatformScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class LoseAndWinHandler : MonoBehaviour
    {
        [SerializeField] private Transform firstPlatform;
        [SerializeField] private Transform platformsParent;

        [Space(20)] [SerializeField] private GameObject loseMenu;
        [SerializeField] private GameObject winMenu;

        private GameObject[] _platforms;

        private GameValuesSetter _values;
        private float _livesCounter;
        private HeartsHandler _heartsHandler;
        private CoinsHandler _coinsHandler;

        private HeartsPicker _heartsPicker;
        
        private MenuButtonsHandler _buttonsHandler;

        private void Start()
        {
            _values = GameObject.Find("GameValues").GetComponent<GameValuesSetter>();
            _values.isLosingHeart = false;
            _livesCounter = 3;
            _platforms = new GameObject[platformsParent.childCount];
            for (var i = 0; i < platformsParent.childCount; i++)
                _platforms[i] = platformsParent.GetChild(i).gameObject;
            _heartsHandler = GetComponent<HeartsHandler>();
            _coinsHandler = GetComponent<CoinsHandler>();
            _heartsPicker = GetComponent<HeartsPicker>();

            _heartsPicker.OnPickHeart += AddLive;
            
            _buttonsHandler = GameObject.Find("ButtonsHandler").GetComponent<MenuButtonsHandler>();
            _buttonsHandler.OnRestartLevel += Restart;
        }

        private void OnDestroy()
        {
            _heartsPicker.OnPickHeart -= AddLive;
            _buttonsHandler.OnRestartLevel += Restart;
        }

        private void AddLive()
        {
            if (_livesCounter >= 3) return;
            if (_livesCounter % 1 == 0)
                _livesCounter++;
            else _livesCounter += 0.5f;
            Debug.Log($"Lives count: {_livesCounter}");
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Win"))
            {
                Debug.Log("You Win!");
                _values.isWin = true;
                winMenu.SetActive(true);
            }

            if (other.gameObject.CompareTag("Lose") && _livesCounter > 0.0f && !_values.isWin)
            {
                if (_livesCounter % 1 == 0)
                    _livesCounter--;
                else _livesCounter -= 0.5f;
                Debug.Log($"Lives count: {_livesCounter}");
                _values.isLosingHeart = true;
                
                BackToCheckPoint();
                UnjumpAllNextPlatforms();

                _heartsHandler.EmptyHeart();
                if (_livesCounter == 0.0f)
                {
                    loseMenu.SetActive(true);
                    _values.isLost = true;
                }
            }
        }

        private void BackToCheckPoint()
        {
            foreach (var platform in _platforms)
                if (platform.TryGetComponent(out CheckPoint checkPoint))
                    if (checkPoint.IsCurrentCheckPoint)
                        transform.position = checkPoint.transform.position;
        }

        public void Restart()
        {
            if (transform.position != firstPlatform.position)
                transform.position = firstPlatform.position;
            _heartsHandler.MakeAllHeartsRed();
            _coinsHandler.Restart();
            _livesCounter = 3.0f;
            _values.isLost = false;
            _values.isWin = false;

            UnjumpAllNextPlatforms();
        }

        private void UnjumpAllNextPlatforms()
        {
            foreach (var item in _platforms.Reverse())
            {
                if (item.TryGetComponent(out CheckPoint checkPoint))
                    if (checkPoint.IsCurrentCheckPoint)
                        break;
                if (item.TryGetComponent(out CameraMovementTrigger trigger))
                    if (trigger.IsJumped)
                        trigger.IsJumped = false;
            }
        }

        public void GetEnemyDamage()
        {
            _livesCounter -= 0.5f;
            Debug.Log($"Lives count: {_livesCounter}");
        }
    }
}