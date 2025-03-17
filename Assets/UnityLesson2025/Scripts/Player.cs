using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ColorPotion>() == true)
        {
            other.GetComponent<ColorPotion>().ChangeTargetColor(meshRenderer.material);
        }
        else if (other.GetComponent<SizePotion>() == true)
        {
            other.GetComponent<SizePotion>().ChangeTargetScale(transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Wall>() == true)
        {
            collision.gameObject.GetComponent<Wall>().CheckColor(meshRenderer.material.color);
        }
    }
}
