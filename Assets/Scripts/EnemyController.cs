using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    GameObject enemy, enemy2;

    [SerializeField]
    GameMaster gm;
    
    [SerializeField]
    Player[] players;
    
    void FixedUpdate() {
        for (int i = 0; i < players.Length; i++) {
            players[i].SpawnEnemy();
        }
    }

    void SpawnEnemy(int lane, Color32 colour) {
        Enemy enemy = Instantiate(enemy, Mathf.Abs(gm.GetLanes(lane).transform.position.x), Quaternion.identity) as Enemy;
        enemy.SetColor(colour);
    }
}
