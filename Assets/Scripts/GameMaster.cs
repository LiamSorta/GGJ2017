using UnityEngine;
using System.Collections;

public class GameMaster :MonoBehaviour{


    public static GameMaster instance = null;
    int Health = 100;
    int HealthStep = 10;
    
    void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    void InitGame()
    {

    }

    public int GetHealth()
    {
        return Health;
    }

    public int GetHealthStep()
    {
        return HealthStep;
    }
}
