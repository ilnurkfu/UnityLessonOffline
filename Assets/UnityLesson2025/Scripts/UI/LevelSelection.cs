using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private Button apllyButton;

    [SerializeField] private LevelButton levelButton;

    private void Start()
    {
        apllyButton.interactable = false;
    }

    public void SetLevelButton(LevelButton newLevelButton)
    {
        if(levelButton == newLevelButton)
        {
            levelButton.Deselect();
            levelButton = null;
            apllyButton.interactable = false;
        }
        else
        {
            if (levelButton != null)
            {
                levelButton.Deselect();
            }

            levelButton = newLevelButton;
            levelButton.Select();
            apllyButton.interactable = true;
        }
    }

    public void LoadSelectScene()
    {
        SceneManager.LoadScene(levelButton.SceneName);
    }
}
