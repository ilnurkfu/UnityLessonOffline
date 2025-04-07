using UnityEngine;

public class Lava : MonoBehaviour, ICollisionObject
{
    [SerializeField] private int damage;

    public void CollisionAction(ICharacter character)
    {
        character.ApplyDamage(damage);
    }
}
