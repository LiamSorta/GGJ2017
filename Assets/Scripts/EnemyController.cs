using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameMaster gm;

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
            for (int i = 0; i < gm.Players.Length; i++)
            {
                gm.Players[i].SpawnEnemy();
            }
        }
    }

    public void SpawnEnemy(byte PlayerColour,byte SendingPlayer) {
        Vector3 pos = gm.SpawnPoints[PlayerColour].transform.position;
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(Mathf.Abs(pos.x), pos.y, pos.z), Quaternion.identity) as GameObject;
        enemy.GetComponent<EnemyScript>().SetColor(gm.Colours[SendingPlayer]);
    }

    void AddToHP(byte i)
    {
        gm.Players[i].HPEnemies.Add(false);
    }
}
