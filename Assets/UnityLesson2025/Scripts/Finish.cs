using UnityEngine;

public class Finish : MonoBehaviour, ITriggerObject<IPlayerController>
{
    [SerializeField] private LevelManager levelManager;

    public void TriggerAction(IPlayerController player)
    {
        levelManager.FinishLevel(player.GetScore());
    }

    public void TriggerAction(ICharacterController character)
    {
        if (character is IPlayerController player)
        {
            TriggerAction(player);
        }
    }
}
