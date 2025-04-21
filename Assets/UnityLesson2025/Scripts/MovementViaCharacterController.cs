using UnityEngine;

public class MovementViaCharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravity;

    [SerializeField] private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //float verticalMovement = Input.GetAxis("Vertical");
        //float horizontalMovement = Input.GetAxis("Horizontal");

        //Vector3 movementForward = transform.forward * verticalMovement;

        //Vector3 movementRight = transform.right * horizontalMovement;

        //characterController.Move((movementForward + movementRight) * moveSpeed * Time.deltaTime);

        //if(characterController.isGrounded == false)
        //{
        //    characterController.Move(Vector3.up * -gravity * Time.deltaTime);
        //}
    }
}
