using System.Collections;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, ICharacter
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected Vector3 collisionPoint;

    [SerializeField] private MeshRenderer meshRenderer;

    protected virtual void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public virtual void ApplyDamage(int damage)
    {
        if (health > damage)
        {
            health -= damage;
            Debug.Log("Получено урона:= " + damage + " здоровья осталось:= " + health);
        }
        else
        {
            health = 0;
            Die();
        }
    }

    public virtual void ChangeColor(Color newColor)
    {
        meshRenderer.material.color = newColor;
    }

    public virtual void ChangeSize(float newSize, float timeEffect)
    {
        StartCoroutine(ChangeSizeCoroutine(newSize, timeEffect));
    }

    public virtual Color GetColor()
    {
        return meshRenderer.material.color;
    }

    protected virtual void ResetSize()
    {
        transform.localScale = Vector3.one;
    }

    protected abstract void Die();

    private IEnumerator ChangeSizeCoroutine(float newScale, float timerEffect)
    {
        transform.localScale = Vector3.one * newScale;

        yield return new WaitForSeconds(timerEffect);

        ResetSize();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ITriggerObjectBase>() != null)
        {
            other.GetComponent<ITriggerObjectBase>().TriggerAction(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ICollisionObject>() != null)
        {
            collisionPoint = collision.contacts[0].point;
            collision.gameObject.GetComponent<ICollisionObject>().CollisionAction(this);
        }
    }
}
