using UnityEngine;

public class SecretLevel : MonoBehaviour
{
    [SerializeField] private GameObject secretLevel;

    [SerializeField] private LevelInfo[] levelsInfo;

    private void Start()
    {
        if(CheckLevels() == true)
        {
            secretLevel.SetActive(true);
        }
    }

    private bool CheckLevels()
    {
        for (int i = 0; i < levelsInfo.Length; i++)
        {
            if (levelsInfo[i].StarsCount != levelsInfo[i].MaxStarsCount)
            {
                return false;
            }
        }

        return true;
    }
}
