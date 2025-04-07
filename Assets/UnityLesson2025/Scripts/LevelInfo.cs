using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "Scriptable Objects/LevelInfo")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private int starsCount;
    [SerializeField] private int maxStarsCount;

    public int StarsCount
    {
        get
        {
            return starsCount;
        }
    }

    public int MaxStarsCount
    {
        get
        {
            return maxStarsCount;
        }
    }

    public void Load()
    {
        try
        {
            if (File.Exists(Path.Combine(Application.persistentDataPath, $"{name}.json")))
            {
                string jsonData = File.ReadAllText(Path.Combine(Application.persistentDataPath, $"{name}.json"));
                JsonUtility.FromJsonOverwrite(jsonData, this);
            }
            else
            {
                Debug.LogWarning("Данные не найдены");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Не удалось загрузить файл: {e.Message}");
        }
    }

    public void SetStarsCount(int newStarsCount)
    {
        Debug.Log("Старое чилсо звёзд:= " + starsCount);
        if (starsCount < newStarsCount)
        {
            starsCount = newStarsCount;
            Debug.Log("Новое чилсо звёзд:= " + starsCount);
            Save();
        }
    }

    private void Save()
    {
        Debug.Log("Попытка сохранить уровень");
        try
        {
            string jsonData = JsonUtility.ToJson(this, true);
            File.WriteAllText(Path.Combine(Application.persistentDataPath, $"{name}.json") ,jsonData);
            Debug.Log("Уровень сохранён");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Не удалось сохранить файл: {e.Message}");
        }
    }


}
