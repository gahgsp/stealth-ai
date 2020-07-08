using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 5f;

    // Cached references.
    private CharacterController _characterController;

    private float _ccOriginalHeight;
    private float _originalMoveSpeed;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        _characterController = GetComponent<CharacterController>();
        _ccOriginalHeight = _characterController.height;
        _originalMoveSpeed = _moveSpeed;
    }

    private void Update()
    {
        Move();
        Crouch();
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        var direction = new Vector3(horizontal, 0, vertical);
        var movement = transform.TransformDirection(direction) * _moveSpeed;
        _characterController.SimpleMove(movement);
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _characterController.height = _ccOriginalHeight / 2;
            _moveSpeed /= 3;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _characterController.height = _ccOriginalHeight;
            _moveSpeed = _originalMoveSpeed;
        }
    }
}
