using UnityEngine;
using UnityEngine.TextCore.Text;

public class ColorPotion : MonoBehaviour, ITriggerObject<ICharacterController>
{
    [SerializeField] private Color currentColor;

    public void TriggerAction(ICharacterController character)
    {
        character.ChangeColor(currentColor);
        Destroy(gameObject);
    }
}
