using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class PlayerBehaviours : MonoBehaviour {

    byte PlayerColour;
    string PlayerCommand;
    public int health;
    bool Stance;
    GameMaster GM;
    int count = 0;
    Transform Child;
    float toggleCD = 0;
    SpriteRenderer SpRenderer;
    ShieldFade ChildFade;
    bool Dead = false;

    float colorTime;

    float neutAdd; 

    public List<byte> LPEnemies;
    public List<bool> HPEnemies;
    int StoredEnemies = 0;
    AudioClip SelectedTrack;
    AudioSource MPlayer;
    Animator Anim;

    // Use this for initialization
    void Start() {
        MPlayer = GetComponent<AudioSource>();
        Anim = GetComponent<Animator>();
        SpRenderer = gameObject.GetComponent<SpriteRenderer>();
        SpRenderer.sortingOrder = 1;
        Child = transform.GetChild(0);
        ChildFade =  Child.gameObject.GetComponent<ShieldFade>();
        PlayerCommand = "Player " + PlayerColour.ToString() + " ";
        GM = GameObject.FindObjectOfType<GameMaster>();
        health = GM.GetHealth();
        transform.position = GM.SpawnPoints[PlayerColour].transform.position;
        Stance = false;
        int track = Random.Range(0, GM.Musics.GetLength(0));
        SelectedTrack = GM.Musics[track];
        GM.GMPlayer[PlayerColour+1].clip = SelectedTrack;
        GM.GMPlayer[PlayerColour + 1].Play();
    }


    public void SpawnEnemy()
    {
        if (HPEnemies.Count > 0)
        {
            GM.enemyCon.SpawnEnemy(PlayerColour,4);
            HPEnemies.RemoveAt(0);
        }
        else if (LPEnemies.Count > 0)
        {
            GM.enemyCon.SpawnEnemy(PlayerColour,LPEnemies[0]);
            LPEnemies.RemoveAt(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (colorTime + 0.25f < Time.time)
        {
            GM.Warnings[PlayerColour].enabled = false;
        }
        if (!Dead)
        {
            GM.StoredTexts[PlayerColour].text = StoredEnemies.ToString();
            GM.IncomingTexts[PlayerColour].text = (LPEnemies.Count + HPEnemies.Count).ToString();
            GM.HealthTexts[PlayerColour].text = health.ToString();
            GM.GMPlayer[PlayerColour + 1].volume = ((100-health) / 100f);

            if(neutAdd + Mathf.Clamp((3f-Time.time/40),3f,3f) < Time.time)
            {
                neutAdd = Time.time;
                HPEnemies.Add(true);
            }
            if(health <= 0)
            {
                Dead = true;
            }
            if (toggleCD < Time.time && (Input.GetButtonDown(PlayerCommand + "Toggle")))
            {
                toggleCD = Time.time + 0.3f;

                SwitchStance();
            }

            for (int i = 0; i < GM.SpawnPoints.Length; i++)
            {
                try
                {
                    if (Input.GetButtonDown(PlayerCommand + "Attack Player " + i))
                    {
                        if (StoredEnemies > 0)
                        {
                            
                            SendEnemyToPlayer(i);
                        }
                    }
                }
                catch
                {
                    //Will fail once per player
                }

            }
        }
        else
        {
            GameObject.FindObjectOfType<PlayerManager>().DeadPlayer();

            SpRenderer.enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }
    }

    void SwitchStance()
    {
        Stance = !Stance;
        ChildFade.Live(Stance);
        if (Stance)
        {
            MPlayer.clip = GM.Swords[Random.Range(0, GM.Swords.GetLength(0))];
            MPlayer.Play();
            Anim.SetBool("StanceSwitch", false);
            SpRenderer.sortingOrder = 20;
        }
        else
        {
            MPlayer.clip = GM.Shields[Random.Range(0, GM.Shields.GetLength(0))];
            MPlayer.Play();
            Anim.SetBool("StanceSwitch", true);
            SpRenderer.sortingOrder = 0;
        }
    }

    void SendEnemyToPlayer(int i)
    {
        GM.Players[i].LPEnemies.Add(PlayerColour);
        StoredEnemies--;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        EnemyScript ScriptOnCol = col.gameObject.GetComponent<EnemyScript>();
        if (Stance == ScriptOnCol.GetStance())
        {
            StoredEnemies++;
            GM.Warnings[PlayerColour].color = Color.green;
            GM.Warnings[PlayerColour].enabled = true;
            colorTime = Time.time;
            ScriptOnCol.DIE();
        }
        else
        {
            GM.Warnings[PlayerColour].color = Color.red;
            GM.Warnings[PlayerColour].enabled = true;
            colorTime = Time.time;
            health -= GM.GetHealthStep();
            ScriptOnCol.DIE();
        }
    }

    public void SetPlayerColour(byte i)
    {
        PlayerColour = i;
    }
}
