using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 movementForward = transform.forward * verticalMovement;

        Vector3 movementRight = transform.right * horizontalMovement;

        transform.position += (movementForward + movementRight) * movementSpeed * Time.deltaTime;
    }

    public void PlayerRotate(float mouseInputX)
    {
        transform.Rotate(Vector3.up * mouseInputX);
    }
}
