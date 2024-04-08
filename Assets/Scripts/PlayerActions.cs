using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerActions : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _playerInput = new PlayerInput();

        _playerInput.Player.Jump.performed += OnJump;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        Vector2 direction = _playerInput.Player.Move.ReadValue<Vector2>();

        OnMove(direction);
    }

    private void OnMove(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);

        moveDirection = moveDirection * _moveSpeed;

        _rigidbody.AddForce(moveDirection.MoveToIsometric());
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _rigidbody.AddForce(0, _jumpForce, 0);
    }
}