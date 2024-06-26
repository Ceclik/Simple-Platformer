using System;
using CameraScripts;
using LevelScripts;
using PlatformScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private CameraMover cameraMover;

        private int _jumpsCounter;

        private Rigidbody2D _rigidbody2D;

        private GameValuesSetter _values;
        private ParticlePlayer _particlePlayer;

        private void Start()
        {
            _values = GameObject.Find("GameValues").GetComponent<GameValuesSetter>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _jumpsCounter = 0;
            _particlePlayer = GetComponent<ParticlePlayer>();
        }

        private void Update()
        {
            if (_values.isLosingHeart || _values.isLost || _values.isWin || _values.isInDialog) return;
            var horizontalInput = Input.GetAxis("Horizontal");
            _rigidbody2D.velocity = new Vector2(horizontalInput * _values.CharacterSpeed, _rigidbody2D.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && _jumpsCounter < 2)
            {
                _particlePlayer.PlayJumpEffect();
                _rigidbody2D.AddForce(Vector2.up * _values.CharacterJumpForce, ForceMode2D.Impulse);
                _jumpsCounter++;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Platform") && _jumpsCounter <= 2)
                _jumpsCounter = 0;
            if (collision.gameObject.TryGetComponent<CameraMovementTrigger>(
                    out var cameraMovementTrigger) && !cameraMovementTrigger.IsJumped)
            {
                cameraMover.MoveCamera();
                cameraMovementTrigger.IsJumped = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out CameraMovementTrigger trigger) && !trigger.IsJumped)
            {
                cameraMover.MoveCamera();
                trigger.IsJumped = true;
            }
        }
    }
}