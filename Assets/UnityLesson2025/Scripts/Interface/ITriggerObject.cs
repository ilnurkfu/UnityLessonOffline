using UnityEngine;

public interface ITriggerObject<T> : ITriggerObjectBase
{
    public void TriggerAction(T character);
}
