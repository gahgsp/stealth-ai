using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 5f;

    private CharacterController _characterController;

    private void Awake() => _characterController = GetComponent<CharacterController>();

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        var direction = new Vector3(horizontal, 0, vertical);
        var movement = transform.TransformDirection(direction) * _moveSpeed;
        _characterController.SimpleMove(movement);
    }
}
