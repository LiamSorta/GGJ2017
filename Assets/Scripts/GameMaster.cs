using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameMaster :MonoBehaviour{


    public static GameMaster instance = null;
    int Health = 100;
    int HealthStep = 10;
    float SpawnTime = 0.4f;
    public EnemyController enemyCon;
    public GameObject[] SpawnPoints;
    public Color32[] Colours;
    float Speed = 0.1f;
    public PlayerBehaviours[] Players;
    public GameObject[] PlayerPrefabs;
    public SpriteRenderer[] Warnings;
    public Text[] StoredTexts;
    public Text[] IncomingTexts;
    public Text[] HealthTexts;
    public AudioClip[] Musics;
    public List<AudioClip> Deaths;
    public AudioClip[] Swords;
    public AudioClip[] Shields;
    bool Playing = true;
    public AudioSource[] GMPlayer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);

        GMPlayer = GetComponents<AudioSource>();
        Colours = new Color32[] { new Color32(11, 160, 13, 255), new Color32(214, 6, 6, 255), new Color32(17, 99, 214, 255), new Color32(226, 186, 4, 255), new Color32(255, 255, 255, 255) };

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
    public bool GetPlaying()
    {
        return Playing;
    }
    public void SetPlaying(bool State)
    {
        Playing = State;
    }
}
