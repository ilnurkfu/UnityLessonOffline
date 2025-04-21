using UnityEngine;

public class GravityPedestal : MonoBehaviour, IPromptObject
{
    [SerializeField] private bool isActive;

    [SerializeField] private GameObject gravityZone;

    [SerializeField] private GameObject promptUI;

    public void Hover()
    {
        HidePrompt();
    }

    public void Dehover()
    {
        ShowPrompt();
    }

    public void Action()
    {
        Switch();
    }

    private void HidePrompt()
    {
        promptUI.SetActive(true);
    }

    private void ShowPrompt()
    {
        promptUI.SetActive(false);
    }

    private void Switch()
    {
        isActive = !isActive;

        gravityZone.SetActive(isActive);
    }
}
