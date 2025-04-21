using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

public class SizePotion : MonoBehaviour, ITriggerObject<ICharacterController>
{
    [SerializeField] private float sizeScale;
    [SerializeField] private float timer;

    public void TriggerAction(ICharacterController character)
    {
        character.ChangeSize(sizeScale, timer);
    }
}
