using UnityEngine;

namespace LevelScripts
{
    public class GameValuesSetter : MonoBehaviour
    {
        [Header("Character stats")] [SerializeField]
        private float characterSpeed;

        [SerializeField] private float characterJumpForce;

        [HideInInspector] public bool isLost;
        [HideInInspector] public bool isLosingHeart;
        [HideInInspector] public bool isWin;


        [Space(30)] [Header("Camera Stats")] [SerializeField]
        private float cameraMovementSpeed;

        [SerializeField] private float cameraBackMovingSpeed;


        [Space(30)] [Header("Enemy Stats")] [SerializeField]
        private float enemySpeed;


        public float CharacterSpeed => characterSpeed;
        public float CharacterJumpForce => characterJumpForce;

        public float CameraMovementSpeed => cameraMovementSpeed;
        public float CameraBackMovingSpeed => cameraBackMovingSpeed;

        public float EnemySpeed => enemySpeed;
    }
}