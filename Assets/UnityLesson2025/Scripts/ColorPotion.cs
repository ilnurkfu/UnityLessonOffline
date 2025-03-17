using UnityEngine;

public class ColorPotion : MonoBehaviour
{
    [SerializeField] private Color currentColor;

    public void ChangeTargetColor(Material targetMaterial)
    {
        targetMaterial.color = currentColor;
        Destroy(gameObject);
    }
}
