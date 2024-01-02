using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float moveSpeed = 10f;
    
    private CharacterController characterController;
    private bool _isCrouching;
    private float gravity = -5f;
    private float yVelocity = 0f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;
        
        yVelocity += gravity * Time.deltaTime;
        moveDirection.y = yVelocity;
        
        characterController.Move(moveDirection * Time.deltaTime);
        Crouch();
    }
    
    private void Crouch()
    {
        if (_isCrouching && Input.GetKeyDown(KeyCode.LeftControl))
        {
            _isCrouching = false;
            moveSpeed = 10f;
        }
        else if (!_isCrouching && Input.GetKeyDown(KeyCode.LeftControl))
        {
            _isCrouching = true;
            moveSpeed = 3f;
        }
        
        float targetY = _isCrouching ? 0.2f : 0.5f;
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, new Vector3(0, targetY, 0), 0.2f);
    }
}