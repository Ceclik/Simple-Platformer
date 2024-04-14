using System.Collections;
using UnityEngine;

namespace PlayerScripts
{
    public class EnemiesKiller : MonoBehaviour
    {
        [SerializeField] private float enemyDeathDelay;

        [Space(10)] [SerializeField] private ParticleSystem enemyKillEffect;

        private GameObject _enemy;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.parent.gameObject.CompareTag("Enemy"))
            {
                _enemy = other.transform.parent.gameObject;
                enemyKillEffect.transform.position = _enemy.transform.position;
                enemyKillEffect.Play();
                StartCoroutine(EnemyDeath());
            }
        }

        private IEnumerator EnemyDeath()
        {
            yield return new WaitForSeconds(enemyDeathDelay);
            _enemy.SetActive(false);
        }
    }
}
