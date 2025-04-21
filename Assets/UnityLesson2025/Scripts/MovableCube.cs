using UnityEngine;

public enum AxialDirection
{
    x,
    y,
    z
}

[RequireComponent(typeof(Rigidbody))]
public class MovableCube : MonoBehaviour
{
    [SerializeField] private AxialDirection axialDirection;

    [SerializeField] private float minLimit;
    [SerializeField] private float maxLimit;

    private Rigidbody rigi;

    private Vector3 allowedAxis;

    private Vector3 startPosition;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody>();

        startPosition = transform.position;

        RefreshAxialDirection();
    }

    private void FixedUpdate()
    {
        Vector3 currentVelocity = rigi.linearVelocity;
        Vector3 projectVelocity = Vector3.Project(currentVelocity, allowedAxis);

        float offset = Vector3.Dot(transform.position - startPosition, allowedAxis);

        if (offset <= minLimit && Vector3.Dot(projectVelocity, allowedAxis) < 0)
        {
            projectVelocity = Vector3.zero;
        }

        if (offset >= maxLimit && Vector3.Dot(projectVelocity, allowedAxis) > 0)
        {
            projectVelocity = Vector3.zero;
        }

        rigi.linearVelocity = projectVelocity;

        offset = Mathf.Clamp(offset, minLimit, maxLimit);

        transform.position = startPosition + allowedAxis * offset;
    }

    [ContextMenu("RefreshAxialDirection")]
    private void RefreshAxialDirection()
    {
        switch (axialDirection)
        {
            case AxialDirection.x:
                allowedAxis = transform.right;
                break;
            case AxialDirection.y:
                allowedAxis = transform.up;
                break;
            case AxialDirection.z:
                allowedAxis = transform.forward;
                break;
        }
    }
}
