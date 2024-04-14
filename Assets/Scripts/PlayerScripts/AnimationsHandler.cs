using UnityEngine;

namespace PlayerScripts
{
    public class AnimationsHandler : MonoBehaviour
    {
        private Animator _animator;
        
        private Transform _raycastPosition;

        private bool _isRunning;
        private bool _isOnGround = true;
        private bool _isFalling;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _raycastPosition = transform.GetChild(0).transform;
        }

        private void Update()
        {
            HandleRunning();
            HandleJumping();
            HandleFalling();
        }

        private void HandleFalling()
        {
            if (_isOnGround)
            {
                var hit = Physics2D.Raycast(_raycastPosition.position, Vector2.down, 0.1f);
                if (!hit.collider)
                {
                    _isOnGround = false;
                    _isFalling = true;
                    _animator.ResetTrigger("stay");
                    _animator.ResetTrigger("run");
                    _animator.SetTrigger("fall");
                }
            }
        }

        private void HandleJumping()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _isOnGround = false;
                _animator.ResetTrigger("stay");
                _animator.ResetTrigger("run");
                _animator.SetTrigger("jump");
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Platform") && !_isOnGround)
            {
                _isOnGround = true;
                _animator.ResetTrigger("jump");
                _animator.ResetTrigger("fall");
                if(_isRunning) 
                    _animator.SetTrigger("run");
                else 
                    _animator.SetTrigger("stay"); //////////////////////
            }
        }

        private void HandleRunning()
        {
            var horizontalAspect = Input.GetAxis("Horizontal");
            if (!_isRunning && horizontalAspect != 0 && (_isOnGround || _isFalling))
            {
                if (horizontalAspect > 0)
                {
                    _isRunning = true;
                    _animator.ResetTrigger("stay");
                    _animator.ResetTrigger("fall");
                    _animator.SetTrigger("run");
                    transform.localRotation = Quaternion.Euler(Vector3.zero);
                }
                else if (horizontalAspect < 0)
                {
                    _isRunning = true;
                    _animator.ResetTrigger("stay");
                    _animator.ResetTrigger("fall");
                    _animator.SetTrigger("run");
                    transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));
                }
            }
            else if (_isRunning && horizontalAspect == 0 && _isOnGround)
            {
                _isRunning = false;
                _animator.ResetTrigger("run");
                _animator.SetTrigger("stay");
            }
        }
    }
}
