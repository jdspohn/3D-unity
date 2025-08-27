using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    InputContainer _inputContainer = new InputContainer();
    public InputContainer inputContainer { get { return _inputContainer; } }
    PlayerControls keys;

    private void Start()
    {
        keys = new PlayerControls();
        keys.Enable();

        keys.Player.Move.performed += i => _inputContainer.move = i.ReadValue<Vector2>();
        keys.Player.Look.performed += i => _inputContainer.look = i.ReadValue<Vector2>();
        keys.Player.Jump.started += i => _inputContainer.jump.pressed = i.ReadValue<float>() > 0 ? true : false;
    }

    private void Update()
    {
        _inputContainer.jump.held = GetButtonHeldStatus(keys.Player.Jump.phase);
        TestInput();
    }

    private void LateUpdate()
    {
        _inputContainer.ResetInputs();
    }

    void TestInput()
    {
        if (_inputContainer.jump.held)
        {
            Debug.Log("Jump held");
        }

    }

    bool GetButtonHeldStatus(InputActionPhase phase)
    {
        return phase == InputActionPhase.Performed;
    }
}
