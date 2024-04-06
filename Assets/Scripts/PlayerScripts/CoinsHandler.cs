using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class CoinsHandler : MonoBehaviour
    {
        [SerializeField] private Transform coinsParent;
        
        [Space(10)]
        [SerializeField] private Text coinsText;
        
        private int _coinsCounter;
        private GameObject[] _coins;

        public int CoinsCount
        {
            get => _coinsCounter;
        }

        private void Start()
        {
            _coins = new GameObject[coinsParent.childCount];
            for (int i = 0; i < coinsParent.childCount; i++)
                _coins[i] = coinsParent.GetChild(i).gameObject;
            
            _coinsCounter = 0;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                _coinsCounter++;
                coinsText.text = $"Coins: {_coinsCounter}";
                other.gameObject.SetActive(false);
            }
        }

        public void Restart()
        {
            _coinsCounter = 0;
            coinsText.text = $"Coins: {_coinsCounter}";
            foreach (var coin in _coins)
                coin.SetActive(true);
        }
    }
}
