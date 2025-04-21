using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : CharacterController, IPlayerController
{
    [SerializeField] private float raycastDistance;

    [SerializeField] private LayerMask targetLayer;

    [SerializeField] private Player player;

    [SerializeField] private MovementViaPhysics movementViaPhysics;

    [SerializeField] private Rigidbody rigi;

    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private PauseMenu pauseMenu;

    [SerializeField] private CameraController cameraController;

    [SerializeField] private PlayerInput playerInput;

    private void Start()
    {
        Initialized();
    }

    protected void Initialized()
    {
        playerInfo.SetScoreInfo(player.score.ToString());
        playerInfo.SetHealthInfo(player.health.ToString(), player.maxHealth.ToString(), (float)player.health / player.maxHealth);
    }

    private void Update()
    {
        playerInput.MouseInput();
        playerInput.KeyBoardInput();

        if(playerInput.JumpInput() == true)
        {
            movementViaPhysics.Jump();
        }

        if(playerInput.PauseInput() == true)
        {
            pauseMenu.StartPause();
        }

        movementViaPhysics.PlayerRotate(cameraController.GetSensivityScale(playerInput.MouseX));

        movementViaPhysics.Movement(playerInput.Vertical, playerInput.Horizontal);
        cameraController.RotateCamera(playerInput.MouseY);

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if(Physics.Raycast(ray, out RaycastHit hit, raycastDistance, targetLayer))
        {
            Debug.Log(hit.collider.gameObject.name);
            
            if(hit.collider.TryGetComponent<IPromptObject>(out var newPromptObject))
            {
                if(newPromptObject != player.promptObject)
                {
                    newPromptObject.Hover();
                    player.promptObject = newPromptObject;
                }

                if(playerInput.ActionInput() == true)
                {
                    newPromptObject.Action();
                }
            }
            else
            {
                if(player.promptObject != null)
                {
                    player.promptObject.Dehover();
                    player.promptObject = null;
                }
            }
        }
        else
        {
            if (player.promptObject != null)
            {
                player.promptObject.Dehover();
                player.promptObject = null;
            }
        }


    }

    public void AddScore(int additionalScore)
    {
        player.score += additionalScore;
        playerInfo.SetScoreInfo(player.score.ToString());
        Debug.Log("Получено очков:= " + additionalScore + " всего очков:= " + player.score);
    }

    public override void ApplyDamage(int damage, DamagebleType damagebleType)
    {
        if (player.isInvincible == false)
        {
            if (damagebleType != player.resistance)
            {
                if (player.health > damage)
                {
                    player.health -= damage;

                    playerInfo.SetHealthInfo(player.health.ToString(), player.maxHealth.ToString(), (float)player.health / player.maxHealth);

                    StartCoroutine(Invicibility());

                    movementViaPhysics.KnockbackEffect(player.collisionPoint, player.knockBackPower);

                    Debug.Log("Получено урона:= " + damage + " здоровья осталось:= " + player.health);
                }
                else
                {
                    player.health = 0;
                    Die();
                }
            }
        }
    }

    private void ResetScore()
    {
        player.score = 0;
        playerInfo.SetScoreInfo(player.score.ToString());
    }

    protected override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator Invicibility()
    {
        player.isInvincible = true;

        float elapsedTime = 0f;

        while (elapsedTime < player.InvicibilityTimer)
        {
            elapsedTime += Time.deltaTime;

            Debug.Log("Время до конца неуязвимости:= " + (player.InvicibilityTimer - elapsedTime));

            yield return null;
        }

        player.isInvincible = false;
    }

    public int GetScore()
    {
        return player.score;
    }

    public void Flip()
    {
        if(player.flipCoroutine != null)
        {
            StopCoroutine(player.flipCoroutine);
            player.flipCoroutine = null;
        }

        player.flipCoroutine = FlippedPlayer();

        StartCoroutine(player.flipCoroutine);

        player.flipped = !player.flipped;
    }

    private IEnumerator FlippedPlayer()
    {
        Quaternion startRotation = transform.localRotation;

        Quaternion flipDelta = Quaternion.AngleAxis(180f, transform.right);

        Quaternion endRotation = startRotation * flipDelta;

        float time = 0;
        float duration = player.FlipDuration;

        while (time < duration)
        {
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = endRotation;
        player.flipCoroutine = null;
    }

    public void UseGravity(bool isStandartGravity)
    {
        if (isStandartGravity == true)
        {
            Flip();
            rigi.useGravity = true;
        }
        else
        {
            Flip();
            rigi.useGravity = false;
        }
    }    

    public void AddGravity(Vector3 gravityPower, ForceMode forceMode)
    {
        rigi.AddForce(gravityPower, forceMode);
    }
}
