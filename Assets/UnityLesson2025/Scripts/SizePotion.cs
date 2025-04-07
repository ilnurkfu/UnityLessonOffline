using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

public class SizePotion : MonoBehaviour, ITriggerObject<ICharacter>
{
    [SerializeField] private float sizeScale;
    [SerializeField] private float timer;

    public void TriggerAction(ICharacter character)
    {
        character.ChangeSize(sizeScale, timer);
    }
}
