using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
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

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("GOGOGO");
    }
}
