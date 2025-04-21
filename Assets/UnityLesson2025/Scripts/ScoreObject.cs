using UnityEngine;
using UnityEngine.TextCore.Text;

public class ScoreObject : MonoBehaviour, ITriggerObject<IPlayerController>
{
    [SerializeField] private int currentScore;

    public void TriggerAction(IPlayerController player)
    {
        player.AddScore(currentScore);
        Destroy(gameObject);
    }

    public void TriggerAction(ICharacterController character)
    {
        if(character is IPlayerController player)
        {
            TriggerAction(player);
        }
    }
}
