using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MovementViaPhysics : MonoBehaviour
{
    [SerializeField] private bool isControll;
    [SerializeField] private bool isGrounded;

    [SerializeField] private int groundCount;

    //[SerializeField] private int currentjumpCount;
    //[SerializeField] private int maxJumpCount;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;

    [SerializeField] private Rigidbody rigi;

    public bool IsGrounded
    {
        get
        { 
            return isGrounded;
        }
    }

    private void Awake()
    {
        rigi = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 movementForward = transform.forward * verticalMovement;

        Vector3 movementRight = transform.right * horizontalMovement;

        

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (currentjumpCount < maxJumpCount)
        //    {
        //        rigi.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        //        currentjumpCount++;
        //    }
        //}

        if (isGrounded == true && isControll == true)
        {
            rigi.linearVelocity = (movementForward + movementRight) * movementSpeed + new Vector3(0, rigi.linearVelocity.y, 0f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                //currentjumpCount++;
            }
        }
    }

    public void PlayerRotate(float mouseInputX)
    {
        transform.Rotate(Vector3.up * mouseInputX);
    }

    public void SetControll(bool newControllState)
    {
        isControll = newControllState;
    }

    public void Jump()
    {
        if (isGrounded == true && isControll == true)
        {
            rigi.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    public void KnockbackEffect(Vector3 collisionPoint, float knockBackPower)
    {
        Vector3 horizontalDirection = transform.position - collisionPoint;

        horizontalDirection.y = 0;

        if (horizontalDirection == Vector3.zero)
        {
            horizontalDirection = transform.forward;
        }

        Vector3 knockbackDirection = (horizontalDirection.normalized + Vector3.up).normalized;

        SetControll(false);

        rigi.AddForce(knockbackDirection * knockBackPower, ForceMode.Impulse);
    }
    public void Movement(float verticalMovement, float horizontalMovement)
    {
        Vector3 movementForward = transform.forward * verticalMovement;

        Vector3 movementRight = transform.right * horizontalMovement;

        if (isGrounded == true && isControll == true)
        {
            rigi.linearVelocity = (movementForward + movementRight) * movementSpeed + new Vector3(0, rigi.linearVelocity.y, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ground>() == true)
        {
            groundCount++;
            isGrounded = true;
            isControll = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ground>() == true)
        {
            groundCount--;

            if (groundCount == 0)
            {
                isGrounded = false;
            }
        }
    }
}
