using PlatformScripts;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace PlayerScripts
{
    public class LoseAndWinHandler : MonoBehaviour
    {
        [SerializeField] private Transform firstPlatform;
        [SerializeField] private Transform platformsParent;

        [Space(20)]
        [SerializeField] private GameObject loseMenu;
        [SerializeField] private GameObject winMenu;
        
        private GameObject[] _platforms;

        private GameValuesSetter _values;
        private int _livesCounter;
        private HeartsHandler _heartsHandler;
        private CoinsHandler _coinsHandler;
        
        private void Start()
        {
            _values = GameObject.Find("GameValues").GetComponent<GameValuesSetter>();
            _values.IsLosingHeart = false;
            _livesCounter = 3;
            _platforms = new GameObject[platformsParent.childCount];
            for (int i = 0; i < platformsParent.childCount; i++)
                _platforms[i] = platformsParent.GetChild(i).gameObject;
            _heartsHandler = GetComponent<HeartsHandler>();
            _coinsHandler = GetComponent<CoinsHandler>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Win"))
            {
                Debug.Log("You Win!");
                _values.IsWin = true;
                winMenu.SetActive(true);

            }
            if (other.gameObject.CompareTag("Lose") && _livesCounter > 0)
            {
                _livesCounter--;
                _values.IsLosingHeart = true;
                transform.position = firstPlatform.position;
                foreach (var item in _platforms)
                    if(item.TryGetComponent(out CameraMovementTrigger trigger))
                        if (trigger.IsJumped)
                            trigger.IsJumped = false;
                _heartsHandler.EmptyHeart();
                if (_livesCounter == 0)
                {
                    loseMenu.SetActive(true);
                    _values.IsLost = true;
                }
            }
        }

        public void Restart()
        {
            if (transform.position != firstPlatform.position)
                transform.position = firstPlatform.position;
            _heartsHandler.MakeAllHeartsRed();
            _coinsHandler.Restart();
            _livesCounter = 3;
            _values.IsLost = false;
            _values.IsWin = false;
        }
        
    }
}