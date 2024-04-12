using UnityEngine;

namespace PlayerScripts
{
    public class AnimationsHandler : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            HandleRunning();
            HandleJumping();
        }

        private void SetRunningTriggersFromIdle()
        {
            _animator.ResetTrigger("isStay");
            _animator.SetTrigger("isRunning");
        }

        private void HandleRunning()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput > 0)
            {
                transform.localRotation = Quaternion.Euler(Vector3.zero);
                SetRunningTriggersFromIdle();
            }

            else if (horizontalInput < 0)
            {
                SetRunningTriggersFromIdle();
                transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));
            }
            else 
            {
                _animator.ResetTrigger("isRunning");
                _animator.SetTrigger("isStay");
            }
        }

        private void HandleJumping()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _animator.ResetTrigger("isStay");
                _animator.SetTrigger("jump");
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                _animator.SetTrigger("isStay");
                _animator.ResetTrigger("jump");
            }
        }
    }
}
