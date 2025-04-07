using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private string sceneName;

    [SerializeField] private Image outlineButton;

    [SerializeField] private GameObject[] stars;

    [SerializeField] private LevelInfo levelInfo;

    public string SceneName
    {
        get
        {
            return sceneName;
        }
    }

    private void Start()
    {
        for (int i = 0; i < levelInfo.StarsCount; i++)
        {
            stars[i].SetActive(true);
        }
    }

    public void Select()
    {
        outlineButton.enabled = true;
    }

    public void Deselect()
    {
        outlineButton.enabled = false;
    }
}
