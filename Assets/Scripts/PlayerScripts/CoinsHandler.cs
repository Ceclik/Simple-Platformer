using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class CoinsHandler : MonoBehaviour
    {
        [SerializeField] private Text coinsText;
        
        private int _coinsCounter;

        private void Start()
        {
            _coinsCounter = 0;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                _coinsCounter++;
                coinsText.text = $"Coins: {_coinsCounter}";
                other.gameObject.SetActive(false);
            }
        }
    }
}
