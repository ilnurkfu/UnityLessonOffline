using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraModel cameraModel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RotateCamera(float mouseY)
    {
        cameraModel.currentY -= mouseY;
        cameraModel.currentY = Mathf.Clamp(cameraModel.currentY, cameraModel.MinYAngleLimits, cameraModel.MaxYAngleLimits);

        transform.localRotation = Quaternion.Euler(cameraModel.currentY, 0f, 0f);
    }

    public float GetSensivityScale(float value)
    {
        return value * cameraModel.Sensivity;
    }
}
