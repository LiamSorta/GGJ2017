using UnityEngine;
using System.Collections;

public class GameMaster :MonoBehaviour{


    public static GameMaster instance = null;
    int Health = 100;
    int HealthStep = 10;
    float SpawnTime = 1f;
    public EnemyController enemyCon;
    public GameObject[] SpawnPoints;
    public Color32[] Colours;
    float Speed = 0.12f;
    public PlayerBehaviours[] Players;
    public GameObject[] PlayerPrefabs;
    public SpriteRenderer[] Warnings;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    Colours = new Color32[] { new Color32(11, 160, 13, 255), new Color32(214, 6, 6, 255), new Color32(17, 99, 214, 255), new Color32(226, 186, 4, 255),new Color32(255, 255, 255, 255) };

    //enemyCon = gameObject.GetComponent<EnemyController>();

    InitGame();
    }

    void InitGame()
    {
        Players = new PlayerBehaviours[4];
        for (byte i = 0; i < Players.GetLength(0); i++)
        {
            GameObject plyer = Instantiate(PlayerPrefabs[i], transform.position, Quaternion.identity) as GameObject;
            Players[i] = plyer.GetComponent<PlayerBehaviours>();
            Players[i].SetPlayerColour(i);
            
        }
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
