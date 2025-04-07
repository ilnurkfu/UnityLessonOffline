using UnityEngine;

public class LevelDatas : MonoBehaviour
{
    [SerializeField] private int stars = 3;

    private static LevelDatas instance;

    public int Stars 
    {
        get 
        {
            return stars;
        }
    }

    public static LevelDatas Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }
}
