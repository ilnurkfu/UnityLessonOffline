using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : CharacterBase, IPlayer
{
    [SerializeField] private bool isInvincible;

    [SerializeField] private int score;

    [SerializeField] private float invicibilityTimer;
    [SerializeField] private float knockBackPower;

    [SerializeField] private MovementViaPhysics movementViaPhysics;

    [SerializeField] private Rigidbody rigi;

    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private PauseMenu pauseMenu;

    //public override void ApplyDamage(int currentDamage)
    //{
    //    if (isInvincible == false)
    //    {
    //        if (health > currentDamage)
    //        {
    //            health -= currentDamage;

    //            StartCoroutine(Invicibility());

    //            KnockbackEffect((transform.position - currentDamagebleObject.transform.position).normalized);

    //            Debug.Log("Получено урона:= " + currentDamage + " здоровья осталось:= " + health);
    //        }
    //        else
    //        {
    //            health = 0;
    //            Die();
    //        }
    //    }
    //}

    //public void ApplyDamage()
    //{
    //    if (isInvincible == false)
    //    {
    //        if (score != 0)
    //        {
    //            ResetScore();

    //            StartCoroutine(Invicibility());

    //            KnockbackEffect((transform.position - currentDamagebleObject.transform.position).normalized);

    //            Debug.Log("Получен урон очки сброшены");
    //        }
    //        else
    //        {
    //            Die();
    //        }
    //    }
    //}

    private void Start()
    {
        Initialized();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pauseMenu.StartPause();
        }
    }

    protected void Initialized()
    {
        playerInfo.SetScoreInfo(score.ToString());
        playerInfo.SetHealthInfo(health.ToString(), maxHealth.ToString(), (float)health / maxHealth);
    }

    public void AddScore(int additionalScore)
    {
        score += additionalScore;
        playerInfo.SetScoreInfo(score.ToString());
        Debug.Log("Получено очков:= " + additionalScore + " всего очков:= " + score);
    }

    public int GetScore()
    {
        return score;
    }

    public override void ApplyDamage(int damage)
    {
        if (isInvincible == false)
        {
            if (health > damage)
            {
                health -= damage;

                playerInfo.SetHealthInfo(health.ToString(), maxHealth.ToString(), (float)health / maxHealth);

                StartCoroutine(Invicibility());

                KnockbackEffect(collisionPoint);

                Debug.Log("Получено урона:= " + damage + " здоровья осталось:= " + health);
            }
            else
            {
                health = 0;
                Die();
            }
        }
    }

    protected override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ResetScore()
    {
        score = 0;
        playerInfo.SetScoreInfo(score.ToString());
    }

    private void KnockbackEffect(Vector3 collisionPoint)
    {
        Vector3 horizontalDirection = transform.position - collisionPoint;

        horizontalDirection.y = 0;

        if(horizontalDirection == Vector3.zero)
        {
            horizontalDirection = transform.forward;
        }

        Vector3 knockbackDirection = (horizontalDirection.normalized + Vector3.up).normalized;

        movementViaPhysics.SetControll(false);

        rigi.AddForce(knockbackDirection * knockBackPower, ForceMode.Impulse);
    }

    private IEnumerator Invicibility()
    {
        isInvincible = true;

        float elapsedTime = 0f;

        while (elapsedTime < invicibilityTimer)
        {
            elapsedTime += Time.deltaTime;

            Debug.Log("Время до конца неуязвимости:= " + (invicibilityTimer - elapsedTime));

            yield return null;
        }

        isInvincible = false;
    }


}
