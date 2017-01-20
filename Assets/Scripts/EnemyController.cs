using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameMaster gm;
    
    [SerializeField]
    PlayerBehaviours[] players;

    float lastSpawn;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameMaster>();
        lastSpawn = Time.time;
    }
    void FixedUpdate() {
        if (lastSpawn + gm.GetSpawnTime() < Time.time)
        {
            lastSpawn = Time.time;
            for (int i = 0; i < players.Length; i++)
            {
                players[i].SpawnEnemy();
            }
        }
    }

    public void SpawnEnemy(byte PlayerColour) {
        Vector3 pos = gm.SpawnPoints[PlayerColour].transform.position;
        EnemyScript enemy = Instantiate(enemyPrefab, new Vector3(Mathf.Abs(pos.x), pos.y, pos.z), Quaternion.identity) as EnemyScript;
        enemy.SetColor(gm.Colours[PlayerColour]);
    }
}
