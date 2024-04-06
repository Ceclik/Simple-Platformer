using UnityEngine;

public  class GameValuesSetter : MonoBehaviour
{
    [Header("Character stats")]
    [SerializeField] private float characterSpeed;
    [SerializeField] private float characterJumpForce;
    
    [HideInInspector] public bool IsLost = false;
    [HideInInspector] public bool IsLosingHeart = false;
    [HideInInspector] public bool IsWin = false;
    
    
    [Space(30)] [Header("Camera Stats")]
    [SerializeField] private float cameraMovementSpeed;
    [SerializeField] private float cameraBackMovingSpeed;


    public float CharacterSpeed => characterSpeed;
    public float CharacterJumpForce => characterJumpForce;

    public float CameraMovementSpeed => cameraMovementSpeed;
    public float CameraBackMovingSpeed => cameraBackMovingSpeed;
}