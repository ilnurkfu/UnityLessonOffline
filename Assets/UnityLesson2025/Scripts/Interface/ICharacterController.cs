using UnityEngine;

public interface ICharacterController
{
    public void ChangeColor(Color newColor);

    public void ApplyDamage(int damage, DamagebleType damagebleType);

    public void ChangeSize(float newSize, float timeEffect);

    public Color GetColor();
}
