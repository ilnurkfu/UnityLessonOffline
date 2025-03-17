using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

public class SizePotion : MonoBehaviour
{
    [SerializeField] private float sizeScele;
    [SerializeField] private float timer;

    private Dictionary<Transform, IEnumerator> enumerators = new Dictionary<Transform, IEnumerator>();

    public void ChangeTargetScale(Transform targetTransform)
    {
        if(enumerators.ContainsKey(targetTransform))
        {
            StopCoroutine(enumerators[targetTransform]);

            enumerators[targetTransform] = StartChangeTargetScale(targetTransform);

            StartCoroutine(enumerators[targetTransform]);
        }
        else
        {
            enumerators.Add(targetTransform, StartChangeTargetScale(targetTransform));
            StartCoroutine(enumerators[targetTransform]);
        }
    }

    private IEnumerator StartChangeTargetScale(Transform targetTransform)
    {
        targetTransform.localScale = Vector3.one * sizeScele;

        yield return new WaitForSeconds(timer);

        targetTransform.localScale = Vector3.one;

        enumerators.Remove(targetTransform);
    }
}
