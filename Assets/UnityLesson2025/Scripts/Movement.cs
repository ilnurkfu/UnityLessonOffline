using UnityEngine;

public class Movement : MonoBehaviour
{
    public int intNumber;
    public float floatNumber;
    [SerializeField]private double doubleNumber;
    public string movementName;
    public bool isMovement;

    private void Awake()
    {
        Debug.Log("Awake " + name);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable " + name);
    }

    private void Start()
    {
        Debug.Log("Start " + name);
    }
}
