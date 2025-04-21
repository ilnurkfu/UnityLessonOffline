using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;

    public float Horizontal
    {
        get
        {
            return horizontal;
        }
    }

    public float Vertical
    {
        get
        {
            return vertical;
        }
    }

    public float MouseX
    {
        get
        {
            return mouseX;
        }
    }

    public float MouseY
    {
        get
        {
            return mouseY;
        }
    }

    public void KeyBoardInput()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    public void MouseInput()
    {
         mouseX = Input.GetAxis("Mouse X");
         mouseY = Input.GetAxis("Mouse Y");
    }

    public bool JumpInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool PauseInput()
    {
        return Input.GetKeyDown(KeyCode.Alpha1);
    }

    public bool ActionInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}
