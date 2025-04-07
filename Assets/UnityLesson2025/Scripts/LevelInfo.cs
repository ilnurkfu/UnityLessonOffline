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
                Debug.LogWarning("������ �� �������");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"�� ������� ��������� ����: {e.Message}");
        }
    }

    public void SetStarsCount(int newStarsCount)
    {
        Debug.Log("������ ����� ����:= " + starsCount);
        if (starsCount < newStarsCount)
        {
            starsCount = newStarsCount;
            Debug.Log("����� ����� ����:= " + starsCount);
            Save();
        }
    }

    private void Save()
    {
        Debug.Log("������� ��������� �������");
        try
        {
            string jsonData = JsonUtility.ToJson(this, true);
            File.WriteAllText(Path.Combine(Application.persistentDataPath, $"{name}.json") ,jsonData);
            Debug.Log("������� �������");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"�� ������� ��������� ����: {e.Message}");
        }
    }


}
