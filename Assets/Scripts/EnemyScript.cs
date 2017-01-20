using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    bool Stance;
    GameMaster GM;

	// Use this for initialization
	void Start () {
        GM = GameObject.FindObjectOfType<GameMaster>();
        int value = Random.Range(0, 100);
        if (value >= 50)
        {
            Stance = false;
        }
        else
        {
            Stance = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector3.right * GM.GetSpeed() * Time.deltaTime);
	}

    public void DIE()
    {
        GameObject.Destroy(gameObject);
    }

    public bool GetStance()
    {
        return Stance;
    }

    public void SetColor(Color32 colour)
    {

    }
}
