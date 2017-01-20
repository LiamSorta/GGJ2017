﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerBehaviours : MonoBehaviour {

    public byte PlayerColour;
    string PlayerCommand;
    int health;
    bool Stance;
    GameMaster GM;

    public List<EnemyScript> LPEnemies;
    public List<EnemyScript> HPEnemies;

    // Use this for initialization
    void Start() {
        PlayerCommand = "Player " + PlayerColour.ToString() + " ";
        GM = GameObject.FindObjectOfType<GameMaster>();
        health = GM.GetHealth();
        transform.position = GM.SpawnPoints[PlayerColour].transform.position;
        Stance = false;
    }


    public void SpawnEnemy()
    {
        if(HPEnemies.Count > 0)
        {
            GM.enemyCon.SpawnEnemy(PlayerColour);
            HPEnemies.RemoveAt(0);
        }
        else if (LPEnemies.Count > 0)
        {
            GM.enemyCon.SpawnEnemy(PlayerColour);
            LPEnemies.RemoveAt(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(PlayerCommand + "Toggle"))
        {
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
        if (Stance)
        {
            Stance = false;
        }
        else
        {
            Stance = true;
        }
    }

    void SendEnemyToPlayer(int i)
    {

    }

    void OnTrigger2DEnter(Collider2D col)
    {
        EnemyScript ScriptOnCol = col.gameObject.GetComponent<EnemyScript>();
        if (Stance == ScriptOnCol.GetStance())
        {
            ScriptOnCol.DIE();
        }
        else
        {
            health -= GM.GetHealthStep();
        }
    }
}
