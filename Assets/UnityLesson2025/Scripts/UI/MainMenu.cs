using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string startSceneName;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
