using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManageStart : MonoBehaviour
{
    public static GameManageStart instance;
    private const string Hight_Core = "HightCore";
    // Start is called before the first frame update
    void Awake()
    {
        IsPlayFirstTime();
        SingleInstace();
    }
    void IsPlayFirstTime()
    {
        if(!PlayerPrefs.HasKey("IsPlayFirstTime"))
        {
            PlayerPrefs.SetInt(Hight_Core, 0);
            PlayerPrefs.SetInt("IsPlayFirstTime", 0);
        }
    }
    void SingleInstace()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void SetPoint(int score)
    {
        PlayerPrefs.SetInt(Hight_Core, score);
    }
    public int GetPoint()
    {
        return PlayerPrefs.GetInt(Hight_Core);
    }
}
