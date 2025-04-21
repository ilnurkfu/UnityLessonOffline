using System.Collections;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour, ICharacterController
{
    [SerializeField] private CharacterBase characterBase;

    public virtual void ApplyDamage(int damage, DamagebleType damagebleType)
    {
        if (characterBase.health > damage)
        {
            characterBase.health -= damage;
            Debug.Log("Получено урона:= " + damage + " здоровья осталось:= " + characterBase.health);
        }
        else
        {
            characterBase.health = 0;
            Die();
        }
    }

    public virtual void ChangeColor(Color newColor)
    {
        characterBase.meshRenderer.material.color = newColor;
    }

    public virtual void ChangeSize(float newSize, float timeEffect)
    {
        StartCoroutine(ChangeSizeCoroutine(newSize, timeEffect));
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
            characterBase.collisionPoint = collision.contacts[0].point;
            collision.gameObject.GetComponent<ICollisionObject>().CollisionAction(this);
        }
    }

    public Color GetColor()
    {
        return characterBase.meshRenderer.material.color;
    }
}
