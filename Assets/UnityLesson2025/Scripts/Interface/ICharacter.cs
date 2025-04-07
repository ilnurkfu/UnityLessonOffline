using UnityEngine;

public interface ICharacter
{
    public void ChangeColor(Color newColor);

    public void ApplyDamage(int damage);

    public void ChangeSize(float newSize, float timeEffect);

    public Color GetColor();
}
