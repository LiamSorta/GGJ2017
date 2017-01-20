using UnityEngine;
using System.Collections;

public class PlayerBehaviours : MonoBehaviour {

    public byte PlayerColour;
    public GameObject[] SpawnPoints;
    string PlayerCommand;
    int health;

    // Use this for initialization
    void Start() {
        transform.position = SpawnPoints[PlayerColour].transform.position;
        PlayerCommand = "Player " + PlayerColour.ToString() + " ";
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
            if (Input.GetButton(PlayerCommand + "Attack Player" + i)) 
            {
                SendEnemyToPlayer(i);
            }
        }
    }

    void SwitchStance()
    {
 
    }

    void SendEnemyToPlayer(int i)
    {

    }
}
