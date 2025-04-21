using UnityEngine;
using UnityEngine.Events;

public class PhysicalButton : MonoBehaviour
{
    [SerializeField] private float liftingPower;
    [SerializeField] private float minLimit;
    [SerializeField] private float maxLimit;

    [SerializeField] private Rigidbody rigi;

    [SerializeField] private UnityEvent buttonPressAction;
    [SerializeField] private UnityEvent buttonReleaseAction;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 offset = transform.position;
        offset.y = Mathf.Clamp(offset.y, minLimit, maxLimit);

        var currentPower = 0f;

        if (offset.y > minLimit)
        {
            currentPower = liftingPower * (1 - ((offset.y - minLimit) / (maxLimit - minLimit)));
        }

        rigi.linearVelocity = transform.up * currentPower;

        transform.position = offset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<TriggerPhysicalButton>() == true)
        {
            buttonPressAction?.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<TriggerPhysicalButton>() == true)
        {
            buttonReleaseAction?.Invoke();
        }
    }
}
