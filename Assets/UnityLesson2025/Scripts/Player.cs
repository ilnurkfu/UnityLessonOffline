using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : CharacterBase
{
    public bool isInvincible;
    public bool flipped;

    public int score;

    public float knockBackPower;

    public IPromptObject promptObject;

    public IEnumerator flipCoroutine;

    public DamagebleType resistance;

    [SerializeField] private float invicibilityTimer;
    [SerializeField] private float flipDuration;

    public float InvicibilityTimer
    {
        get
        {
            return invicibilityTimer;
        }
    }

    public float FlipDuration
    {
        get
        {
            return flipDuration;
        }
    }
}
