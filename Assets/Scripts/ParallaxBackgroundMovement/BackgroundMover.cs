using UnityEngine;

namespace ParallaxBackgroundMovement
{
    public class BackgroundMover : MonoBehaviour
    {
        [SerializeField] private float movingSpeed;

        [SerializeField] private bool isFarLayer;

        private void Update()
        {
            if (isFarLayer)
                MoveFarLayer();
            else
                MoveMiddleLayer();
        }

        private void MoveMiddleLayer()
        {
            transform.Translate(new Vector3(movingSpeed * Time.deltaTime, 0.0f, 0.0f));
            if (transform.position.x >= 440.0f)
                transform.position = new Vector3(-440.0f, 0.0f, 250.0f);
        }

        private void MoveFarLayer()
        {
            transform.Translate(new Vector3(movingSpeed * Time.deltaTime, 0.0f, 0.0f));
            if (transform.position.x >= 900.0f)
                transform.position = new Vector3(-900.0f, 0.0f, 500.0f);
        }
    }
}