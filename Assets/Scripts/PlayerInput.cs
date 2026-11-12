using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private InputAction JumpAction;
    private InputAction MoveAction;
    private void Start()
    {
        JumpAction = InputSystem.actions.FindAction("Jump");
        MoveAction = InputSystem.actions.FindAction("Move");
    }
    private void Update()
    {
        if (JumpAction.triggered)
        {
            Debug.Log("Ç∂Ç·Å[ÇÒÇ’ÇµÇΩÇÊ!");
        }
        Vector2 moveInput = MoveAction.ReadValue<Vector2>();
    }
}
