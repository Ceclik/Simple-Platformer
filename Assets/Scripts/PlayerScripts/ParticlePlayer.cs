using UnityEngine;

namespace PlayerScripts
{
    public class ParticlePlayer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] jumpEffect;

        private int index = 0;
        public void PlayJumpEffect()
        {
            if (index == 2) index = 0;
            jumpEffect[index].transform.position = transform.position;
            jumpEffect[index].Play();
            index++;
        }
    }
}
