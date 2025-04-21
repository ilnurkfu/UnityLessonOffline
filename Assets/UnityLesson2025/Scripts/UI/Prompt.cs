using UnityEngine;

public class Prompt : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void Update()
    {
        Vector3 direction = transform.position - playerTransform.position;

        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction);
    }
}
