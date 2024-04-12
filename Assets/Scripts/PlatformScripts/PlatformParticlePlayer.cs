using System.Collections;
using UnityEngine;

namespace PlatformScripts
{
    public class PlatformParticlePlayer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem cloudParticle;
        [SerializeField] private float particlePlayDelay;

        private bool _isPlay;
        private Vector3 _entityPosition;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _isPlay = true;
                _entityPosition =
                    new Vector3(other.transform.position.x, other.transform.position.y, -1.0f);
                StartCoroutine(CloudParticlePlay());
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _entityPosition =
                    new Vector3(other.transform.position.x, other.transform.position.y, -1.0f);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _isPlay = false;
            }
        }

        private IEnumerator CloudParticlePlay()
        {
            while (_isPlay)
            {
                yield return new WaitForSeconds(particlePlayDelay);
                cloudParticle.transform.position =
                    new Vector3(_entityPosition.x, _entityPosition.y - 0.5f, -1.0f);
                cloudParticle.Play();
            }
        }
    }
}
