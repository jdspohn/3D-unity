using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    InputContainer inputContainer = new InputContainer();
    PlayerControls keys;

    private void Start()
    {
        keys = new PlayerControls();
        keys.Enable();

        keys.Player.Move.performed += i => inputContainer.move = i.ReadValue<Vector2>();
        keys.Player.Look.performed += i => inputContainer.look = i.ReadValue<Vector2>();
        keys.Player.Jump.started += i => inputContainer.jump.pressed = i.ReadValue<float>() > 0 ? true : false;
    }

    private void Update()
    {
        inputContainer.jump.held = GetButtonHeldStatus(keys.Player.Jump.phase);
        TestInput();
    }

    private void LateUpdate()
    {
        inputContainer.ResetInputs();
    }

    void TestInput()
    {
        if (inputContainer.jump.held)
        {
            Debug.Log("Jump held");
        }

    }

    bool GetButtonHeldStatus(InputActionPhase phase)
    {
        return phase == InputActionPhase.Performed;
    }
}
