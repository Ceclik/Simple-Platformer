using UnityEngine;

namespace PlayerScripts
{
    public class ParticlePlayer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem doubleJumpEffect;
        public void PlayDoubleJumpEffect()
        {
            var requiredSpawnPosition =
                new Vector3(transform.position.x, transform.position.y, transform.position.z);
            doubleJumpEffect.transform.position = requiredSpawnPosition;
            doubleJumpEffect.Play();
        }
    }
}
