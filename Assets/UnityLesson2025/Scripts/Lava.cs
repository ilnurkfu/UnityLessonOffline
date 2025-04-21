using UnityEngine;

public class Lava : MonoBehaviour, ICollisionObject
{
    [SerializeField] private DamagebleType damagebleType;

    [SerializeField] private int damage;

    public void CollisionAction(ICharacterController character)
    {
        character.ApplyDamage(damage, damagebleType);
    }
}
