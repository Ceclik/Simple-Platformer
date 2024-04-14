using System.Collections;
using UnityEngine;

namespace PlayerScripts
{
    public class EnemiesKiller : MonoBehaviour
    {
        [SerializeField] private float enemyDeathDelay;

        [Space(10)] 

        private GameObject _enemy;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.parent.gameObject.CompareTag("Enemy"))
            {
                _enemy = other.transform.parent.gameObject;
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
