using System;
using UnityEngine;

namespace PlayerScripts
{
    public class ParticlePlayer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] jumpEffect;
        [Space(10)][SerializeField] private ParticleSystem landEffect;

        private int index = 0;
        public void PlayJumpEffect()
        {
            if (index == 2) index = 0;
            jumpEffect[index].transform.position = transform.position;
            jumpEffect[index].Play();
            index++;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                Vector3 landPosition =
                    new Vector3(transform.position.x, transform.position.y - 0.35f, transform.position.z);
                landEffect.transform.position = landPosition;
                landEffect.Play();
            }
        }
    }
}
