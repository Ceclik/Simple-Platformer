using PlayerScripts;
using UnityEngine;

namespace CameraScripts
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private float cameraMovementSpeed;
        [SerializeField] private float cameraBackMovinSpeed;
        [SerializeField] private GameObject pointsParent;

        [Space(10)] [SerializeField] private Transform zeroPoint;
        [SerializeField] private LoseAndWinHandler loseAndWinHandler;

        [Space(10)] [SerializeField] private GameObject leftBorder;
        [SerializeField] private GameObject rightBorder;
            
        private Transform[] _points;
        private int _pointIndex;
        public bool IsMoving { get; private set; }

        private void Start()
        {
            _points = pointsParent.GetComponentsInChildren<Transform>();
            _pointIndex = 0;
            IsMoving = false;
        }

        public void MoveCamera()
        {
            _pointIndex++;
            IsMoving = true;
        }

        private void Update()
        {
            if (IsMoving)
            {
                SetBordersActivity(false);
                transform.position = Vector3.MoveTowards(transform.position, _points[_pointIndex].position,
                    cameraMovementSpeed * Time.deltaTime);
            }

            if (transform.position == _points[_pointIndex].position)
            {
                IsMoving = false;
                SetBordersActivity(true);
            }

            if (loseAndWinHandler.IsLost && transform.position != zeroPoint.position)
            {
                SetBordersActivity(false);
                IsMoving = false;
                transform.position = Vector3.MoveTowards(transform.position, zeroPoint.position,
                    cameraBackMovinSpeed * Time.deltaTime);
                MakePointIndexZero();
            }

            if (loseAndWinHandler.IsLost && transform.position == zeroPoint.position)
            {
                loseAndWinHandler.IsLost = false;
                SetBordersActivity(true);
            }
        }
        
        private void SetBordersActivity(bool status)
        {
            if (status)
            {
                leftBorder.SetActive(true);
                rightBorder.SetActive(true);
            }
            else
            {
                leftBorder.SetActive(false);
                rightBorder.SetActive(false);
            }
        }

        public void MakePointIndexZero()
        {
            _pointIndex = 0;
        }
    }
}