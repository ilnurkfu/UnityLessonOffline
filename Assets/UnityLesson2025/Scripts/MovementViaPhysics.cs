using UnityEngine;

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
                rigi.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.GetComponent<Ground>() == true)
    //    {
    //        isGrounded = true;
    //        //currentjumpCount = 0;
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.GetComponent<Ground>() == true)
    //    {
    //        isGrounded = false;
    //    }
    //}
}
