using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Color requiredColor;

    [SerializeField] private Collider currentCollider;

    private void Awake()
    {
        currentCollider = GetComponent<Collider>();
    }

    public void CheckColor(Color targetColor)
    {
        if (requiredColor == targetColor)
        {
            currentCollider.enabled = false;
        }
    }
}
