using UnityEngine;
using System.Collections;

public class GameMaster :MonoBehaviour{


    public static GameMaster instance = null;
    int Health = 100;
    int HealthStep = 10;
    float SpawnTime = 5f;
    public EnemyController enemyCon;
    public GameObject[] SpawnPoints;
    public Color32[] Colours = { new Color32(11, 160, 13, 255), new Color32(214, 6, 6, 255), new Color32(17, 99, 214, 255), new Color32(226, 186, 4, 255) };
    float Speed = 5f;
    
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

        enemyCon = gameObject.GetComponent<EnemyController>();

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

    public float GetSpawnTime()
    {
        return SpawnTime;
    }

    public float GetSpeed()
    {
        return Speed;
    }
}
