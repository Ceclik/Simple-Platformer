using UnityEngine;

namespace PlayerScripts
{
    public class ParticlePlayer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] jumpEffect;
        [Space(10)] [SerializeField] private ParticleSystem landEffect;
        [SerializeField] private ParticleSystem coinPickEffect;
        [SerializeField] private ParticleSystem damageEffect;
        [SerializeField] private ParticleSystem enemyKillEffect;

        private int _index;

        public void PlayJumpEffect()
        {
            if (_index == 2) _index = 0;
            jumpEffect[_index].transform.position = transform.position;
            jumpEffect[_index].Play();
            _index++;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                var landPosition =
                    new Vector3(transform.position.x, transform.position.y - 0.35f, transform.position.z);
                landEffect.transform.position = landPosition;
                landEffect.Play();
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                damageEffect.transform.position = transform.position;
                damageEffect.Play();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                coinPickEffect.transform.position = other.transform.position;
                coinPickEffect.Play();
            }

            if (other.transform.parent.gameObject.CompareTag("Enemy"))
            {
                enemyKillEffect.transform.position = other.transform.parent.transform.position;
                enemyKillEffect.Play();
            }
        }
    }
}