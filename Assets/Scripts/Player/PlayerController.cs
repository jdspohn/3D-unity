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

    float moveAmount;
    Vector3 moveDirection;

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
        HandleRotation(delta);
    }

    void HandleMovement(InputContainer inputContainer, float delta)
    {
        moveAmount = inputContainer.move.magnitude;

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

    void HandleRotation(float delta)
    {
        if (moveDirection == Vector3.zero)
        {
            moveDirection = mTransform.forward;
        }
        Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
        Quaternion targetRotation = Quaternion.Slerp(mTransform.rotation, lookRotation, rotationSpeed * delta);
        mTransform.rotation = new Quaternion(0, targetRotation.y, 0, targetRotation.w);
    }
}
