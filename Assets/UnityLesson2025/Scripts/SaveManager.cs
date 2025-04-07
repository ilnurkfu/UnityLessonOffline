using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private LevelInfo[] levelsInfo;

    [SerializeField] private SecretLevel secretLevel;

    private void Start()
    {
        for (int i = 0; i < levelsInfo.Length; i++)
        {
            Debug.Log("Загрузка данных");
            levelsInfo[i].Load();
        }

        secretLevel.CheckLevels();
    }
}
