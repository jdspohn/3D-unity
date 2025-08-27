using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    Transform mTransform;
    Transform mainCameraTransform;

    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    public void PlayerInit()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        mTransform = transform;
        mainCameraTransform = Camera.main.transform;
    }

    public void PlayerUpdate(InputContainer inputContainer, float delta)
    {
        HandleMovement(inputContainer, delta);
    }

    void HandleMovement(InputContainer inputContainer, float delta)
    {
        float moveAmount = inputContainer.move.magnitude;
        Vector3 moveDirection;

        if (moveAmount >= .5f)
        {
            moveDirection = mainCameraTransform.forward * inputContainer.move.y;
            moveDirection += mainCameraTransform.right * inputContainer.move.x;
            moveDirection.Normalize();
            moveDirection.y = 0;

            moveDirection *= (moveSpeed * moveAmount) * delta;
        }
        else
        {
            moveAmount = 0;
            moveDirection = Vector3.zero;
        }
        characterController.Move(moveDirection);
    }
}
