using LevelScripts;
using PlayerScripts;
using UnityEngine;

namespace TutorialLevelScripts
{
    public class TutorialPlayerMover : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private GameValuesSetter _values;
        private ParticlePlayer _particlePlayer;
        private int _jumpsCounter;

        private void Start()
        {
            _values = GameObject.Find("GameValues").GetComponent<GameValuesSetter>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _jumpsCounter = 0;
            _particlePlayer = GetComponent<ParticlePlayer>();
        }

        private void Update()
        {
            if (_values.isLosingHeart || _values.isLost || _values.isWin) return;
            var horizontalInput = Input.GetAxis("Horizontal");
            _rigidbody2D.velocity = new Vector2(horizontalInput * _values.CharacterSpeed, _rigidbody2D.velocity.y);

            if (Input.GetKeyDown(KeyCode.W) && _jumpsCounter < 2)
            {
                _particlePlayer.PlayJumpEffect();
                _rigidbody2D.AddForce(Vector2.up * _values.CharacterJumpForce, ForceMode2D.Impulse);
                _jumpsCounter++;
            }
        }
    }
}
