using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int requiredScore;

    [SerializeField] private float currentTime;
    [SerializeField] private float requiredTime;
    [SerializeField] private float levelDelay;

    [SerializeField] private string nextSceneName;

    [SerializeField] private LevelInfo levelInfo;

    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    public void FinishLevel(int playerScore)
    {
        int currentStars = 0;

        if(CheckScore(playerScore))
        {
            currentStars++;
        }

        if(CheckRequiredTime())
        {
            currentStars++;
        }

        currentStars++;

        levelInfo.SetStarsCount(currentStars);
        LoadNextScene();
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    private bool CheckScore(int playerScore)
    {
        if(playerScore >= requiredScore)
        {
            return true;
        }

        return false;
    }

    private bool CheckRequiredTime()
    {
        if(currentTime < requiredTime)
        {
            return true;
        }

        return false;
    }

    private IEnumerator LoadNextSceneCoroutine()
    {
        yield return new WaitForSeconds(levelDelay);
        SceneManager.LoadScene(nextSceneName);
    }
}
