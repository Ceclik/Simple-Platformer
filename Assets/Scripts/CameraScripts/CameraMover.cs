using UnityEngine;

namespace CameraScripts
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private GameObject pointsParent;
        [SerializeField] private Transform zeroPoint;
            
        private Transform[] _points;
        private int _pointIndex;
        
        private GameValuesSetter _values;
        private bool _isMoving;

        private void Start()
        {
            _values = GameObject.Find("GameValues").GetComponent<GameValuesSetter>();
            _points = pointsParent.GetComponentsInChildren<Transform>();
            _pointIndex = 0;
            _isMoving = false;
        }

        public void MoveCamera()
        {
            _pointIndex++;
            _isMoving = true;
        }

        private void Update()
        {
            if (_isMoving)
            {
                transform.position = Vector3.MoveTowards(transform.position, _points[_pointIndex].position,
                    _values.CameraMovementSpeed * Time.deltaTime);
            }

            if (transform.position == _points[_pointIndex].position)
                _isMoving = false;

            if (_values.IsLosingHeart && transform.position != zeroPoint.position)
            {
                _isMoving = false;
                transform.position = Vector3.MoveTowards(transform.position, zeroPoint.position,
                    _values.CameraBackMovingSpeed * Time.deltaTime);
                MakePointIndexZero();
            }

            if (_values.IsLosingHeart && transform.position == zeroPoint.position)
                _values.IsLosingHeart = false; ;
        }

        private void MakePointIndexZero()
        {
            _pointIndex = 0;
        }

        public void ResetCameraPosition()
        {
            if (transform.position != zeroPoint.position)
                transform.position = zeroPoint.position;
        }
    }
}