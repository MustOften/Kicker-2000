using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int points = 100;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnLevelWasLoaded(int level)
    {
        Text ui = GameObject.Find("/Canvas/Text").GetComponent<Text>();
        Debug.Log("scene was loaded");
    }
}