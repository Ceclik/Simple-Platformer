using LevelScripts;
using UnityEngine;

namespace EnemyScripts
{
    public class EnemyMover : MonoBehaviour
    {
        private GameValuesSetter _values;
        private Rigidbody2D _rigidbody;
        
        private float _horizontal = 1f;

        private bool _isRightHit;
        private bool _isLeftHit;

        [SerializeField] private Transform rightRayPosition;
        [SerializeField] private Transform leftRayPosition;

        private void Start()
        {
            _values = GameObject.Find("GameValues").GetComponent<GameValuesSetter>();
            _rigidbody = GetComponent<Rigidbody2D>();
            Physics2D.IgnoreLayerCollision(6, 7, true);
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_horizontal * _values.EnemySpeed, _rigidbody.velocity.y);
            
            RaycastHit2D rightHit = Physics2D.Raycast(rightRayPosition.position, transform.right, 0.01f);
            RaycastHit2D leftHit = Physics2D.Raycast(leftRayPosition.position, -transform.right, 0.01f);
            
            if (rightHit.collider != null)
            {
                if (rightHit.collider.gameObject.CompareTag("PlarformBorder") && !_isRightHit)
                {
                    _isRightHit = true;
                    _isLeftHit = false;
                    _horizontal *= -1;
                }
            }

            if (leftHit.collider != null)
            {
                if (leftHit.collider.gameObject.CompareTag("PlarformBorder") && !_isLeftHit)
                {
                    _isLeftHit = true;
                    _isRightHit = false;
                    _horizontal *= -1;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == 6)
                Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }
}
