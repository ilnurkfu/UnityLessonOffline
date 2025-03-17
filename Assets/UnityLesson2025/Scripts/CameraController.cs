using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private float sensivity;
    [SerializeField] private float currentY;
    [SerializeField] private float minYAngleLimits;
    [SerializeField] private float maxYAngleLimits;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity;

        currentY -= mouseY;
        currentY = Mathf.Clamp(currentY, minYAngleLimits, maxYAngleLimits);

        player.PlayerRotate(mouseX);

        transform.localRotation = Quaternion.Euler(currentY, 0f, 0f);
    }
}
