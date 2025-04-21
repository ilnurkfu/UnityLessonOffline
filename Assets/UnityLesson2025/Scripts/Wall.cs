using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour, ICollisionObject
{
    [SerializeField] private bool isOpen = false;

    [SerializeField] private float minLimit;
    [SerializeField] private float maxLimit;

    [SerializeField] private Color requiredColor;

    [SerializeField] private GameObject flag;


    private void Start()
    {
        flag.GetComponent<MeshRenderer>().material.color = requiredColor;
    }

    private void Update()
    {
        if (isOpen == true)
        {
            transform.localPosition += Vector3.up * Time.deltaTime;
        }
        else
        {
            transform.localPosition -= Vector3.up * Time.deltaTime;
        }

        Vector3 offset = transform.localPosition;
        offset.y = Mathf.Clamp(offset.y, minLimit, maxLimit);

        transform.localPosition = offset;
    }

    public void CollisionAction(ICharacterController character)
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
        isOpen = true;
    }

    public void CloseGate()
    {
        isOpen = false;
    }
}
