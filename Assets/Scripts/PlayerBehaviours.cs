using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerBehaviours : MonoBehaviour {

    byte PlayerColour;
    string PlayerCommand;
    int health;
    bool Stance;
    GameMaster GM;
    int count = 0;
    Transform Child;
    float toggleCD = 0;
    SpriteRenderer SpRenderer;
    ShieldFade ChildFade;

    public List<byte> LPEnemies;
    public List<bool> HPEnemies;

    // Use this for initialization
    void Start() {
        SpRenderer = gameObject.GetComponent<SpriteRenderer>();
        SpRenderer.sortingOrder = 1;
        Child = transform.GetChild(0);
        ChildFade =  Child.gameObject.GetComponent<ShieldFade>();
        PlayerCommand = "Player " + PlayerColour.ToString() + " ";
        GM = GameObject.FindObjectOfType<GameMaster>();
        health = GM.GetHealth();
        transform.position = GM.SpawnPoints[PlayerColour].transform.position;
        Stance = false;
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
        if (toggleCD < Time.time && (Input.GetButton(PlayerCommand + "Toggle")||Input.GetKeyDown(KeyCode.Space)))
        {
            toggleCD = Time.time + 0.3f; 
            Debug.Log(Stance);
            SwitchStance();
        }

        for (int i = 0; i < GM.SpawnPoints.Length; i++)
        {
            try
            {
                if (Input.GetButton(PlayerCommand + "Attack Player " + i))
                {
                    SendEnemyToPlayer(i);
                }
            }
            catch
            {
                //Will fail once per player
            }
            
        }
    }

    void SwitchStance()
    {
        Stance = !Stance;
        ChildFade.Live(Stance);
        if (Stance)
        {
            SpRenderer.sortingOrder = 20;
        }
        else
        {
            SpRenderer.sortingOrder = 0;
        }
    }

    void SendEnemyToPlayer(int i)
    {
        GM.Players[i].LPEnemies.Add(PlayerColour);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        EnemyScript ScriptOnCol = col.gameObject.GetComponent<EnemyScript>();
        if (Stance == ScriptOnCol.GetStance())
        {
            ScriptOnCol.DIE();
        }
        else
        {
            health -= GM.GetHealthStep();
            //ScriptOnCol.DIE();
        }
    }

    public void SetPlayerColour(byte i)
    {
        PlayerColour = i;
    }
}
