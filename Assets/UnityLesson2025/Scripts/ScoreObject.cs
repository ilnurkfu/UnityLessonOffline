using UnityEngine;
using UnityEngine.TextCore.Text;

public class ScoreObject : MonoBehaviour, ITriggerObject<IPlayer>
{
    [SerializeField] private int currentScore;

    public void TriggerAction(IPlayer player)
    {
        player.AddScore(currentScore);
        Destroy(gameObject);
    }

    public void TriggerAction(ICharacter character)
    {
        if(character is IPlayer player)
        {
            TriggerAction(player);
        }
    }
}
