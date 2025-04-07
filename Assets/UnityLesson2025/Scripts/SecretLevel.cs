using UnityEngine;

public class SecretLevel : MonoBehaviour
{
    [SerializeField] private GameObject secretLevel;

    [SerializeField] private LevelInfo[] levelsInfo;

    public void CheckLevels()
    {
        bool isRequiredCondition = true;
        for (int i = 0; i < levelsInfo.Length; i++)
        {
            Debug.Log("�������:= " + i + " ���������� ��������� ���� �����:= " + levelsInfo[i].StarsCount + "����� �������� ����:= " + levelsInfo[i].MaxStarsCount);
            if (levelsInfo[i].StarsCount != levelsInfo[i].MaxStarsCount)
            {
                isRequiredCondition = false;
            }
        }

        OpenSecretLevel(isRequiredCondition);
    }

    private void OpenSecretLevel(bool isRequiredCondition)
    {
        if (isRequiredCondition == true)
        {
            secretLevel.SetActive(true);
        }
    }
}
