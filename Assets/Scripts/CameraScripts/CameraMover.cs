using System;
using LevelScripts;
using MenuHandlers.LoseMenu;
using PlatformScripts;
using UnityEngine;

namespace CameraScripts
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private Transform pointsParent;

        [Space(10)] [SerializeField] private CheckPoint[] checkPoints;

        private Transform[] _points;
        private int _currentPointIndex;
        private int _zeroPointIndex;
        private Transform _targetZeroPoint;

        private GameValuesSetter _values;
        private bool _isMoving;
        private bool _isResetting;

        private MenuButtonsHandler _buttonsHandler;

        private void Start()
        {
            _values = GameObject.Find("GameValues").GetComponent<GameValuesSetter>();
            _points = new Transform[pointsParent.childCount];

            for (var i = 0; i < pointsParent.childCount; i++)
                _points[i] = pointsParent.GetChild(i);

            _isMoving = false;

            foreach (var checkPoint in checkPoints)
                checkPoint.OnCheckpointStayForCamera += SetCheckpointPosition;

            _buttonsHandler = GameObject.Find("ButtonsHandler").GetComponent<MenuButtonsHandler>();
            _buttonsHandler.OnRestartLevel += ResetCameraPosition;
        }

        private void OnDestroy()
        {
            foreach (var checkPoint in checkPoints)
                checkPoint.OnCheckpointStayForCamera -= SetCheckpointPosition;

            _buttonsHandler.OnRestartLevel -= ResetCameraPosition;
        }

        public void MoveCamera()
        {
            _currentPointIndex++;
            _isMoving = true;
        }

        private void SetCheckpointPosition(Transform newZeroPoint)
        {
            for (var i = 0; i < _points.Length; i++)
                if (_points[i].position == newZeroPoint.position)
                {
                    _zeroPointIndex = i;
                    _targetZeroPoint = _points[i];
                }
        }

        private void Update()
        {
            if (_isMoving)
                transform.position = Vector3.MoveTowards(transform.position, _points[_currentPointIndex].position,
                    _values.CameraMovementSpeed * Time.deltaTime);

            if (transform.position == _points[_currentPointIndex].position)
                _isMoving = false;

            if (_values.isLosingHeart && transform.position != _targetZeroPoint.position)
            {
                _isMoving = false;
                transform.position = Vector3.MoveTowards(transform.position, _targetZeroPoint.position,
                    _values.CameraBackMovingSpeed * Time.deltaTime);
                MakeCurrentPointIndexZero();
            }

            if (_values.isLosingHeart && transform.position == _targetZeroPoint.position)
                _values.isLosingHeart = false;
        }

        private void MakeCurrentPointIndexZero()
        {
            _currentPointIndex = _zeroPointIndex;
        }

        public void ResetCameraPosition()
        {
            _zeroPointIndex = 0;
            MakeCurrentPointIndexZero();
            _targetZeroPoint = _points[_zeroPointIndex];
            if (transform.position != _targetZeroPoint.position)
                transform.position = _targetZeroPoint.position;
        }
    }
}