using UnityEngine;

public class CameraModel : MonoBehaviour
{
    [SerializeField] private float sensivity;
    [SerializeField] public float currentY;
    [SerializeField] private float minYAngleLimits;
    [SerializeField] private float maxYAngleLimits;

    public float Sensivity
    {
        get
        {
            return sensivity;
        }
    }

    public float MinYAngleLimits
    {
        get
        {
            return minYAngleLimits;
        }
    }

    public float MaxYAngleLimits
    {
        get
        {
            return maxYAngleLimits;
        }
    }
}
