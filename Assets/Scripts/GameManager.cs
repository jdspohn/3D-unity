using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class GameManager : MonoBehaviour
{
    InputHandler inputHandler;
    [SerializeField] PlayerController player;
    private void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        player.PlayerInit();
    }

    private void Update()
    {
        float delta = Time.deltaTime;
        player.PlayerUpdate(inputHandler.inputContainer, delta);
    }
}
