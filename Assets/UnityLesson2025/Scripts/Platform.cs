using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour, ICollisionObject
{
    [SerializeField] private float timer;
    [SerializeField] private float blinkTimer;
    [SerializeField] private float resetTimer;
    [SerializeField] private float minBlinkTimer;

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Collider currentCollider;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        currentCollider = GetComponent<Collider>();
    }

    public void CollisionAction(ICharacterController character)
    {
        StartCoroutine(DisablePlatform());
    }

    private IEnumerator DisablePlatform()
    {
        float elapsedTime = 0f;
        float blinkTime;

        while (elapsedTime < timer)
        {
            meshRenderer.enabled = false;

            blinkTime = blinkTimer * (1 - elapsedTime / timer);

            if(blinkTime < minBlinkTimer)
            {
                blinkTime = blinkTimer;
            }

            yield return new WaitForSeconds(blinkTime); 

            elapsedTime += blinkTime;
            meshRenderer.enabled = true;

            yield return new WaitForSeconds(blinkTime);
            elapsedTime += blinkTime;
        }

        meshRenderer.enabled = false;
        currentCollider.enabled = false;

        yield return new WaitForSeconds(resetTimer);

        Reset();
    }

    private void Reset()
    {
        meshRenderer.enabled = true;
        currentCollider.enabled = true;
    }
}
