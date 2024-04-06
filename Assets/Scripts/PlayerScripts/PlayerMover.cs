using CameraScripts;
using PlatformScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerScripts
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;

        [Space(10)][SerializeField] private CameraMover cameraMover;

        private int _jumpsCounter;

        private Rigidbody2D _rigidbody2D;
        private LoseAndWinHandler _loseHandler;

        private void Start()
        {
            _loseHandler = GetComponent<LoseAndWinHandler>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _jumpsCounter = 0;
        }

        private void Update()
        {
            if (_loseHandler.IsLost) return;
            var horizontalInput = Input.GetAxis("Horizontal");
            _rigidbody2D.velocity = new Vector2(horizontalInput * speed, _rigidbody2D.velocity.y);

            if (Input.GetKeyDown(KeyCode.W) && _jumpsCounter < 2)
            {
                _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                _jumpsCounter++;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Platform") && _jumpsCounter >= 2)
                _jumpsCounter = 0;
            if (collision.gameObject.TryGetComponent<CameraMovementTrigger>(
                    out var cameraMovementTrigger) && !cameraMovementTrigger.IsJumped)
            {
                cameraMover.MoveCamera();
                cameraMovementTrigger.IsJumped = true;
            }
        }
    }
}