using UnityEngine;

public class InputContainer
{
    public Vector2 move, look;
    public ButtonContainer jump;

    public InputContainer()
    {
        jump = new ButtonContainer();
    }

    public void ResetInputs()
    {
        jump.pressed = false;
    }
}
