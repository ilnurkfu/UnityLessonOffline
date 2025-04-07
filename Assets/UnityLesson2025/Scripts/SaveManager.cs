using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private LevelInfo[] levelsInfo;

    private void Start()
    {
        for (int i = 0; i < levelsInfo.Length; i++)
        {
            levelsInfo[i].Load();
        }
    }
}
