using UnityEngine;

namespace PlatformScripts
{
    public class CheckPoint : MonoBehaviour
    {
        [SerializeField] private Transform cameraPoint;

        public bool IsCurrentCheckPoint { get; set; }

       public delegate void AllPropertiesFalseSetter();
       
       public delegate void MoveCameraToCheckpoint(Transform checkpointPosition);
       
       public event AllPropertiesFalseSetter OnCheckpointStay;
       public event MoveCameraToCheckpoint OnCheckpointStayForCamera;

       private void Start()
       {
           IsCurrentCheckPoint = false;
       }

       private void OnCollisionStay2D(Collision2D other)
       {
           if (other.gameObject.CompareTag("Player"))
           {
               OnCheckpointStay?.Invoke();
               IsCurrentCheckPoint = true;
               OnCheckpointStayForCamera?.Invoke(cameraPoint);
           }
       }
    }
}
