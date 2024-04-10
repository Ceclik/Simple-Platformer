using System;
using LevelScripts;
using UnityEngine;

namespace EnemyScripts
{
    public class EnemyMover : MonoBehaviour
    {
        private GameValuesSetter _values;
        private Rigidbody2D _rigidbody;
        
        private float horizontal = 1f;

        [SerializeField] private Transform rightRayPosition;
        [SerializeField] private Transform leftRayPosition;

        private void Start()
        {
            _values = GameObject.Find("GameValues").GetComponent<GameValuesSetter>();
            _rigidbody = GetComponent<Rigidbody2D>();
            Physics2D.IgnoreLayerCollision(6, 7, true);
        }

        private void Update()
        {
            
            _rigidbody.velocity = new Vector2(horizontal * _values.EnemySpeed, _rigidbody.velocity.y);
            
            RaycastHit2D rightHit = Physics2D.Raycast(rightRayPosition.position, transform.right, 0.01f);
            RaycastHit2D leftHit = Physics2D.Raycast(transform.position, -transform.right, 0.01f);
            Debug.DrawRay(rightRayPosition.position, transform.right, Color.red, 0.01f);
            Debug.DrawRay(leftRayPosition.position, -transform.right, Color.green, 0.01f);
            if (rightHit.collider != null)
            {
                if (rightHit.collider.gameObject.CompareTag("PlarformBorder"))
                {
                    rightHit.distance = 0;
                    leftHit.distance = 0.01f;
                    horizontal *= -1;
                }
                if (leftHit.collider.gameObject.CompareTag("PlarformBorder"))
                {
                    rightHit.distance = 0.01f;
                    leftHit.distance = 0;
                    horizontal *= -1;
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
