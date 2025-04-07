using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour, ICollisionObject
{
    [SerializeField] private bool isOpen = false;

    [SerializeField] protected string AnimationName;

    [SerializeField] private Color requiredColor;

    [SerializeField] private GameObject flag;

    [SerializeField] private Animator animator;


    private void Start()
    {
        flag.GetComponent<MeshRenderer>().material.color = requiredColor;
    }

    public void CollisionAction(ICharacter character)
    {
        Debug.Log("Collision");
        if (requiredColor == character.GetColor())
        {
            if (isOpen == false)
            {
                OpenGate();
            }
        }
    }

    public void OpenGate()
    {
        animator.Play(AnimationName);
    }
}
