using UnityEngine;

public class Finish : MonoBehaviour, ITriggerObject<IPlayer>
{
    [SerializeField] private LevelManager levelManager;

    public void TriggerAction(IPlayer player)
    {
        levelManager.FinishLevel(player.GetScore());
    }

    public void TriggerAction(ICharacter character)
    {
        if (character is IPlayer player)
        {
            TriggerAction(player);
        }
    }
}
