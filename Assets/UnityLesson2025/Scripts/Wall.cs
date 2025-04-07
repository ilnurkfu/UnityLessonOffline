using UnityEngine;

public class Wall : MonoBehaviour, ICollisionObject
{
    [SerializeField] private Color requiredColor;

    [SerializeField] private Collider currentCollider;

    private void Awake()
    {
        currentCollider = GetComponent<Collider>();
    }

    public void CollisionAction(ICharacter character)
    {
        if (requiredColor == character.GetColor())
        {
            currentCollider.enabled = false;
        }
    }
}
