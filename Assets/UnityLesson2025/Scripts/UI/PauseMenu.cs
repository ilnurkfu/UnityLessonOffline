using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private string mainMenuScenename;

    public void StartPause()
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene(mainMenuScenename);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
