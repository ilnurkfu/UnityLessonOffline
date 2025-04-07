using UnityEngine;
using UnityEngine.TextCore.Text;

public class ColorPotion : MonoBehaviour, ITriggerObject<ICharacter>
{
    [SerializeField] private Color currentColor;

    public void TriggerAction(ICharacter character)
    {
        character.ChangeColor(currentColor);
        Destroy(gameObject);
    }
}
