using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private Image healthBar;

    public void SetScoreInfo(string newScoreText)
    {
        scoreText.text = newScoreText;
    }

    public void SetHealthInfo(string newHealthText, string maxHealth, float healthPercentage)
    {
        healthText.text = $"{newHealthText} / {maxHealth}";

        healthBar.fillAmount = healthPercentage;
    }
}
