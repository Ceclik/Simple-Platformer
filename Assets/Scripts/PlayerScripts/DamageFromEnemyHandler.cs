using UnityEngine;

namespace PlayerScripts
{
    public class DamageFromEnemyHandler : MonoBehaviour
    {
        private LoseAndWinHandler _loseAndWinHandler;
        private HeartsHandler _heartsHandler;

        private void Start()
        {
            _loseAndWinHandler = GetComponent<LoseAndWinHandler>();
            _heartsHandler = GetComponent<HeartsHandler>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _loseAndWinHandler.GetEnemyDamage();
                _heartsHandler.EmptyHalfHeart();
            }
        }
    }
}
