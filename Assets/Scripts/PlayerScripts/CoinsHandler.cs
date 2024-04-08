using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class CoinsHandler : MonoBehaviour
    {
        [SerializeField] private Transform coinsParent;

        [Space(10)] [SerializeField] private Text coinsText;

        private GameObject[] _coins;
        public int CoinsCount { get; private set; }

        private void Start()
        {
            _coins = new GameObject[coinsParent.childCount];
            for (var i = 0; i < coinsParent.childCount; i++)
                _coins[i] = coinsParent.GetChild(i).gameObject;

            CoinsCount = 0;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                CoinsCount++;
                coinsText.text = $"Coins: {CoinsCount}";
                other.gameObject.SetActive(false);
            }
        }

        public void Restart()
        {
            CoinsCount = 0;
            coinsText.text = $"Coins: {CoinsCount}";
            foreach (var coin in _coins)
                coin.SetActive(true);
        }
    }
}