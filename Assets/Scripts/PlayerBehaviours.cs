using UnityEngine;
using System.Collections;

public class PlayerBehaviours : MonoBehaviour {

    public byte PlayerColour;
    public GameObject[] SpawnPoints;
    string PlayerCommand;
    int health;
    bool Stance;
    GameMaster GM;

    // Use this for initialization
    void Start() {
        health = GM.GetHealth();
        transform.position = SpawnPoints[PlayerColour].transform.position;
        PlayerCommand = "Player " + PlayerColour.ToString() + " ";
        Stance = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(PlayerCommand + "Toggle"))
        {
            SwitchStance();
        }
        for (int i = 0; i < SpawnPoints.Length; i++)
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
