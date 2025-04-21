using System.Collections;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Vector3 collisionPoint;

    public MeshRenderer meshRenderer;

    protected virtual void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
}
