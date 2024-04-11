using UnityEngine;

namespace LevelScripts
{
    public class ObjectYAxisRotator : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;

        private float _angleValue = 0.0f;
        private void FixedUpdate()
        {
            _angleValue = rotationSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(0.0f, _angleValue, 0.0f));
            if (_angleValue >= 360.0f)
                _angleValue = 0.0f;
        }
    }
}
